using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaCofre : CartaSorte
{
    private int tipo;
    public CartaCofre()
    {
        this.valor = Random.Range(200, 1000);
        this.tipo = Random.Range(0, 1);
        if (this.tipo == 0)
        {
            this.descricao = $"O jogador vai ser debitado em {this.valor}";
        }
        else
        {
            this.descricao = $"O jogador vai ser creditado em {this.valor}";
        }

    }
    public override void aplicarEfeito(Jogador jogador)
    {
        if (this.tipo == 0)
            jogador.debita(this.valor);
        else
            jogador.credita(this.valor);
    }
}
