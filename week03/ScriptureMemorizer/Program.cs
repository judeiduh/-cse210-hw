

class Program
{
    static void Main(string[] args)
    {
        // Example scripture
        string reference = "John 3:16";
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

        // Create a Scripture object
        Scripture scripture = new Scripture(reference, text);

        // Start displaying the scripture and hiding words until all are hidden
        while (true)
        {
            Console.Clear();
            scripture.DisplayScripture();

            // Ask user for input
            Console.WriteLine("Press Enter to hide a word, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            // Hide a random word if the user presses Enter
            scripture.HideRandomWord();

            // If all words are hidden, end the program
            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                scripture.DisplayScripture();
                Console.WriteLine("All words are hidden! Well done!");
                break;
            }
        }
    }
}
