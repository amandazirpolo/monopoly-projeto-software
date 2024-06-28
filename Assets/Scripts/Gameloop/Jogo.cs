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
        if (turno % (jogadores.Count - 1) == 0) 
            avancarRodada();
        if (jogadores[turno].getPosicao() - jogadores[turno].getPosicaoAntiga() < 0) 
            jogadores[turno].credita(200);
        StartCoroutine(movePecas());
    }

    private Jogo()
    {
        this.tabuleiro = new Tabuleiro();
        this.dados = new Dados();
        this.jogadores = new List<Jogador>(6);
        this.turno = 0;
        this.rodada = 0;
    }
    public void iniciarJogo()
    {
        this.instancia = getInstancia();
    }
    public void avancarTurno()
    {
        this.turno++;
    }
    private void avancarRodada()
    {
        this.rodada++;
    }
    public void rolarDados()
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
            int currentPos = this.jogadores[i].getPosicao();
            int piecePos = this.jogadores[i].getPosicaoAntiga();

            // Verifica se a peça está em uma dezena atrás do jogador
            if ((piecePos / 10) < (currentPos / 10))
            {
                // Move a peça para a próxima dezena inteira
                int nextDecadePos = ((piecePos / 10) + 1) * 10;
                Vector3 targetPositionDecade = getTargetPosition(i, nextDecadePos);
                yield return MoveToPosition(i, targetPositionDecade);
            }

            // Move a peça para a posição final do jogador
            Vector3 targetPosition = getTargetPosition(i, currentPos);
            yield return MoveToPosition(i, targetPosition);
        }
    }

    private Vector3 getTargetPosition(int i, int pos)
    {
        Vector3 targetPosition;
        if ((pos >= 10 && pos <= 20) || (pos >= 30 && pos <= 39))
            targetPosition = new Vector3(pecas[i].transform.position.x, tabuleiro.getCasasTabuleiro()[pos].transform.position.y, pecas[i].transform.position.z);
        else
            targetPosition = new Vector3(tabuleiro.getCasasTabuleiro()[pos].transform.position.x, pecas[i].transform.position.y, pecas[i].transform.position.z);
        return targetPosition;
    }

    private IEnumerator MoveToPosition(int i, Vector3 targetPosition)
    {
        while (Vector3.Distance(pecas[i].transform.position, targetPosition) > 0.01f)
        {
            pecas[i].transform.position = Vector3.MoveTowards(pecas[i].transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        pecas[i].transform.position = targetPosition;
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
