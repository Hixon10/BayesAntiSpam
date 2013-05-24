using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using BayesAntiSpam;


namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
//            String pathToSpamText = Directory.GetCurrentDirectory() + "\\..\\..\\..\\BayesAntiSpam\\spam-text.txt";
//            String pathToHamText = Directory.GetCurrentDirectory() + "\\..\\..\\..\\BayesAntiSpam\\ham-text.txt";
//
//            TextHelper textHelper = new TextHelper();
//            Shingles shingles = new Shingles();
//            BayesFilter bayesFilter = new BayesFilter();
//
//            #region Обучение фильтра
//
//            shingles.ClearHamShingles();
//            shingles.ClearSpamShingles();
//
//            String spamText = File.ReadAllText(pathToSpamText);
//            String hamText = File.ReadAllText(pathToHamText);
//
//            var spamShingles = textHelper.GetShingles(spamText, 1);
//            var hamShingles = textHelper.GetShingles(hamText, 1);
//
//            shingles.AddSpamShignles(spamShingles);
//            shingles.AddHamShignles(hamShingles);
//
//            #endregion
//
//            String textForChecking = " На данный момент, еслнт, добавьте его в зависимо";
//
//            var textForCheckingShingles = textHelper.GetShingles(textForChecking, 1);
//
//            float probability = bayesFilter.GetPrediction(textForCheckingShingles, shingles.GetSpamShingles(),
//                                                          shingles.GetHamShingles());
//
//            Console.WriteLine(probability);

            BayesFilter bayesFilter = new BayesFilter();

            Dictionary<string, int> ham = new Dictionary<string, int>();
            ham.Add("hello",1);
            ham.Add("", 1);
            ham.Add("how", 1);
            ham.Add("are", 1);
            ham.Add("you", 2);
            ham.Add("did", 1);
            ham.Add("go", 1);
            ham.Add("to", 1);
            ham.Add("the", 1);
            ham.Add("park", 1);
            ham.Add("today", 1);

            Dictionary<string, int> spam = new Dictionary<string, int>();
            spam.Add("want" , 1);
            spam.Add("some", 1);
            spam.Add("viagra", 1);
            spam.Add("", 1);
            spam.Add("cialis", 1);
            spam.Add("the", 1);
            spam.Add("can", 1);
            spam.Add("make", 1);
            spam.Add("you", 1);
            spam.Add("larger", 1);

            List<string> text = new List<string>()
                {
                    "cialis",
                    "viagra",
                    "2",
                    "the"
                };

            //float probability = bayesFilter.GetPrediction(text, spam, ham);
            //Console.WriteLine(probability);

            Console.ReadKey();
        }
    }
}
