using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference ScriptureReference { get; set; }
    public List<Word> Words { get; set; }

    // Constructor to initialize scripture with reference and text
    public Scripture(string reference, string text)
    {
        ScriptureReference = new Reference(reference);
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    // Method to display the entire scripture (full text with hidden words replaced by underscores)
    public void DisplayScripture()
    {
        ScriptureReference.DisplayReference();
        Console.WriteLine();
        foreach (var word in Words)
        {
            word.DisplayWord();
        }
        Console.WriteLine();
    }

    // Method to hide a random word
    public void HideRandomWord()
    {
        var hiddenWords = Words.Where(w => !w.IsWordHidden()).ToList();
        if (hiddenWords.Count > 0)
        {
            Random rand = new Random();
            int index = rand.Next(hiddenWords.Count);
            hiddenWords[index].Hide();
        }
    }

    // Method to check if all words are hidden
    public bool AllWordsHidden()
    {
        return Words.All(w => w.IsWordHidden());
    }
}
