using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Jogador : MonoBehaviour
{
    private string nome;
    private int saldo;
    private int posicao;
    private List<Propriedades> propriedades;

    private bool preso;
    private int turnosPreso;

    public void receberAluguel(int aluguel) 
    {
        this.saldo += aluguel;
    }
    public void pagarAluguel(int aluguel) 
    {
        this.saldo -= aluguel;
    }
    public abstract void comprarPropriedade(Propriedades propriedade);
    public void debitaPropriedade(int precoCompra) 
    {
        this.saldo -= precoCompra;
    }
    public abstract void comprarCasa();
    public bool checarPreso()
    {
        if (this.preso)
            return true;
        return false;
    }
    public abstract void desistir();

    public void setNome(string name)
    {
        this.nome = name;
    }
    public void setPosicao(int pos)
    {
        this.posicao = pos;
        if (this.posicao >= 40)
        {
            this.posicao -= 40;
        }
    }
    public int getPosicao()
    {
        return this.posicao;
    }
    public void setPreso(bool status)
    {
        this.preso = status;
    }
    public bool getPreso()
    {
        return this.preso;
    }
    public void setTurnosPreso(int turnos)
    {
        this.turnosPreso = turnos;
    }
    public int getTurnosPreso()
    {
        return this.turnosPreso;
    }
}
