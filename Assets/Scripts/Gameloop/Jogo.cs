using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour
{
    [SerializeField] private List<GameObject> pecas;
    [SerializeField][Range(0.1f, 1.0f)] private float moveSpeed; // Velocidade de movimento da peça

    private Jogo instancia;
    private Tabuleiro tabuleiro;
    private List<Jogador> jogadores;
    private Dados dados;

    private int turno;
    private int rodada;

    void FixedUpdate()
    {
        if (turno % jogadores.Count == 0) 
            avancarRodada();
        StartCoroutine(movePecas());
    }

    public void iniciarJogo(int qntdJogadores)
    {
        this.instancia = this;
        this.tabuleiro = new Tabuleiro();
        this.jogadores = new List<Jogador>(qntdJogadores);
        this.dados = new Dados();
        this.turno = 0;
        this.rodada = 0;
        for (int i=0; i < jogadores.Count; i++)
        {
            this.pecas[i].gameObject.SetActive(true);
        }
    }
    public void avancarTurno()
    {
        this.turno++;
    }
    private void avancarRodada()
    {
        this.rodada++;
    }
    public void jogarRodadaHumano()
    { 
        rolarDados();
    }
    public void jogarRodadaIa()
    {
        rolarDados();
    }
    private void rolarDados()
    {
        bool dadosIguais;
        do {
            int dadosTotais = this.dados.lancarDados();
            dadosIguais = this.dados.checarDados();
            bool estaPreso = this.jogadores[turno].checarPreso();
            if (dadosIguais && estaPreso)
                this.tabuleiro.liberarJogador(this.jogadores[turno]);
            if (!estaPreso)
                this.tabuleiro.moveJogador(this.jogadores[turno], dadosTotais);
        } while (this.dados.getContador() < 3 && dadosIguais);
        if (this.dados.getContador() == 3)
            this.tabuleiro.prenderJogador(this.jogadores[turno]);
    }
    IEnumerator movePecas()
    {
        for (int i = 0; i < this.jogadores.Count; i++)
        {
            Vector3 targetPosition;
            if ((this.jogadores[i].getPosicao() >= 0 && this.jogadores[i].getPosicao() <= 10) || (this.jogadores[i].getPosicao() >= 20 && this.jogadores[i].getPosicao() <= 30))
                targetPosition = new Vector3(pecas[i].transform.position.x,tabuleiro.getCasasTabuleiro()[this.jogadores[i].getPosicao()].transform.position.y, pecas[i].transform.position.z);
            else
                targetPosition = new Vector3(tabuleiro.getCasasTabuleiro()[this.jogadores[i].getPosicao()].transform.position.x, pecas[i].transform.position.y, pecas[i].transform.position.z);

            while (Vector3.Distance(pecas[i].transform.position, targetPosition) > 0.01f)
            {
                pecas[i].transform.position = Vector3.MoveTowards(pecas[i].transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            pecas[i].transform.position = targetPosition;
        }
    }
    public void addJogador(Jogador jogador)
    {
        this.jogadores.Add(jogador);
    }
    public void removeJogador(Jogador jogador)
    {
        this.jogadores.Remove(jogador);
    }
    public List<GameObject> getPecas()
    {
        return this.pecas;
    }
    public Jogo getInstancia()
    {
        if (this.instancia == null)
            instancia = new Jogo();
        return instancia;
    }
}
