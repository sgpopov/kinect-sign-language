namespace KSL.Gestures.Classifier
{
    using KSL.Gestures.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Classifier
    {
        #region "Declarations"

        private static readonly Classifier instance = new Classifier();

        private List<int> sentenceBuilder = new List<int>();

        private int currentWordIndex = 0;

        private List<int> notMatchList = new List<int>();

        private string foundSentence = String.Empty;

        private List<SentenceStructure> sentencesDictionary = new List<SentenceStructure>();

        private bool areThereMatches = false;

        private Logger logger = Logger.getInstance;

        #endregion

        #region "Constructors"

        static Classifier() { }

        private Classifier() { }

        #endregion

        public static Classifier getInstance
        {
            get { return instance; }
        }

        public void init()
        {
            SentenceStructure s = new SentenceStructure
            {
                ID = 1,
                Codes = new List<int> { (int)WordsEnum.City, (int)WordsEnum.You, (int)WordsEnum.Live },
                Text = "What city do you live in"
            };
            this.sentencesDictionary.Add(s);

            s = new SentenceStructure
            {
                ID = 2,
                Codes = new List<int> { (int)WordsEnum.You, (int)WordsEnum.Name },
                Text = "What is yout name?"
            };
            this.sentencesDictionary.Add(s);

            s = new SentenceStructure
            {
                ID = 3,
                Codes = new List<int> { (int)WordsEnum.You, (int)WordsEnum.Drive },
                Text = "Can you drive [a car]?"
            };
            this.sentencesDictionary.Add(s);

            s = new SentenceStructure
            {
                ID = 4,
                Codes = new List<int> { (int)WordsEnum.Age, (int)WordsEnum.You },
                Text = "How old are you?"
            };
            this.sentencesDictionary.Add(s);

            s = new SentenceStructure
            {
                ID = 5,
                Codes = new List<int> { (int)WordsEnum.You, (int)WordsEnum.Drive, (int)WordsEnum.Bicycle },
                Text = "Can you drive a bicycle?"
            };
            this.sentencesDictionary.Add(s);
        }

        public void addCode(int wordCode)
        {
            this.sentenceBuilder.Add(wordCode);
            logger.logMessage(String.Format("A new word with code [ {0} ] was added.", wordCode), errorFlag.WordAdded);
            logger.logMessage(String.Format("New sentence builder state: [ {0} ]", String.Join(", ", sentenceBuilder)), errorFlag.SentenceBuilderState);
        }

        public void findSentence()
        {
            this.foundSentence = String.Empty;

            if (this.sentenceBuilder.Count < 1)
                return;

            for (int i = currentWordIndex; i < this.sentenceBuilder.Count; i += 1)
            {
                areThereMatches = false;

                foreach (SentenceStructure s in this.sentencesDictionary)
                {
                    if (this.notMatchList.Contains(s.ID) || this.sentenceBuilder.Count > s.Codes.Count)
                        continue;

                    if (this.sentenceBuilder[i] != s.Codes[i])
                    {
                        this.notMatchList.Add(s.ID);
                        if (!areThereMatches)
                            areThereMatches = false;

                        continue;
                    }

                    if (this.sentenceBuilder.Count == s.Codes.Count && this.sentenceBuilder.SequenceEqual(s.Codes))
                    {
                        this.foundSentence = s.Text;
                        areThereMatches = true;
                        logger.logMessage(String.Format("A new sentence was detected: Text = '{0}'; Codes = [ {1} ]", s.Text, String.Join(", ", this.sentenceBuilder)), errorFlag.SentenceDetected);

                        return;
                    }

                    areThereMatches = true;
                }

                if (!this.areThereMatches)
                {                 
                    this.foundSentence = String.Empty;
                    this.currentWordIndex = currentWordIndex <= 0 ? 0 : currentWordIndex - 1;
                    i = currentWordIndex;
                    logger.logMessage(String.Format("Word with code [ {0} ] was removed.", sentenceBuilder[i]), errorFlag.WordRemove);
                    this.sentenceBuilder.RemoveAt(i);
                    this.notMatchList.Clear();

                    logger.logMessage(String.Format("New sentence builder state: [ {0} ]", String.Join(", ", sentenceBuilder)), errorFlag.SentenceBuilderState);

                    findSentence();
                }

                if(this.sentenceBuilder.Count > 0)
                    this.currentWordIndex += 1;
            }
        }

        public bool getAreThereMatches()
        {
            return this.areThereMatches;
        }

        public string getSentence()
        {
            return this.foundSentence;
        }

        public List<int> getSentenceBuilder()
        {
            List<int> temp = new List<int>(this.sentenceBuilder);

            if (!String.IsNullOrEmpty(this.foundSentence))
                this.clear();

            return temp;
        }

        private void clear()
        {
            this.sentenceBuilder.Clear();
            this.notMatchList.Clear();
            this.foundSentence = String.Empty;
            this.currentWordIndex = 0;
        }
    }
}
