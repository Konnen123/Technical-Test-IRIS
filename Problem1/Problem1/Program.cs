namespace Problem1;
class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        
        Console.WriteLine(program.checkBalancedBrackets("[()]{}{[()()]()}"));
        Console.WriteLine(program.checkBalancedBrackets("[(]))"));
    }
    // Approach: Using a stack
    // When an open bracket is found, add it to the stack.
    // If the bracket is closed, check first if the stack is empty.
    // If it is empty, it means the expression is not balanced, because an expression can't have a closed bracket before an open one
    // Then check if the top of the stack corresponds with the closed bracket (check if we have either of these pairs: ( ), [ ], { })
    // At the end, check if we have elements remaining in the stack. If we have, it means the expression is not valid
    // Otherwise, the expression is valid.
    // Time complexity: O(n), where n is the length of the expression
    // Space complexity: O(n), use a stack to store the open brackets
    private string checkBalancedBrackets(string expression)
    {
        // Use a stack to store the open brackets
        Stack<char> openBrackets = new Stack<char>();
        const string successMessage = "Balanced";
        const string errorMessage = "Not Balanced";
        
        foreach(var bracket in expression)
        {
            // If the bracket is open, add it to the stack
            if (isOpenBracket(bracket))
            {
                openBrackets.Push(bracket);
                continue;
            }
            
            // If the stack is empty, it means the expression is not valid 
            if (!openBrackets.Any())
                return errorMessage;

            // Check if the closing bracket (bracket) corresponds with the top element from the stack (ex: ( ), [ ], { })
            if (!areBracketsSameType(openBrackets.Peek(), bracket))
                return errorMessage;

            // The brackets correspond, so remove the open bracket from the stack
            openBrackets.Pop();
        }

        // If there are any open brackets left, it means the expression is not valid
        return openBrackets.Any() ? errorMessage : successMessage;
    }

    private bool isOpenBracket(char bracket)
    {
        if (bracket == '(' || bracket == '[' || bracket == '{')
            return true;

        return false;
    }

    private bool areBracketsSameType(char openBracket, char closedBracket)
    {
        if (openBracket == '(' && closedBracket == ')')
            return true;
        if (openBracket == '[' && closedBracket == ']')
            return true;
        if (openBracket == '{' && closedBracket == '}')
            return true;

        return false;
    }
}
