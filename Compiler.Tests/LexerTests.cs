namespace Compiler.Tests;

[TestClass]
public class LexerTests
{
    [TestMethod]
    public void LexString()
    {
        var actual = Lexer.Lex(" \"foo\" ");
        var expected = new List<Token> {
            new(TokenType.String, "\"foo\"")
        };

        CollectionAssert.AreEqual(expected, actual);

        actual = Lexer.Lex(" 'foo' ");
        expected = new List<Token> {
            new(TokenType.String, "'foo'")
        };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void LexIdentifier()
    {
        var actual = Lexer.Lex("print");
        var expected = new List<Token> {
            new(TokenType.Identifier, "print")
        };

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void LexHelloWorld()
    {
        var actual = Lexer.Lex("console.log(\"Hello world\")");
        var expected = new List<Token> {
            new(TokenType.Identifier, "console"),
            new(TokenType.Dot, "."),
            new(TokenType.Identifier, "log"),
            new(TokenType.OpenParen, "("),
            new(TokenType.String, "\"Hello world\""),
            new(TokenType.CloseParen, ")"),
        };

        CollectionAssert.AreEqual(expected, actual);
    }
}