using System; // Importa o namespace System.
using System.Threading; // Importa o namespace System.Threading.

class BatalhaDosNumeros // Declara a classe BatalhaDosNumeros.
{
    static Random random = new Random(); // Cria uma instância de Random para gerar números aleatórios.
    static int pontosDeVidaJogador = 100; // O jogador inicia com 100 pontos de vida.
    static int pontosDeVidaMonstro = 50; // O monstro inicia com 50 pontos de vida.

    static void Main(string[] args) // Método principal, onde a execução do programa começa.
    {
        // Cabeçalho do Jogo
        Console.WriteLine("============================================");
        Console.WriteLine("|            BATALHA DOS NÚMEROS           |");
        Console.WriteLine("============================================\n");

        // Loop principal do jogo que continua enquanto o jogador e o monstro ainda tiverem vida.
        while (pontosDeVidaJogador > 0 && pontosDeVidaMonstro > 0)
        {
            Console.WriteLine($"Você tem {pontosDeVidaJogador} de vida."); // Exibe a vida atual do jogador.
            Console.WriteLine($"O monstro tem {pontosDeVidaMonstro} de vida."); // Exibe a vida atual do monstro.
            Console.WriteLine("Resolva a equação:"); // Informa que o jogador deve resolver a equação.

            // Chama o método ResolverEquacao e verifica se o jogador acertou a resposta.
            if (ResolverEquacao())
            {
                int danoAoMonstro = random.Next(10, 21); // Gera um dano aleatório entre 10 e 20 para o monstro.
                pontosDeVidaMonstro -= danoAoMonstro; // Subtrai o dano da vida do monstro.
                Console.WriteLine($"Você acertou! Causou {danoAoMonstro} de dano ao monstro.\n"); // Informa o dano causado.
            }
            else // Se o jogador não acertar a resposta.
            {
                int danoAoJogador = random.Next(5, 16); // Gera um dano aleatório entre 5 e 15 para o jogador.
                pontosDeVidaJogador -= danoAoJogador; // Subtrai o dano da vida do jogador.
                Console.WriteLine($"Você errou! O monstro te atacou e causou {danoAoJogador} de dano.\n"); // Informa o dano recebido.
            }

            Thread.Sleep(1000); // Pausa o programa por 1 segundo.
        }

        // Mensagem final
        if (pontosDeVidaMonstro <= 0)
        {
            Console.WriteLine("\nVocê derrotou o monstro! Você venceu o jogo!"); // Mensagem de vitória.
            Console.WriteLine(@"
█████████
█▄█████▄█
█▼▼▼▼▼
█ Você Venceu!
█▲▲▲▲▲
█████████
 ██ ██"); // Exibe uma arte ASCII de vitória.
        }
        else
        {
            Console.WriteLine("\nVocê foi derrotado! Obrigado por jogar Batalha dos Números!"); // Mensagem de derrota.
            Console.WriteLine(@"
█████████
█▄█████▄█
█▼▼▼▼▼
█ Você Perdeu!
█▲▲▲▲▲
█████████
 ██ ██"); // Exibe uma arte ASCII de derrota.
        }
    }

    static bool ResolverEquacao() // Método que gera e resolve a equação.
    {
        int num1 = random.Next(1, 21); // Gera o primeiro número aleatório entre 1 e 20.
        int num2 = random.Next(1, 21); // Gera o segundo número aleatório entre 1 e 20.
        string operacao = new[] { "+", "-" }[random.Next(2)]; // Escolhe aleatoriamente entre adição e subtração.
        
        int respostaCorreta = operacao switch
        {
            "+" => num1 + num2, // Se a operação for adição, calcula a soma.
            "-" => num1 - num2, // Se a operação for subtração, calcula a diferença.
            _ => 0 // Caso padrão (não deve ocorrer aqui).
        };

        // Exibe a equação ao jogador.
        Console.WriteLine($"{num1} {operacao} {num2} = ?");

        // Aguarda a resposta do jogador e verifica se a resposta é um número e se está correta.
        string respostaJogador = Console.ReadLine(); 
        return int.TryParse(respostaJogador, out int resposta) && resposta == respostaCorreta; 
    }
}
