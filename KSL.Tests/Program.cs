namespace KSL.Tests
{
    using KSL.Gestures.Classifier;
    using KSL.Gestures.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private List<int> input = new List<int>();
        private int currentWordIndex = 0;
        private List<int> notMatchList = new List<int>();
        private string foundSentence = String.Empty;

        private List<SentenceStructure> sentencesDictionary = new List<SentenceStructure>
        {
            {
                new SentenceStructure {
                    ID = 1,
                    Codes = new List<int> { (int) WordsEnum.City, (int) WordsEnum.You, (int) WordsEnum.Live },
                    Text = "What city do you live in"
                }
            },
            {
                new SentenceStructure {
                    ID = 2,
                    Codes = new List<int> { (int) WordsEnum.You, (int) WordsEnum.Name },
                    Text = "What is yout name?"
                }
            },
            {
                new SentenceStructure {
                    ID = 3,
                    Codes = new List<int> { (int) WordsEnum.You, (int) WordsEnum.Drive },
                    Text = "Can you drive [a car]?"
                }
            },
            {
                new SentenceStructure {
                    ID = 4,
                    Codes = new List<int> { (int) WordsEnum.Age, (int) WordsEnum.You },
                    Text = "How old are you?"
                }
            },
            {
                new SentenceStructure {
                    ID = 5,
                    Codes = new List<int> { (int) WordsEnum.You, (int) WordsEnum.Drive, (int) WordsEnum.Bicycle },
                    Text = "Can you drive a bicycle?"
                }
            }
        };
        
        static readonly Dictionary<string, List<int>> sentencesDictionary2 = new Dictionary<string, List<int>> {
            { "What city do you live in?", new List<int> { (int) WordsEnum.City, (int) WordsEnum.You, (int) WordsEnum.Live } },
            { "What is yout name?", new List<int> { (int) WordsEnum.You, (int) WordsEnum.Name } },
            { "Can you drive [a car]?", new List<int> { (int) WordsEnum.You, (int) WordsEnum.Drive } },
            { "How old are you?", new List<int> { (int) WordsEnum.Age, (int) WordsEnum.You } },
            { "Can you drive a bicycle?", new List<int> { (int) WordsEnum.You, (int) WordsEnum.Drive, (int) WordsEnum.Bicycle } }
        };

        static void Main(string[] args)
        {
            Program p = new Program();

            p.addCode((int)WordsEnum.You);
            Console.WriteLine(p.displaySentence());

            p.addCode((int)WordsEnum.You);
            Console.WriteLine(p.displaySentence());

            p.addCode((int)WordsEnum.Drive);
            Console.WriteLine(p.displaySentence());

            p.addCode((int)WordsEnum.Bicycle);
            Console.WriteLine(p.displaySentence());
        }

        private void addCode(int wordCode)
        {
            this.input.Add(wordCode);
        }

        private string displaySentence()
        {
            find();
            return foundSentence;
        }

        private void find()
        {
            if (this.input.Count < 1)
                return;

            for (int i = currentWordIndex; i < this.input.Count; i += 1)
            {
                bool AreThereMatches = false;

                foreach (SentenceStructure s in sentencesDictionary)
                {
                    if (notMatchList.Contains(s.ID) || this.input.Count > s.Codes.Count)
                        continue;

                    if (this.input[i] != s.Codes[i])
                    {
                        notMatchList.Add(s.ID);
                        if (!AreThereMatches)
                            AreThereMatches = false;

                        continue;
                    }

                    if (input.Count == s.Codes.Count)
                        foundSentence = s.Text;

                    AreThereMatches = true;
                }

                if (!AreThereMatches)
                {
                    currentWordIndex -= 1;
                    i = currentWordIndex;
                    input.RemoveAt(i);
                    this.notMatchList.Clear();

                    find();
                }

                currentWordIndex += 1;
            }

        }
    }
}
