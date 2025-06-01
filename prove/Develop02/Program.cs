/* Scripture Memorizer Program
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

class ScriptureMemorizer
{
    // Represents a single word in the scripture
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public bool IsHidden => _isHidden;

        public void Hide()
        {
            _isHidden = true;
        }

        public void Show()
        {
            _isHidden = false;
        }

        public string GetDisplayText()
        {
            if (_isHidden)
            {
                return new string('_', _text.Length);
            }
            return _text;
        }

        public string GetOriginalText()
        {
            return _text;
        }
    }

    // Represents a scripture reference (e.g., "John 3:16" or "Proverbs 3:5-6")
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private int _endVerse;

        // Constructor for single verse
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = verse;
        }

        // Constructor for verse range
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _verse = startVerse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            if (_verse == _endVerse)
            {
                return $"{_book} {_chapter}:{_verse}";
            }
            else
            {
                return $"{_book} {_chapter}:{_verse}-{_endVerse}";
            }
        }
    }

    // Represents a complete scripture with reference and text
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private string _category;

        public Scripture(Reference reference, string text, string category = "General")
        {
            _reference = reference;
            _category = category;
            _words = new List<Word>();
            
            string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in wordArray)
            {
                _words.Add(new Word(word));
            }
        }

        public string Category => _category;

        public bool IsCompletelyHidden()
        {
            return _words.All(word => word.IsHidden);
        }

        public void HideRandomWords(int count = 1)
        {
            Random random = new Random();
            List<Word> visibleWords = _words.Where(word => !word.IsHidden).ToList();
            
            int wordsToHide = Math.Min(count, visibleWords.Count);
            
            for (int i = 0; i < wordsToHide; i++)
            {
                if (visibleWords.Count > 0)
                {
                    int randomIndex = random.Next(visibleWords.Count);
                    visibleWords[randomIndex].Hide();
                    visibleWords.RemoveAt(randomIndex);
                }
            }
        }

        public void ShowAllWords()
        {
            foreach (Word word in _words)
            {
                word.Show();
            }
        }

        public string GetDisplayText()
        {
            string wordsText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
            return $"{_reference.GetDisplayText()} - {wordsText}";
        }

        public int GetTotalWordCount()
        {
            return _words.Count;
        }

        public int GetHiddenWordCount()
        {
            return _words.Count(word => word.IsHidden);
        }

        public int GetVisibleWordCount()
        {
            return _words.Count(word => !word.IsHidden);
        }

        public double GetCompletionPercentage()
        {
            return (double)GetHiddenWordCount() / GetTotalWordCount() * 100;
        }
    }

    // Scripture library to manage multiple scriptures
    public class ScriptureLibrary
    {
        private List<Scripture> _scriptures;

        public ScriptureLibrary()
        {
            _scriptures = new List<Scripture>();
            InitializeScriptures();
        }

        private void InitializeScriptures()
        {
            _scriptures.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.",
                "Love"));

            _scriptures.Add(new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.",
                "Faith"));

            _scriptures.Add(new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me.",
                "Strength"));

            _scriptures.Add(new Scripture(
                new Reference("Romans", 8, 28),
                "And we know that all things work together for good to them that love God, to them who are the called according to his purpose.",
                "Faith"));

            _scriptures.Add(new Scripture(
                new Reference("Joshua", 1, 9),
                "Have not I commanded thee? Be strong and of a good courage; be not afraid, neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest.",
                "Courage"));

            _scriptures.Add(new Scripture(
                new Reference("Psalm", 23, 1, 2),
                "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters.",
                "Comfort"));

            _scriptures.Add(new Scripture(
                new Reference("Matthew", 5, 16),
                "Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven.",
                "Service"));

            _scriptures.Add(new Scripture(
                new Reference("1 Corinthians", 13, 4, 5),
                "Charity suffereth long, and is kind; charity envieth not; charity vaunteth not itself, is not puffed up, Doth not behave itself unseemly, seeketh not her own, is not easily provoked, thinketh no evil;",
                "Love"));

            _scriptures.Add(new Scripture(
                new Reference("James", 1, 5),
                "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him.",
                "Wisdom"));

            _scriptures.Add(new Scripture(
                new Reference("2 Timothy", 1, 7),
                "For God hath not given us the spirit of fear; but of power, and of love, and of a sound mind.",
                "Courage"));
        }

        public Scripture GetRandomScripture()
        {
            Random random = new Random();
            return _scriptures[random.Next(_scriptures.Count)];
        }

        public List<Scripture> GetAllScriptures()
        {
            return new List<Scripture>(_scriptures);
        }

        public List<string> GetCategories()
        {
            return _scriptures.Select(s => s.Category).Distinct().OrderBy(c => c).ToList();
        }

        public List<Scripture> GetScripturesByCategory(string category)
        {
            return _scriptures.Where(s => s.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }

    // Main program class
    class Program
    {
        private static ScriptureLibrary library = new ScriptureLibrary();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Scripture Memorizer!");
            Console.WriteLine("This program will help you memorize scriptures by gradually hiding words.");
            Console.WriteLine();

            while (true)
            {
                Scripture selectedScripture = SelectScripture();
                if (selectedScripture == null) break;

                int difficulty = SelectDifficulty();
                RunMemorizationSession(selectedScripture, difficulty);

                if (!AskToPlayAgain()) break;
            }

            Console.WriteLine("Thank you for using Scripture Memorizer! Keep studying!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static Scripture SelectScripture()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SCRIPTURE SELECTION ===");
                Console.WriteLine("1. Random Scripture");
                Console.WriteLine("2. Choose by Category");
                Console.WriteLine("3. Browse All Scriptures");
                Console.WriteLine("4. Exit Program");
                Console.WriteLine();
                Console.Write("Please select an option (1-4): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        return library.GetRandomScripture();
                    case "2":
                        return SelectByCategory();
                    case "3":
                        return BrowseAllScriptures();
                    case "4":
                        return null;
                    default:
                        Console.WriteLine("Invalid selection. Please choose 1-4.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static Scripture SelectByCategory()
        {
            List<string> categories = library.GetCategories();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SELECT BY CATEGORY ===");
                for (int i = 0; i < categories.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {categories[i]}");
                }
                Console.WriteLine($"{categories.Count + 1}. Back to Main Menu");
                Console.WriteLine();
                Console.Write($"Please select a category (1-{categories.Count + 1}): ");

                string choice = Console.ReadLine();
                if (int.TryParse(choice, out int categoryIndex) && 
                    categoryIndex >= 1 && categoryIndex <= categories.Count + 1)
                {
                    if (categoryIndex == categories.Count + 1)
                        return SelectScripture();

                    string selectedCategory = categories[categoryIndex - 1];
                    List<Scripture> categoryScriptures = library.GetScripturesByCategory(selectedCategory);
                    
                    return SelectFromList(categoryScriptures, $"=== {selectedCategory.ToUpper()} SCRIPTURES ===");
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static Scripture BrowseAllScriptures()
        {
            List<Scripture> allScriptures = library.GetAllScriptures();
            return SelectFromList(allScriptures, "=== ALL SCRIPTURES ===");
        }

        static Scripture SelectFromList(List<Scripture> scriptures, string title)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(title);
                for (int i = 0; i < scriptures.Count; i++)
                {
                    Scripture scripture = scriptures[i];
                    Console.WriteLine($"{i + 1}. {scripture.GetDisplayText().Substring(0, Math.Min(80, scripture.GetDisplayText().Length))}...");
                }
                Console.WriteLine($"{scriptures.Count + 1}. Back");
                Console.WriteLine();
                Console.Write($"Please select a scripture (1-{scriptures.Count + 1}): ");

                string choice = Console.ReadLine();
                if (int.TryParse(choice, out int scriptureIndex) && 
                    scriptureIndex >= 1 && scriptureIndex <= scriptures.Count + 1)
                {
                    if (scriptureIndex == scriptures.Count + 1)
                        return SelectScripture();

                    return scriptures[scriptureIndex - 1];
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static int SelectDifficulty()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SELECT DIFFICULTY ===");
                Console.WriteLine("1. Easy (Hide 1 word at a time)");
                Console.WriteLine("2. Medium (Hide 2-3 words at a time)");
                Console.WriteLine("3. Hard (Hide 3-5 words at a time)");
                Console.WriteLine();
                Console.Write("Please select difficulty (1-3): ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": return 1;
                    case "2": return new Random().Next(2, 4);
                    case "3": return new Random().Next(3, 6);
                    default:
                        Console.WriteLine("Invalid selection. Please choose 1-3.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void RunMemorizationSession(Scripture scripture, int wordsPerTurn)
        {
            scripture.ShowAllWords(); // Reset scripture to show all words

            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("=== SCRIPTURE MEMORIZATION ===");
                Console.WriteLine();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                
                // Show progress
                double completionPercentage = scripture.GetCompletionPercentage();
                int visibleWords = scripture.GetVisibleWordCount();
                Console.WriteLine($"Progress: {completionPercentage:F1}% complete ({visibleWords} words remaining)");
                
                // Show progress bar
                int progressBarLength = 30;
                int filledLength = (int)(completionPercentage / 100 * progressBarLength);
                string progressBar = "[" + new string('█', filledLength) + new string('░', progressBarLength - filledLength) + "]";
                Console.WriteLine($"Progress: {progressBar}");
                Console.WriteLine();

                // Show encouragement based on progress
                if (completionPercentage >= 75)
                    Console.WriteLine("Excellent! You're almost there!");
                else if (completionPercentage >= 50)
                    Console.WriteLine("Great progress! Keep going!");
                else if (completionPercentage >= 25)
                    Console.WriteLine("You're doing well! Stay focused!");
                else
                    Console.WriteLine("Just getting started! You can do it!");

                Console.WriteLine();
                Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit, 'restart' to start over:");
                
                string input = Console.ReadLine().ToLower().Trim();
                
                if (input == "quit")
                {
                    return;
                }
                else if (input == "restart")
                {
                    scripture.ShowAllWords();
                    continue;
                }
                
                // Hide random words
                scripture.HideRandomWords(wordsPerTurn);
            }

            // All words are hidden - show completion message
            Console.Clear();
            Console.WriteLine("=== CONGRATULATIONS! ===");
            Console.WriteLine();
            Console.WriteLine("You have successfully hidden all words in the scripture!");
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("🎉 Well done! You're on your way to memorizing this scripture! 🎉");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static bool AskToPlayAgain()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Would you like to practice another scripture? (y/n): ");
                string response = Console.ReadLine().ToLower().Trim();
                
                if (response == "y" || response == "yes")
                    return true;
                else if (response == "n" || response == "no")
                    return false;
                else
                {
                    Console.WriteLine("Please enter 'y' for yes or 'n' for no.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}