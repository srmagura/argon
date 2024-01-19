using System.Text.RegularExpressions;

namespace Compiler;

public static class Lexer
{
    private static Token? LexString(string input, int i)
    {
        var j = i;

        if (input[j] != '"')
        {
            return null;
        }

        j++;

        for (; j < input.Length; j++)
        {
            if (input[j] == '"')
            {
                return new Token(TokenType.String, input.Substring(i, j - i + 1));
            }
        }

        // We got to the end without finding a closing quote
        return null;
    }

    private static readonly Regex identifierRegex = new(@"[a-zA-Z_]");

    private static Token? LexIdentifier(string input, int i)
    {
        var j = i;

        if (!identifierRegex.IsMatch(input[j].ToString()))
        {
            return null;
        }

        j++;

        for (; j < input.Length; j++)
        {
            if (!identifierRegex.IsMatch(input[j].ToString()) && !char.IsDigit(input[j]))
            {
                break;
            }
        }

        return new Token(TokenType.Identifier, input[i..j]);
    }

    public static List<Token>? Lex(string input)
    {
        var tokens = new List<Token>();
        var i = 0;

        bool check(Token? token)
        {
            if (token == null) { return false; }

            tokens.Add(token);
            i += token.Value.Length;
            return true;
        }

        while (i < input.Length)
        {
            var nextChar = input[i];

            // Spaces and tabs are not considered tokens
            if (nextChar == ' ' || nextChar == '\t')
            {
                i++;
                continue;
            }

            if (check(LexString(input, i)))
            {
                continue;
            }

            if (check(LexIdentifier(input, i)))
            {
                continue;
            }

            return null;
        }

        return tokens;
    }
}
