using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baralho : MonoBehaviour
{
    private List<CartaSorte> cartas;

    public Baralho()
    {
        cartas = new List<CartaSorte>(30);
    }
    public void addCartaSorte()
    {
        for (int i = 0; i < cartas.Count; i++)
        {
            if(i % 2 == 0) 
                cartas[i] = new CartaTransporte();
            else
                cartas[i] = new CartaCofre();
        }
    }
    public void addCartaCofre()
    {
        for (int i = 0; i < cartas.Count; i++)
        {
            cartas[i] = new CartaCofre();
        }
    }
    public void embaralharCartas()
    {
        // Algoritmo Fisher-Yates
        System.Random rng = new System.Random();
        int n = cartas.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            CartaSorte carta = cartas[k];
            cartas[k] = cartas[n];
            cartas[n] = carta;
        }
    }

    public CartaSorte sortearCarta()
    {
        CartaSorte cartaSorteada = cartas[0];
        cartas.Remove(cartaSorteada);
        return cartaSorteada;
    }
}
