using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;
using System;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Happy Mood")]
        public void GivenMessageShouldReturnHappy()
        {
            ///Follow AAA strategy
            ///Arrange , Act and in last Assert
            AnalyzeMood mood = new AnalyzeMood("I am in Happy Mood");
            string excepted = "happy";
            var actual = mood.Mood();
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [TestCategory("SAD Mood")]
        public void GivenMessageShouldReturnSad()
        {
            ///Follow AAA strategy
            ///Arrange , Act and in last Assert
            AnalyzeMood mood = new AnalyzeMood("I am in SAD Mood");
            string excepted = "sad";
            var actual = mood.Mood();
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        [TestCategory("Null Exception")]
        public void GivenNullShouldReturnCustomException()
        {
            ///Follow AAA strategy
            ///Arrange , Act and in last Assert
            string message = null;
            string excepted = "Message cann't be null";
            try
            {
                AnalyzeMood mood = new AnalyzeMood(message);
                string actual = mood.Mood();
            }
            catch (MoodAnalyzerException ex)
            {
                Console.WriteLine("Custom Exception :" + ex);
                Assert.AreEqual(excepted, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Worst Case Exception :" + ex);
            }
        }
        [TestMethod]
        [TestCategory("Empty Exception")]
        public void GivenEmptyShouldReturnCustomException()
        {
            ///Follow AAA strategy
            ///Arrange , Act and in last Assert
            string message = "";
            string excepted = "Message cann't be Empty";
            try
            {
                AnalyzeMood mood = new AnalyzeMood(message);
                string actual = mood.Mood();
            }
            catch (MoodAnalyzerException ex)
            {
                Console.WriteLine("Custom Exception :" + ex);
                Assert.AreEqual(excepted, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Worst Case Exception :" + ex);
            }
        }
    }
}