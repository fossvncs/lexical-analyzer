using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Lexer
{
    public static List<Token> Analisar(string entrada)
    {
        List<Token> tokens = new List<Token>();
        int i = 0;

        while (i < entrada.Length)
        {
            char atual = entrada[i];

            if (char.IsWhiteSpace(atual))
            {
                i++;
                continue;
            }

            if (atual == '(')
            {
                tokens.Add(new Token(TokenType.AbrePar, "("));
                i++;
            }
            else if (atual == ')')
            {
                tokens.Add(new Token(TokenType.FechaPar, ")"));
                i++;
            }
            else if (char.IsDigit(atual))
            {
                int start = i++;
                while (i < entrada.Length && (char.IsLetterOrDigit(entrada[i])))
                    i++;

                string prop = entrada.Substring(start, i - start);
                tokens.Add(new Token(TokenType.Proposicao, prop));
            }
            else if (atual == '\\')
            {
                int start = i++;
                while (i < entrada.Length && char.IsLetter(entrada[i]))
                    i++;

                string comando = entrada.Substring(start, i - start);

                switch (comando)
                {
                    case "\\neg": tokens.Add(new Token(TokenType.Neg, comando)); break;
                    case "\\wedge": tokens.Add(new Token(TokenType.Wedge, comando)); break;
                    case "\\vee": tokens.Add(new Token(TokenType.Vee, comando)); break;
                    case "\\rightarrow": tokens.Add(new Token(TokenType.Implies, comando)); break;
                    case "\\leftrightarrow": tokens.Add(new Token(TokenType.Iff, comando)); break;
                    default:
                        tokens.Add(new Token(TokenType.Erro, comando));
                        break;
                }
            }
            else if (entrada.Substring(i).StartsWith("true"))
            {
                tokens.Add(new Token(TokenType.True, "true"));
                i += 4;
            }
            else if (entrada.Substring(i).StartsWith("false"))
            {
                tokens.Add(new Token(TokenType.False, "false"));
                i += 5;
            }
            else
            {
                tokens.Add(new Token(TokenType.Erro, atual.ToString()));
                i++;
            }
        }

        tokens.Add(new Token(TokenType.EOF, ""));
        return tokens;
    }
}
