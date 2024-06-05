using UnityEngine;

public class Dados : MonoBehaviour
{
    private int dado1;
    private int dado2;
    private int contaDuplos = 0;

    public int lancarDados()
    {
        dado1 = Random.Range(1, 7); // Rola o primeiro dado (1 a 6)
        dado2 = Random.Range(1, 7); // Rola o segundo dado (1 a 6)
        return (dado1 + dado2);
    }
    public bool checarDados()
    {
        if (dado1 == dado2)
        {
            incrementaContador();
            return true;
        }
        return false;
    }
    private void incrementaContador()
    {
        contaDuplos++;
    }

    public int getContador()
    {
        return this.contaDuplos;
    }
}
