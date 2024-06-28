using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrategiaConservadora : EstrategiaCompra
{
    public void comprarPropriedade(JogadorIa jogadorIa, Propriedades propriedade)
    {
        if ((jogadorIa.getSaldo() - propriedade.getCustoCompra()) / jogadorIa.getSaldo() >= 0.60){
            propriedade.gerenciaPropriedade(jogadorIa);
        }
    }
    public void comprarCasa(Propriedades propriedade)
    {
        Terreno terreno = (Terreno)propriedade;
        terreno.comprarCasa();
    }
}
