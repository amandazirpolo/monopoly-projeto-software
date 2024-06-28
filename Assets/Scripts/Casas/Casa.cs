using UnityEngine;

public abstract class Casa : MonoBehaviour
{
    [SerializeField] protected string nome;
    [SerializeField] protected string descricao;

    public abstract void executaEfeitoCasa(Jogador jogador);
}
