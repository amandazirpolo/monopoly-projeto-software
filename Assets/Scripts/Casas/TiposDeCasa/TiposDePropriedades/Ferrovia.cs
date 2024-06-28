using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferrovia : Propriedades
{
    public override void executaEfeitoCasa(Jogador jogador)
    {
        Jogador proprietario = this.getProprietario();
        if (proprietario == null)
            jogador.comprarPropriedade(this);
        else
        {
            List<Propriedades> listaPropriedades = proprietario.getPropriedades();
            int i = -1;
            foreach (Propriedades propriedade in listaPropriedades)
            {
                if (propriedade is Ferrovia) 
                    i += 1;
            }
            proprietario.receberAluguel(this.getAluguel() * (2 ^ i));
            jogador.pagarAluguel(this.getAluguel() * (2 ^ i));
        }
    }
}
