namespace KSL.Gestures.Classifier
{
    using System.Collections.Generic;

    public class SentenceStructure
    {
        public int ID { set; get; }

        public List<int> Codes { set; get; }

        public string Text { set; get; }
    }
}
