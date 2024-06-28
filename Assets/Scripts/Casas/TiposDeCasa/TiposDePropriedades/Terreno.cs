using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terreno : Propriedades
{
    private int custoCompraCasa;
    private int aluguel1casa;
    private int aluguel2casa;
    private int aluguel3casa;
    private int aluguel4casa;
    private int aluguelHotel;
    private int numeroCasas;
    private int cor;

    public void comprarCasa()
    {
        if (numeroCasas < 5) { 
            Jogador proprietario = getProprietario();
            proprietario.debita(this.custoCompraCasa);
            this.numeroCasas += 1;
        }
    }
    public void venderCasa()
    {
        if (numeroCasas > 0)
        {
            Jogador proprietario = getProprietario();
            proprietario.credita(this.custoCompraCasa);
            this.numeroCasas -= 1;
        }
    }
    public int getAluguel()
    {
        if (this.numeroCasas == 0) return this.aluguel;
        if (this.numeroCasas == 1) return this.aluguel1casa;
        if (this.numeroCasas == 2) return this.aluguel2casa;
        if (this.numeroCasas == 3) return this.aluguel3casa;
        if (this.numeroCasas == 4) return this.aluguel4casa;
        else return this.aluguelHotel;
    }
    public int getCor()
    {
        return this.cor;
    }
}
