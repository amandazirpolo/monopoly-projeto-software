using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaSairPrisao : CartaSorte
{
    public CartaSairPrisao()
    {
        this.descricao = "O jogador pode fugir na proxima vez que for preso";
    }
    public override void aplicarEfeito(Jogador jogador)
    {
        jogador.setPreso(false);
    }
}
