using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaTransporte : CartaSorte
{
    public CartaTransporte() { 
        this.valor = Random.Range(0, 39);
        this.descricao = $"O jogador vai teleportar para a casa {this.valor}";
    }
    public override void aplicarEfeito(Jogador jogador)
    {
        jogador.setPosicao(this.valor);
    }
}
