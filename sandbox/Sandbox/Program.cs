using System;
using System.Collections.Generic;

namespace Sandbox
{
    class JournalEntry
    {
        public DateTime Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public JournalEntry(string prompt, string response)
        {
            Date = DateTime.Now;
            Prompt = prompt;
            Response = response;
        }

        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()}, Prompt: {Prompt}, Response: {Response}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<JournalEntry> journalEntries = new List<JournalEntry>();

            // Adding sample entries
            journalEntries.Add(new JournalEntry("What made you happy today?", "I enjoyed a walk in the park."));
            journalEntries.Add(new JournalEntry("What did you learn today?", "I learned how to use classes in C#."));

            // Display all entries
            Console.WriteLine("Journal Entries:");
            foreach (var entry in journalEntries)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
