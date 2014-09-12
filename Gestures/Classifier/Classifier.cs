namespace KSL.Gestures.Classifier
{
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
        }

        public void findSentence()
        {
            if (this.sentenceBuilder.Count < 1)
                return;

            for (int i = currentWordIndex; i < this.sentenceBuilder.Count; i += 1)
            {
                bool AreThereMatches = false;

                foreach (SentenceStructure s in this.sentencesDictionary)
                {
                    if (this.notMatchList.Contains(s.ID) || this.sentenceBuilder.Count > s.Codes.Count)
                        continue;

                    if (this.sentenceBuilder[i] != s.Codes[i])
                    {
                        this.notMatchList.Add(s.ID);
                        if (!AreThereMatches)
                            AreThereMatches = false;

                        continue;
                    }

                    if (this.sentenceBuilder.Count == s.Codes.Count && this.sentenceBuilder.SequenceEqual(s.Codes))
                    {
                        this.foundSentence = s.Text;
                        AreThereMatches = true;

                        return;
                    }

                    AreThereMatches = true;
                }

                if (!AreThereMatches)
                {
                    this.foundSentence = String.Empty;
                    currentWordIndex = currentWordIndex <= 0 ? 0 : currentWordIndex - 1;
                    i = currentWordIndex;
                    this.sentenceBuilder.RemoveAt(i);
                    this.notMatchList.Clear();

                    findSentence();
                }

                currentWordIndex += 1;
            }
        }

        public string getSentence()
        {
            return this.foundSentence;
        }

        public List<int> getSentenceBuilder()
        {
            List<int> buffer = this.sentenceBuilder;

            if (!String.IsNullOrEmpty(this.foundSentence))
                this.clear();

            return buffer;
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
