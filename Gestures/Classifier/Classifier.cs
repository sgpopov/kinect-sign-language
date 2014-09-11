namespace KSL.Gestures.Classifier
{
    using KSL.Gestures.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Classifier
    {
        private static readonly Classifier instance = new Classifier();

        static Classifier() { }

        private Classifier() { }

        private List<int> input = new List<int>();

        private bool foundMatch = false;

        static readonly Dictionary<string, List<int>> sentencesDictionary = new Dictionary<string, List<int>> {
            { "What city do you live in?", new List<int> { (int) WordsDictionaryEnum.City, (int) WordsDictionaryEnum.You, (int) WordsDictionaryEnum.Live } },
            { "What is yout name?", new List<int> { (int) WordsDictionaryEnum.You, (int) WordsDictionaryEnum.Name } },
            { "Can you drive [a car]?", new List<int> { (int) WordsDictionaryEnum.You, (int) WordsDictionaryEnum.Drive } },
            { "How old are you?", new List<int> { (int) WordsDictionaryEnum.Age, (int) WordsDictionaryEnum.You } },
            { "Can you drive a bicycle?", new List<int> { (int) WordsDictionaryEnum.You, (int) WordsDictionaryEnum.Drive, (int) WordsDictionaryEnum.Bicycle } }
        };

        public static Classifier getInstance
        {
            get { return instance; }
        }

        public void addCode(int wordCode)
        {
            this.input.Add(wordCode);
        }

        public String matchForSentence()
        {
            if (this.input.Count < 2)
            {
                return String.Empty;
            }

            foreach (var item in sentencesDictionary)
            {
                var Value = item.Value;
                var Key = item.Key;

                if (input.SequenceEqual(Value))
                {
                    if (foundMatch)
                    {
                        clearInputData();
                        return Key;
                    }

                    foundMatch = true;

                    return Key;
                }
            }

            clearInputData();

            return String.Empty;
        }

        private void clearInputData()
        {
            this.foundMatch = false;
            this.input.Clear();
        }
    }
}
