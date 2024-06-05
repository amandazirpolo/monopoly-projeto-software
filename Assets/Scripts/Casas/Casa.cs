using UnityEngine;

public abstract class Casa : MonoBehaviour
{
    [SerializeField] private string nome;
    [SerializeField] private string descricao;

    public abstract void executaEfeitoCasa(Jogador jogador);
}
