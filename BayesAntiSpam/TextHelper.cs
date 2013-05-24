using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SimHashBusiness.Analysers;
using SimHashBusiness.Interfaces;

namespace BayesAntiSpam
{
    public class TextHelper
    {
        private int minLenghtWord = -1;
        private int shingleLenght = -1;

        public TextHelper()
        {
            
        }

        public TextHelper(int shingleLenght, int minLenghtWord)
        {
            this.shingleLenght = shingleLenght;
            this.minLenghtWord = minLenghtWord;
        }

        private string GetTextWithoutSpecialChars(string text)
        {
            Regex rgx = new Regex("[^йцукенгшщзхъфывапроёлджэячсмитьбюqwertyiopasdfghjklzxcvbnm ]");
            return rgx.Replace(text.ToLower(), " ").Replace("   ", " ").Replace("  ", " ");
        }

        public List<string> GetShingles(string text)
        {
            return GetShingles(text, shingleLenght);
        }

        public List<string> GetShingles(string text, int shingleSize)
        {
            if (shingleSize < 1) shingleSize = 1;

            String textWithoutIncorrectSpecialChars = GetTextWithoutSpecialChars(text);
            List<string> words = new List<string>(textWithoutIncorrectSpecialChars.Split(new string[] { "\r\n", "\n", " " }, StringSplitOptions.None));

            List<string> wordsWithPossibleLenght = getLongWords(words, minLenghtWord);

            if (shingleSize == 1)
            {
                return wordsWithPossibleLenght;
            }

            List<string> shingles = new List<string>();
            for (int i = 0; i < wordsWithPossibleLenght.Count; i++)
            {
                StringBuilder sb = new StringBuilder();

                if (i + shingleSize < wordsWithPossibleLenght.Count)
                {
                    for (int j = 0; j < shingleSize; j++)
                    {
                        sb.Append(wordsWithPossibleLenght[i + j]);

                        if ((j != shingleSize - 1) && (shingleSize != 1)) 
                        {
                            sb.Append(" ");
                        }
                         
                    }
                    string shingle = sb.ToString();
                    shingles.Add(shingle);
                }
            }

            return shingles;
        }

        private List<string> getLongWords(IEnumerable<string> words, int minLength = 3)
        {
            List<string> longWords = new List<string>();
            foreach (var word in words)
            {
                if (word.Length >= minLength)
                {
                    longWords.Add(word);
                }
            }
            return longWords;
        }
    }
}
