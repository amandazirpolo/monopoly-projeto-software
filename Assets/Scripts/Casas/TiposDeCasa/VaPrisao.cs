using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaPrisao : Casa
{
    public override void executaEfeitoCasa(Jogador jogador)
    {
        jogador.setPreso(true);
        jogador.setPosicao(10);
    }
}
