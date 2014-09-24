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
            sentence = classifier.findSentence();    
            testList = classifier.getSentenceBuilder();

            Assert.AreEqual(String.Empty, sentence);
        }

        [TestMethod]
        public void InputAndOutputListsSouldBeEqual()
        {
            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.What);
            sentence = classifier.findSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hello);
            sentence = classifier.findSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Age);
            sentence = classifier.findSentence();           
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();         
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();  
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Name);
            sentence = classifier.findSentence();
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
            sentence = classifier.findSentence();       
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.What);
            sentence = classifier.findSentence();    
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hello);
            sentence = classifier.findSentence();      
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int) WordsEnum.Age);
            sentence = classifier.findSentence();
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int) WordsEnum.You);
            sentence = classifier.findSentence();
            testList = classifier.getSentenceBuilder();

            StringAssert.Equals("How old are you?", sentence);
        }

        [TestMethod]
        public void ItShouldReturnHowOldAreYou2()
        {
            classifier.addCode((int)WordsEnum.Hello);
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.City);
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Live);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Age);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hello);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Age);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Age);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            StringAssert.Equals("How old are you?", sentence);
        }

        [TestMethod]
        public void ItShouldReturnAreYouHungry()
        {
            classifier.addCode((int)WordsEnum.Hello);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.City);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Live);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Age);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hello);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Age);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hungry);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hungry);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hungry);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            StringAssert.Equals("Are you hungry?", sentence);
        }

        [TestMethod]
        public void ItShouldReturnWhatDoYouWantToEat()
        {
            classifier.addCode((int)WordsEnum.Hello);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.City);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Live);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Age);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hello);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Age);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hungry);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hungry);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Hungry);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.What);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.You);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            classifier.addCode((int)WordsEnum.Food);
            sentence = classifier.findSentence();
            
            testList = classifier.getSentenceBuilder();

            StringAssert.Equals("What do you want to eat?", sentence);
        }
    }
}
