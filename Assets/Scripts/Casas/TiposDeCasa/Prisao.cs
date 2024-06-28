using System.Collections.Generic;

public class Prisao : Casa
{
    private List<Jogador> presos;
    public override void executaEfeitoCasa(Jogador jogador)
    {
        if (jogador.getPreso())
            adicionarPreso(jogador);
        else
            removerPreso(jogador);
    }
    private void adicionarPreso(Jogador jogador)
    {
        presos.Add(jogador);
    }
    private void removerPreso(Jogador jogador)
    {
        presos.Remove(jogador);
    }
}
