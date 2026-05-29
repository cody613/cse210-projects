using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] splitText = text.Split(' ');
        foreach (string wordString in splitText)
        {
            Word newWord = new Word(wordString);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> unhiddenWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                unhiddenWords.Add(word);
            }
        }
        if (unhiddenWords.Count < numberToHide)
        {
            numberToHide = unhiddenWords.Count;
        }
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int randomIndex = random.Next(unhiddenWords.Count);
            unhiddenWords[randomIndex].Hide();
            unhiddenWords.RemoveAt(randomIndex);
        }
    }

    public void HintRandomWords(int numberToHint)
    {
        List<Word> hiddenUnhintedWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (word.IsHidden() == true && word.IsHinted() == false)
            {
                hiddenUnhintedWords.Add(word);
            }
        }
        if (hiddenUnhintedWords.Count < numberToHint)
        {
            numberToHint = hiddenUnhintedWords.Count;
        }
        Random random = new Random();
        for (int i = 0; i < numberToHint; i++)
        {
            int randomIndex = random.Next(hiddenUnhintedWords.Count);
            hiddenUnhintedWords[randomIndex].Hint();
            hiddenUnhintedWords.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = "";
        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()} {scriptureText.Trim()}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                return false;
            }
        }
        return true;
    }
}