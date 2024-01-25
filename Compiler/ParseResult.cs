using Ast;

namespace Compiler;

internal class ParseResult
{
    public required AstNode Node { get; set; }
    public required int TokensConsumed { get; set; }
}
