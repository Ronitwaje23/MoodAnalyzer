using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzer
{
    public class MoodAnalyzerFactory
    {
        /// <summary>
        /// CreateMoodAnalyse method to create object of MoodAnalyse class.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyzer.MoodAnalyzerException">
        /// Class not found
        /// or
        /// Constructor not found
        /// </exception>
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            // create the pattern and checks whether constructor name and class name are equal
            string pattern = @"." + constructorName + "";
            Match result = Regex.Match(className, pattern);
            // if true then create object.
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                // if no class found then then throw class not found exception
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            // if constructor name not equal to class name then throw constructor not found exception
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor not found");
            }
        }
    }
}
    

