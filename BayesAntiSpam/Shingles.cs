using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BayesAntiSpam
{
    public class Shingles
    {
        private string PATH_TO_SPAM_SHINGLES_FILE;
        private string PATH_TO_HAM_SHINGLES_FILE;
        private string PATH_TO_PROBABILITIES;
        private char DELIMITER = '|';

        public Shingles()
        {
            PATH_TO_SPAM_SHINGLES_FILE = Directory.GetCurrentDirectory() + "\\..\\..\\..\\BayesAntiSpam\\spam-shingles.txt";
            PATH_TO_HAM_SHINGLES_FILE = Directory.GetCurrentDirectory() + "\\..\\..\\..\\BayesAntiSpam\\ham-shingles.txt";
            PATH_TO_PROBABILITIES = Directory.GetCurrentDirectory() + "\\..\\..\\..\\BayesAntiSpam\\probabilities.txt";
        }

        public SortedDictionary<string, double> GetProbabilities(int spamShinglesNumber = -1)
        {
            SortedDictionary<string, double> shingles = new SortedDictionary<string, double>();

            String[] text = File.ReadAllLines(PATH_TO_PROBABILITIES);
            foreach (var s in text)
            {
                string[] splitedShingle = s.Split(DELIMITER);

                if (!shingles.ContainsKey(splitedShingle[0]))
                {
                    shingles.Add(splitedShingle[0], double.Parse(splitedShingle[1]));
                }
            }

            return shingles;
        }

        public SortedDictionary<string, double> GetSpamShingles(int spamShinglesNumber = -1)
        {
            return GetShingles(PATH_TO_SPAM_SHINGLES_FILE, spamShinglesNumber);
        }

        public SortedDictionary<string, double> GetHamShingles(int hamShinglesNumber = -1)
        {
            return GetShingles(PATH_TO_HAM_SHINGLES_FILE, hamShinglesNumber);
        }

        public void ClearSpamShingles()
        {
            File.WriteAllText(PATH_TO_SPAM_SHINGLES_FILE,"");
        }

        public void ClearHamShingles()
        {
            File.WriteAllText(PATH_TO_HAM_SHINGLES_FILE, "");
        }

        public void ClearProbabilities()
        {
            File.WriteAllText(PATH_TO_PROBABILITIES, "");
        }

        public void AddSpamShingle(string shingle)
        {
            AddShingle(shingle, PATH_TO_SPAM_SHINGLES_FILE);
        }

        public void AddHamShingle(string shingle)
        {
            AddShingle(shingle, PATH_TO_HAM_SHINGLES_FILE);
        }
        
        public void AddSpamShignles(IEnumerable<string> shingles)
        {
            AddShignles(shingles, PATH_TO_SPAM_SHINGLES_FILE);
        }

        public void AddHamShignles(IEnumerable<string> shingles)
        {
            AddShignles(shingles, PATH_TO_HAM_SHINGLES_FILE);
        }

        public void AddSpamShignles(SortedDictionary<string, double> shingles)
        {
            AddShignles(shingles, PATH_TO_SPAM_SHINGLES_FILE);
        }

        public void AddHamShignles(SortedDictionary<string, double> shingles)
        {
            AddShignles(shingles, PATH_TO_HAM_SHINGLES_FILE);
        }

        public void AddProbabilities(SortedDictionary<string, double> shingles)
        {
            AddShignles(shingles, PATH_TO_PROBABILITIES);
        }

        private void AddShignles(IEnumerable<string> shingles, string path)
        {
            String addingString = null;
            foreach (var shingle in shingles)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(shingle);
                sb.Append(DELIMITER.ToString());
                sb.Append("1\r\n");
                addingString += sb.ToString();
            }

            if (!String.IsNullOrWhiteSpace(addingString))
            {
                File.AppendAllText(path, addingString);
            }
        }

        private void AddShignles(SortedDictionary<string, double> shingles, string path)
        {
            String addingString = null;
            foreach (var shingle in shingles)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(shingle.Key);
                sb.Append(DELIMITER.ToString());
                sb.Append(shingle.Value);
                sb.Append("\r\n");
                addingString += sb.ToString();
            }

            if (!String.IsNullOrWhiteSpace(addingString))
            {
                File.AppendAllText(path, addingString);
            }
        }

        private void AddShingle(string shingle, string path)
        {
            String addingString = shingle + DELIMITER.ToString() + "1\r\n";
            File.AppendAllText(path, addingString);
        }

        private SortedDictionary<string, double> GetShingles(string path, int spamShinglesNumber = -1)
        {
            SortedDictionary<string, double> shingles = new SortedDictionary<string, double>();

            String[] text = File.ReadAllLines(path);
            foreach (var s in text)
            {
                string[] splitedShingle = s.Split(DELIMITER);

                if (shingles.ContainsKey(splitedShingle[0]))
                {
                    shingles[splitedShingle[0]] += 1;
                }
                else
                {
                    shingles.Add(splitedShingle[0], double.Parse(splitedShingle[1]));
                }
            }

//            if (spamShinglesNumber > -1)
//            {
//                var sortedDict = (from entry in shingles orderby entry.Value descending select entry).Take(spamShinglesNumber)
//    .ToDictionary(pair => pair.Key, pair => pair.Value);
//                return sortedDict;
//            }

            return shingles;
        } 
    }
}
