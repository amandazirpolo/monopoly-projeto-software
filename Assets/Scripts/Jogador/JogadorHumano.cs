using UnityEngine.SceneManagement;

public class JogadorHumano : Jogador
{
    public JogadorHumano()
    {
        this.posicaoAntiga = 0;
        this.posicao = 0;
        this.preso = false;
        this.turnosPreso = 0;
    }
    public override void comprarCasa(Propriedades propriedade)
    {
        // 3 cores: vermelho = 1, amarelo = 2, laranja = 3, azulClaro = 4, rosa = 5, verde = 6;
        // 2 cores: marrom = 7, azulEscuro = 8;
        Terreno terreno;
        int corMax = 0;
        if (propriedade is Terreno)
        {
            terreno = (Terreno)propriedade;
            if (terreno.getCor() < 7) corMax = 3;
            else corMax = 2;
        }

        int cont = 0;
        foreach (Propriedades prop in this.propriedades)
        {
            if (prop is Terreno)
            {
                terreno = (Terreno)prop;
                if (terreno.getCor() == ((Terreno)propriedade).getCor())
                {
                    cont += 1;
                }
            }
        }
        
        if ((cont == corMax) && (this.getSaldo() >= propriedade.getCustoCompra()))
        {
            terreno = (Terreno)propriedade;
            terreno.comprarCasa();
        }
    }

    public override void comprarPropriedade(Propriedades propriedade)
    {
        if (this.getSaldo() >= propriedade.getCustoCompra())
              propriedade.gerenciaPropriedade(this);
    }

    public void desistir()
    {
        SceneManager.LoadScene(0);
    }
}
