using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : Casa
{
    private Tabuleiro tabuleiro;
    void Start()
    {
        tabuleiro = GetComponent<Tabuleiro>();
    }
    public override void executaEfeitoCasa(Jogador jogador)
    {
        CartaSorte carta = tabuleiro.getBaralhoCofre().sortearCarta();
        carta.aplicarEfeito(jogador);
    }
}
