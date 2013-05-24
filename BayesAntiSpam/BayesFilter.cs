using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SimHashBusiness.Analysers;
using SimHashBusiness.Interfaces;

namespace BayesAntiSpam
{
    public class BayesFilter
    {
        private IAnalyser analyser = new SimHashAnalyser();  
        private int _ngood;
        private int _nbad;

        // Values in PG's original article:
        private int MinCountForInclusion = 1;		// 5
        private double MinScore = 0.011;				// 0.01
        private double MaxScore = 0.99;				// 0.99
        private double LikelySpamScore = 0.9998;		// 0.9998
        private double CertainSpamScore = 0.9999;	// 0.9999
        private int CertainSpamCount = 10;			// 10
        private int InterestingWordCount = 15;		// 15 (later changed to 20)

        /// <summary>
        /// Do the math to populate the probabilities collection
        /// </summary>
        public SortedDictionary<string, double> CalculateProbabilities(SortedDictionary<string, double> _bad, SortedDictionary<string, double> _good)
        {
            SortedDictionary<string, double> _prob = new SortedDictionary<string, double>();

            _ngood = _good.Count;
            _nbad = _bad.Count;
            foreach (string token in _good.Keys)
            {
                Double? pb = CalculateTokenProbability(token, _bad, _good);
                if (pb != null)
                {
                    _prob[token] = (double)pb;
                }
            }
            foreach (string token in _bad.Keys)
            {
                if (!_prob.ContainsKey(token))
                {
                    Double? pb = CalculateTokenProbability(token, _bad, _good);
                    if (pb != null)
                    {
                        _prob[token] = (double)pb;
                    }
                }
            }

            return _prob;
        }

        /// <summary>
        /// Returns the probability that the supplied body of text is spam
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public double Test(List<string> shinglesNewMail, SortedDictionary<string, double> _prob)
        {
            SortedList probs = new SortedList();

            // Spin through every word in the body and look up its individual spam probability.
            // Keep the list in decending order of "Interestingness"
            int index = 0;
            foreach (var token in shinglesNewMail)
            {
                if (_prob.ContainsKey(token))
                {
                    // "interestingness" == how far our score is from 50%.  
                    // The crazy math below is building a string that lets us sort alphabetically by interestingness.
                    double prob = _prob[token];
                    string key = (0.5 - Math.Abs(0.5 - prob)).ToString(".00000") + token + index++;
                    probs.Add(key, prob);
                }
            }

            /* Combine the 15 most interesting probabilities together into one.  
             * The algorithm to do this is shown below and described here:
             * http://www.paulgraham.com/naivebayes.html
             * 
             *				abc           
             *	---------------------------
             *	abc + (1 - a)(1 - b)(1 - c)
             *
             */

            double mult = 1;  // for holding abc..n
            double comb = 1;  // for holding (1 - a)(1 - b)(1 - c)..(1-n)
            index = 0;
            foreach (string key in probs.Keys)
            {
                double prob = (double)probs[key];
                mult = mult * prob;
                comb = comb * (1 - prob);

                Debug.WriteLine(index + " " + probs[key] + " " + key);

                if (++index > InterestingWordCount)
                    break;
            }

            return mult / (mult + comb);
        }

        /// <summary>
        /// For a given token, calculate the probability that will appear in a spam text
        /// by comparing the number of good and bad texts it appears in already.
        /// </summary>
        /// <param name="token"></param>
        private Double? CalculateTokenProbability(string token, SortedDictionary<string, double> _bad, SortedDictionary<string, double> _good)
        {
            /*
             * This is a direct implementation of Paul Graham's algorithm from
             * http://www.paulgraham.com/spam.html
             * 
             *	(let ((g (* 2 (or (gethash word good) 0)))
             *		  (b (or (gethash word bad) 0)))
             *	   (unless (< (+ g b) 5)
             *		 (max .01
             *			  (min .99 (float (/ (min 1 (/ b nbad))
             *								 (+ (min 1 (/ g ngood))   
             *									(min 1 (/ b nbad)))))))))
             */
            double g = GetTokenCount(_good, token);
            double b = GetTokenCount(_bad, token);

            if (g + b >= MinCountForInclusion)
            {
                double goodfactor = Min(1, (double)g / (double)_ngood);
                double badfactor = Min(1, (double)b / (double)_nbad);

                double prob = Max(MinScore,
                                Min(MaxScore, badfactor / (goodfactor + badfactor))
                            );

                // special case for Spam-only tokens.
                // .9998 for tokens only found in spam, or .9999 if found more than 10 times
                if (g == 0)
                {
                    prob = (b > CertainSpamCount) ? CertainSpamScore : LikelySpamScore;
                }

                return prob;
            }

            return null;
        }

        private double GetTokenCount(SortedDictionary<string, double> shingles, string token)
        {
            int count = 0;

            if (shingles.ContainsKey(token))
            {
                return shingles[token];
            }

//            foreach (var shingle in shingles)
//            {
//                if (analyser.GetLikenessValue(shingle.Key, token) > 0.9)
//                {
//                    return shingles[shingle.Key];
//                }
//            }

            return count;
        }

        private double Max(double one, double two)
        {
            return one > two ? one : two;
        }

        private double Min(double one, double two)
        {
            return one < two ? one : two;
        }
    }
}
