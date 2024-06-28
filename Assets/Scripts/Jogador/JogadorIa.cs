using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorIa : Jogador
{
    private EstrategiaCompra estrategiaCompra;

    public JogadorIa()
    {
        this.posicaoAntiga = 0;
        this.posicao = 0;
        this.preso = false;
        this.turnosPreso = 0;
        int random = Random.Range(0, 2);
        if (random == 0) estrategiaCompra = new EstrategiaAgressiva();
        else estrategiaCompra = new EstrategiaConservadora();
    }
    public override void comprarCasa(Propriedades propriedade)
    {
        // 3 cores: vermelho = 1, amarelo = 2, laranja = 3, azulClaro = 4, rosa = 5, verde = 6;
        // 2 cores: marrom = 7, azulEscuro = 8;
        Terreno terreno = (Terreno)propriedade;
        int corMax;
        if (terreno.getCor() < 7) corMax = 3;
        else corMax = 2;

        int cont = 0;
        foreach (Propriedades prop in this.propriedades)
        {
            if (prop is Terreno)
            {
                terreno = (Terreno)prop;
                if (terreno.getCor() == ((Terreno)propriedade).getCor())
                {
                    cont += 1;
                }
            }
        }
        if (cont == corMax)
        {
            if ((estrategiaCompra is EstrategiaConservadora) && ((getSaldo() - propriedade.getCustoCompra()) / getSaldo() >= 0.35))
                estrategiaCompra.comprarCasa(propriedade);
            else if ((estrategiaCompra is EstrategiaAgressiva) && (getSaldo() > propriedade.getCustoCompra()))
                estrategiaCompra.comprarCasa(propriedade);
        }
    }

    public override void comprarPropriedade(Propriedades propriedade)
    {
        if (estrategiaCompra is EstrategiaConservadora)
            estrategiaCompra.comprarPropriedade(this, propriedade);
        else if (estrategiaCompra is EstrategiaAgressiva)
            estrategiaCompra.comprarPropriedade(this, propriedade);
    }

    public void setEstrategiaCompra(EstrategiaCompra estrategia)
    {
        this.estrategiaCompra = estrategia;
    }
}
