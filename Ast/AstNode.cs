namespace Ast;

public abstract class AstNode
{
}

public class ExpressionAstNode : AstNode
{
}

public class PropertyAccessAstNode : AstNode
{
    public required ExpressionAstNode Object { get; set; }
    public required 
}

public class FunctionCallAstNode : AstNode
{
    public required ExpressionAstNode Function { get; set; }
    public required List<ExpressionAstNode> Arguments { get; set; }
}

