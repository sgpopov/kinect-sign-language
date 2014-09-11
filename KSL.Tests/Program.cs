namespace KSL.Tests
{
    using KSL.Gestures.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private List<int> input = new List<int>();

        private bool foundMatchOnce = false;

        private bool foundMatchTwice = false;

        static readonly Dictionary<string, List<int>> sentencesDictionary = new Dictionary<string, List<int>> {
            { "What city do you live in?", new List<int> { (int) WordsDictionaryEnum.City, (int) WordsDictionaryEnum.You, (int) WordsDictionaryEnum.Live } },
            { "What is yout name?", new List<int> { (int) WordsDictionaryEnum.You, (int) WordsDictionaryEnum.Name } },
            { "Can you drive [a car]?", new List<int> { (int) WordsDictionaryEnum.You, (int) WordsDictionaryEnum.Drive } },
            { "How old are you?", new List<int> { (int) WordsDictionaryEnum.Age, (int) WordsDictionaryEnum.You } },
            { "Can you drive a bicycle?", new List<int> { (int) WordsDictionaryEnum.You, (int) WordsDictionaryEnum.Drive, (int) WordsDictionaryEnum.Bicycle } }
        };

        static void Main(string[] args)
        {
            Program p = new Program();

            p.match((int)WordsDictionaryEnum.You);
            p.match((int)WordsDictionaryEnum.You);
            p.match((int)WordsDictionaryEnum.Drive);
            p.match((int)WordsDictionaryEnum.Bicycle);
        }

        private void match(int wordCode)
        {
            this.input.Add(wordCode);


            //Console.WriteLine(String.Format("Word = {0}, Count = {1}", wordCode, input.Count));

            if (this.input.Count < 2)
            {
                return;
            }

            string display;
            foreach (var item in sentencesDictionary)
            {
                var Value = item.Value;
                var Key = item.Key;

                if (input.SequenceEqual(Value))
                {
                    display = Key;
                    Console.WriteLine(display);
                }
            }
        }
    }
}
