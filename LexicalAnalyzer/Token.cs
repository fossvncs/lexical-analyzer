using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum TokenType
{
    True,
    False,
    Proposicao,
    Neg,
    Wedge,
    Vee,
    Implies,
    Iff,
    AbrePar,
    FechaPar,
    EOF,
    Erro
}

public class Token
{
    public TokenType Tipo { get; }
    public string Valor { get; }

    public Token(TokenType tipo, string valor)
    {
        Tipo = tipo;
        Valor = valor;
    }

    public override string ToString() => $"{Tipo}: '{Valor}'";
}
