using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Jogador : MonoBehaviour
{
    [SerializeField] protected string nome;
    [SerializeField] protected int saldo;
    protected int posicao;
    protected int posicaoAntiga;
    protected List<Propriedades> propriedades;

    protected bool preso;
    protected int turnosPreso;

    public void receberAluguel(int aluguel) 
    {
        this.saldo += aluguel;
    }
    public void pagarAluguel(int aluguel) 
    {
        this.saldo -= aluguel;
    }
    public abstract void comprarPropriedade(Propriedades propriedade);
    public void credita(int valor)
    {
        this.saldo += valor;
    }
    public void debita(int valor) 
    {
        this.saldo -= valor;
    }
    public abstract void comprarCasa(Propriedades propriedade);
    public bool checarPreso()
    {
        if (this.preso)
            return true;
        return false;
    }
    public void setNome(string name)
    {
        this.nome = name;
    }
    public string getName()
    {
        return this.nome;
    }
    public void setSaldo(int saldo)
    {
        this.saldo = saldo;
    }
    public int getSaldo()
    {
        return this.saldo;
    }
    public void setPosicao(int pos)
    {
        this.posicaoAntiga = this.posicao;
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
    public int getPosicaoAntiga()
    {
        return this.posicaoAntiga;
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
    public void addPropriedades(Propriedades propriedade)
    {
        propriedades.Add(propriedade);
    }
    public List<Propriedades> getPropriedades()
    {
        return this.propriedades;
    }
}
