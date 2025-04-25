using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Parser
{
    private static List<Token> tokens;
    private static int pos;

    public static bool Validar(List<Token> entrada)
    {
        tokens = entrada;
        pos = 0;

        bool valido = ParseFormula();

        return valido && TokenAtual().Tipo == TokenType.EOF;
    }


    private static Token TokenAtual()
    {
        return pos < tokens.Count ? tokens[pos] : new Token(TokenType.EOF, "");
    }

    private static Token Consumir(TokenType esperado)
    {
        if (TokenAtual().Tipo == esperado)
            return tokens[pos++];
        return null;
    }

    private static bool ParseFormula()
    {
        Token token = TokenAtual();

        switch (token.Tipo)
        {
            case TokenType.True:
            case TokenType.False:
                Consumir(token.Tipo);
                return true;

            case TokenType.Proposicao:
                Consumir(TokenType.Proposicao);
                return true;

            case TokenType.AbrePar:
                if (LookAhead(1)?.Tipo == TokenType.Neg)
                    return ParseFormulaUnaria();
                else
                    return ParseFormulaBinaria();

            default:
                return false;
        }
    }

    private static bool ParseFormulaUnaria()
    {
        if ((Consumir(TokenType.AbrePar) == null) || (Consumir(TokenType.Neg) == null))
            return false;

        if (!ParseFormula())
            return false;

        return Consumir(TokenType.FechaPar) != null;
    }

    private static bool ParseFormulaBinaria()
    {
        if (Consumir(TokenType.AbrePar) == null)
            return false;

        if (!ParseOperadorBinario())
            return false;

        if (!ParseFormula())
            return false;

        if (!ParseFormula())
            return false;

        return Consumir(TokenType.FechaPar) != null;
    }

    private static bool ParseOperadorBinario()
    {
        TokenType tipo = TokenAtual().Tipo;

        if (tipo == TokenType.Wedge || tipo == TokenType.Vee ||
            tipo == TokenType.Implies || tipo == TokenType.Iff)
        {
            Consumir(tipo);
            return true;
        }

        return false;
    }

    private static Token LookAhead(int offset)
    {
        return (pos + offset < tokens.Count) ? tokens[pos + offset] : null;
    }
}

