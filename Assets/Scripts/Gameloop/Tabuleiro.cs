using System.Collections.Generic;
using UnityEngine;

public class Tabuleiro : MonoBehaviour
{
    [SerializeField] private List<GameObject> casasTabuleiro;
    [SerializeField] private List<GameObject> pecas;

    private List<Casa> casas;
    private Baralho baralhoSorte;
    private Baralho baralhoCofre;

    public Tabuleiro()
    {
        iniciarTabuleiro();
    }
   
    private void iniciarTabuleiro()
    {
        casas = new List<Casa>(40);
        for (int i = 0; i < casas.Count; i++)
        {
            if (i == 0)
                continue;
            if (i == 36 || i == 4)
                casas[i] = new Imposto();
            else if (i==10)
                casas[i] = new Prisao();
            else if (i==30)
                casas[i] = new VaPrisao();
            else if (i == 5 || i == 15 || i == 25 || i == 35)
                casas[i] = new Ferrovia();
            else if (i == 28 || i == 12 || i == 38)
                casas[i] = new CompanhiaServico();
            else if (i == 7 || i == 22 || i== 36)
                casas[i] = new Sorte();
            else if (i == 2 || i == 17 || i == 33)
                casas[i] = new Cofre();
            else
                casas[i] = new Terreno();
        }
        baralhoSorte = new Baralho();
        baralhoSorte.addCartaSorte();
        embaralhaBaralho(baralhoSorte);
        baralhoCofre = new Baralho();
        baralhoCofre.addCartaCofre();
        embaralhaBaralho(baralhoCofre);
    }
    private void embaralhaBaralho(Baralho baralho)
    {
        baralho.embaralharCartas();
    }
    public void checkEfeito(Jogador jogador) 
    {
        Casa casaDoJogador = checkPosicao(jogador.getPosicao());
        aplicaEfeito(jogador,casaDoJogador);
    }
    private void aplicaEfeito(Jogador jogador, Casa casaDoJogador)
    {
        casaDoJogador.executaEfeitoCasa(jogador);
    }
    private Casa checkPosicao(int posicao)
    {
        return casas[posicao];
    }
    public void moveJogador(Jogador jogador, int passos) 
    {
        jogador.setPosicao(jogador.getPosicao()+passos);

    }
    public void prenderJogador(Jogador jogador) 
    {
        jogador.setPreso(true);
        jogador.setPosicao(10);
    }
    public void liberarJogador(Jogador jogador) 
    {
        jogador.setPreso(false);
    }
    public List<Casa> getCasas()
    {
        return casas;
    }
    public List<GameObject> getCasasTabuleiro()
    {
        return casasTabuleiro;
    }
    public Baralho getBaralhoSorte()
    {
        return baralhoSorte;
    }
    public Baralho getBaralhoCofre()
    {
        return baralhoCofre;
    }
}
