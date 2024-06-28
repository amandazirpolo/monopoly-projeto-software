using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanhiaServico : Propriedades
{
    public override void executaEfeitoCasa(Jogador jogador)
    {
        Jogador proprietario = this.getProprietario();
        if (proprietario == null)
            jogador.comprarPropriedade(this);
        else
        {
            int random = Random.Range(2, 8);
            proprietario.receberAluguel(this.getAluguel() * random);
            jogador.pagarAluguel(this.getAluguel() * random);
        }
    }
}
