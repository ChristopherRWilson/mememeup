using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;

namespace MemeMeUp.Models.Helpers
{
    public class MemeText
    {
        public static string SplitSentence(string Sentence, int PreferedLineLength = 35)
        {
            int numberOfLines = (int)((Sentence.Length / PreferedLineLength) + .5);
            int targetLineLength = (Sentence.Length / (numberOfLines + 1));
            int targetLineLengthMin = (Sentence.Length / (numberOfLines + 1));
            string[] Words = Sentence.Split(' ');
            StringBuilder newSentence = new StringBuilder();
            int currentLineLength = 0;

            for (int i = 0; i < Words.Length; i++)
            {
                string thisWord, nextWord;
                int thisWordLength, nextWordLength;

                thisWord = Words[i];
                nextWord = i + 1 == Words.Length ? string.Empty : Words[i + 1];

                thisWordLength = thisWord.Length;
                nextWordLength = nextWord.Length;

                newSentence.Append (thisWord);
                
                currentLineLength += thisWordLength;

                if (currentLineLength >= targetLineLengthMin && (currentLineLength + nextWordLength + 1) > targetLineLength)
                {
                    newSentence.Append("\n");
                    currentLineLength = 0;
                }
                else
                {
                    newSentence.Append(' ');
                    currentLineLength++;
                }
            }

            return newSentence.ToString();
        }
    }
}