namespace KSL.Tests
{
    using KSL.Gestures.Classifier;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class ClassifierTests
    {
        Classifier classifier = Classifier.getInstance;
        private List<int> testList = new List<int>();
        private string sentence = String.Empty;

        [TestInitialize]
        public void init()
        {
            classifier.init();
        }

        [TestMethod]
        public void ItShouldBeEmptySentence()
        {
            classifier.addCode((int) WordsEnum.Age);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            Assert.AreEqual(String.Empty, sentence);
        }

        [TestMethod]
        public void InputAndOutputListsSouldBeEqual()
        {
            classifier.addCode((int)WordsEnum.You);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.What);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hello);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Age);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Name);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            List<int> expectedList = new List<int>
            {
                (int) WordsEnum.You, (int) WordsEnum.Name 
            };

            CollectionAssert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void ItShouldReturnHowOldAreYou()
        {
            classifier.addCode((int)WordsEnum.You);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.What);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hello);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int) WordsEnum.Age);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int) WordsEnum.You);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            StringAssert.Equals("How old are you?", sentence);
        }

        [TestMethod]
        public void ItShouldReturnHowOldAreYou2()
        {
            classifier.addCode((int)WordsEnum.Hello);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.City);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Live);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Age);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hello);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Age);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Age);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            classifier.findSentence();
            sentence = classifier.getSentence();
            testList = classifier.getSentenceBuilder();

            StringAssert.Equals("How old are you?", sentence);
        }
    }
}
