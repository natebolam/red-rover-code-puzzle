using System.Text;

class TreeNode(string data)
{
    public string Data { get; set; } = data;
    public List<TreeNode> Children { get; } = [];
}

class Tree(string data)
{
    public TreeNode Root { get; set; } = new TreeNode(data);

    public string ToString( bool sort)
    {
        return PrintTree(Root, 0, sort);
    }

    public static Tree FromString(string data)
    {
        var rootNode = new TreeNode("root");
        var stack = new Stack<TreeNode>();
        stack.Push(rootNode);

        string currentToken = "";
        foreach (char c in data)
        {
            if (c == '(')
            {
                if (!string.IsNullOrEmpty(currentToken))
                {
                    var newNode = new TreeNode(currentToken.Trim());
                    stack.Peek().Children.Add(newNode);
                    stack.Push(newNode);
                    currentToken = "";
                }
            }
            else if (c == ')')
            {
                if (!string.IsNullOrEmpty(currentToken))
                {
                    var newNode = new TreeNode(currentToken.Trim());
                    stack.Peek().Children.Add(newNode);
                    currentToken = "";
                }
                stack.Pop();
            }
            else if (c == ',')
            {
                if (!string.IsNullOrEmpty(currentToken))
                {
                    var newNode = new TreeNode(currentToken.Trim());
                    stack.Peek().Children.Add(newNode);
                    currentToken = "";
                }
            }
            else
            {
                currentToken += c;
            }
        }

        return new Tree("root") { Root = rootNode};
    }

    private static string PrintTree(TreeNode node, int indent, bool sort, bool first = true)
    {
        var sb = new StringBuilder();

        // Skip printing the root node itself (only print its children)
        if (!first)
        {
            sb.AppendLine(new string(' ', indent * 2) + "- " + node.Data);
        }

        // Conditionally sort children alphabetically by Data
        var children = sort ? [.. node.Children.OrderBy(child => child.Data)] : node.Children;
        
        foreach (var child in children)
        {
            sb.Append(PrintTree(child, indent + 1, sort, false));
        }

        return sb.ToString();
    }
}