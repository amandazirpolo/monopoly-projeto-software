using System.Collections.Generic;
using UnityEngine;

public class Tabuleiro : MonoBehaviour
{
    [SerializeField] private List<GameObject> casasTabuleiro;
    [SerializeField] private List<GameObject> pecas;

    private List<Casa> casas;
    private Baralho baralhoSorte;
    private Baralho baralhoCofre;

    void Start()
    {
        iniciarTabuleiro();
    }
    private void iniciarTabuleiro()
    {
        casas = new List<Casa>(40);
        for (int i = 0; i < casas.Count; i++)
        {
            if (i == 0)
                casas[i] = new Imposto();
            else if (i==10)
                casas[i] = new Prisao();
            else if (i==30)
                casas[i] = new VaPrisao();
            else if (i == 5 || i == 15 || i == 25 || i == 35)
                casas[i] = new Ferrovia();
            else if (i == 28)
                casas[i] = new CompanhiaServico();
            else if (i == 7 || i == 22 || i == 36)
                casas[i] = new Sorte();
            else if (i == 38)
                casas[i] = new Cofre();
            else
                casas[i] = new Terreno();
        }
        baralhoSorte = new Baralho();
        embaralhaBaralho(baralhoSorte);
        baralhoCofre = new Baralho();
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
    public void verificaAluguel(int posicao)
    {
        return casas[posicao].verificaAluguel();
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
    public List<GameObject> getCasasTabuleiro()
    {
        return casasTabuleiro;
    }
}
