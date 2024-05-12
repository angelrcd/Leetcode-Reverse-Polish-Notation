namespace ReversePolish;

public class Solution
{
    private string[] tokens;
    public Stack<int> stack = new Stack<int>();
    
    
    public int EvalRPN(string[] tokens)
    {
        this.tokens = tokens;
        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int result))
            {
                stack.Push(result);
                continue;
            }

            var x = stack.Pop();
            var y = stack.Pop();
            var z = Operate(token, x, y);
            stack.Push(z);
        }

        return stack.Pop();
    }

    private int Operate(string operation, int x, int y)
    {
        switch (operation)
        {
            case "+":
                return y + x;
            case "-":
                return y - x;
            case "*":
                return y * x;
            case "/":
                return y / x;
            default:
                throw new Exception();
        }
    }
}