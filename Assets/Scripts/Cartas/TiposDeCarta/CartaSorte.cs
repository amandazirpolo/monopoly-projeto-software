using TMPro;
using UnityEngine;

public abstract class CartaSorte : MonoBehaviour
{
    protected string descricao;
    protected int valor;
    
    public virtual void aplicarEfeito(Jogador jogador)
    {
        return;
    }
    public void mostrarCarta(TextMeshPro texto)
    {
        texto.text = descricao;
    }
}
