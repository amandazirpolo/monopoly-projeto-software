using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imposto : Casa
{
    public override void executaEfeitoCasa(Jogador jogador)
    {
        jogador.debita(150);
    }
}
