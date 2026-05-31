using System;
using System.Collections.Generic;

namespace Develop03
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            string[] splitWords = text.Split(' ');
            foreach (string wordText in splitWords)
            {
                _words.Add(new Word(wordText));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();
            
            List<int> visibleIndices = new List<int>();
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden())
                {
                    visibleIndices.Add(i);
                }
            }

            int actualToHide = Math.Min(numberToHide, visibleIndices.Count);

            for (int i = 0; i < actualToHide; i++)
            {
                int randomIndexInList = random.Next(visibleIndices.Count);
                int targetWordIndex = visibleIndices[randomIndexInList];
                
                _words[targetWordIndex].Hide();
                
                visibleIndices.RemoveAt(randomIndexInList);
            }
        }

        public string GetDisplayText()
        {
            List<string> displayedWords = new List<string>();
            foreach (Word word in _words)
            {
                displayedWords.Add(word.GetDisplayText());
            }

            string combinedText = string.Join(" ", displayedWords);
            return $"{_reference.GetDisplayText()} - {combinedText}";
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }
    }
}