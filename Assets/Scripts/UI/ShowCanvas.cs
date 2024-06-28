using TMPro;
using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    [SerializeField] private Jogador jogador;
    [SerializeField] private TMP_Text textNome;
    [SerializeField] private TMP_Text textSaldo;

    void Update()
    {
        textNome.text = jogador.getName();
        textSaldo.text = jogador.getSaldo().ToString();
    }
}
