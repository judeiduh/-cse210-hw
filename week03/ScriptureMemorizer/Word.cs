using System;

public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    // Constructor to initialize the word
    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    // Method to hide the word by replacing it with underscores
    public void Hide()
    {
        if (!IsHidden)
        {
            IsHidden = true;
            Text = new string('_', Text.Length);  // Replace the word with underscores
        }
    }

    // Method to check if the word is hidden
    public bool IsWordHidden()
    {
        return IsHidden;
    }

    // Method to display the word (either the actual word or underscores)
    public void DisplayWord()
    {
        Console.Write(Text + " ");
    }
}
