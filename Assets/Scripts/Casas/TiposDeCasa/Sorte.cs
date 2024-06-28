using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorte : Casa
{
    private Tabuleiro tabuleiro;
    void Start()
    {
        tabuleiro = GetComponent<Tabuleiro>();
    }
    public override void executaEfeitoCasa(Jogador jogador)
    {
        CartaSorte carta = tabuleiro.getBaralhoSorte().sortearCarta();
        carta.aplicarEfeito(jogador);
    }
}
