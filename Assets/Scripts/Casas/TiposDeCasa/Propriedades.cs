using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propriedades : Casa
{
    protected int custoCompra;
    protected int aluguel;
    protected int hipoteca;
    protected Jogador proprietario;
    public override void executaEfeitoCasa(Jogador jogador)
    {
        Jogador proprietario = this.getProprietario();
        if (proprietario == null)
            jogador.comprarPropriedade(this);
        else if (proprietario != jogador)
        {
            proprietario.receberAluguel(this.aluguel);
            jogador.pagarAluguel(this.aluguel);
        }
    }
    public void gerenciaPropriedade(Jogador jogadorDaVez)
    {
        int custo = getCustoCompra();
        jogadorDaVez.debita(custo);
        jogadorDaVez.addPropriedades(this);
        setProprietario(jogadorDaVez);
    }
    public int getAluguel()
    {
        return this.aluguel;
    }
    public int getCustoCompra()
    {
        return this.custoCompra;
    }
    public Jogador getProprietario()
    {
        return proprietario;
    }
    public void setProprietario(Jogador jogador)
    {
        this.proprietario = jogador;
    }
}
