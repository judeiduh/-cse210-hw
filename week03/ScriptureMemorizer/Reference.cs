using System;

public class Reference
{
    public string ScriptureReference { get; set; }

    // Constructor for a single verse or verse range (e.g., "John 3:16" or "Proverbs 3:5-6")
    public Reference(string reference)
    {
        ScriptureReference = reference;
    }

    // Method to display the reference
    public void DisplayReference()
    {
        Console.WriteLine(ScriptureReference);
    }
}
