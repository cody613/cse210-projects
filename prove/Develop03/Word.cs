using System;

public class Word
{
    private string _text;
    private bool _isHidden;
    private bool _isHinted;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
        _isHinted = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Hint()
    {
        _isHinted = true;
    }

    public bool IsHinted()
    {
        return _isHinted;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden && _isHinted)
        {
            string hintedWord = _text[0].ToString();
            for (int i = 1; i < _text.Length; i++)
            {
                hintedWord += "_";
            }
            return hintedWord;
        }
        else if (_isHidden)
        {
            string underscores = "";
            for (int i = 0; i < _text.Length; i++)
            {
                underscores += "_";
            }
            return underscores;
        }
        else
        {
            return _text;
        }
    }
}