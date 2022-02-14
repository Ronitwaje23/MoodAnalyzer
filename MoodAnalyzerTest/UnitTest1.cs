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
        /// <summary>
        /// TC-4.1 Returns the mood analyser object
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyserReflection_ShouldReturnObject()
        {
            object expected = new AnalyzeMood();
            object actual = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalyzer.AnalyzeMood", "AnalyzeMood");
            expected.Equals(actual);
        }
        /// <summary>
        /// TC-4.2 should throw NO_SUCH_CLASS exception.
        /// </summary>
        [TestMethod]
        public void GivenClassNameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "Class not found";
            try
            {
                object actual = MoodAnalyzerFactory.CreateMoodAnalyse("Mood.AnalyzeMood", "AnalyzeMood");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
        /// <summary>
        /// TC-4.3 should throw NO_SUCH_CONTRUCTOR exception.
        /// </summary>
        [TestMethod]
        public void GivenConstructorNameImproper_ShouldReturnMoodAnalysisException()
        {
            string expected = "Constructor not found";
            try
            {
                object actual = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalyzer.AnalyzeMood", "MoodAnalyzer");
            }
            catch (MoodAnalyzerException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
    }
}