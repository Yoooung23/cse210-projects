public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person you interacted with today?",
        "What was the best part of your day?",
        "How did you see yourself grow today?",
        "What was the strongest emotion you felt today?",
        "If you had one thing you could do over today, what would it be?",
        "What are you grateful for today?",
        "What is something you learned today?",
        "What is a goal you have for tomorrow?",
        "Write about a challenge you faced today and how you handled it.",
        "What made you smile today?",
        "Describe something beautiful you saw or experienced today.",
        "What inspired you today?",
        "What is one thing you wish you had done differently today?",
        "Who did you help today and how?",
        "What are you looking forward to tomorrow?"
    };

    public PromptGenerator()
    {
        
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        var index = random.Next(_prompts.Count);
        var randomItem = _prompts[index];
        return randomItem;
    }
}