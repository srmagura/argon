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
    }
}