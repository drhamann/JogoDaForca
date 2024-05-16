namespace Jogo
{
    public class JogoDaForca
    {
        public string[] palavras { get; set; }
        char[] acertos { get; set; }
        List<string> letrasUsada { get; set; } = new List<string>();
        public string palavraParaAdivinhar { get; set; }
        public int erros { get; set; } = 0;

        public JogoDaForca()
        {
            palavras = new string[30];

            string palavrao = "ABACATE ABACAXI ACEROLA AÇAÍ ARAÇA BACABA BACURI BANANA CAJÁ CAJÚ CARAMBOLA CUPUAÇU GRAVIOLA GOIABA JABUTICABA JENIPAPO MAÇÃ MANGABA MANGA MARACUJÁ MURICI PEQUI PITANGA PITAYA SAPOTI TANGERINA UMBU UVA UVAIA";
            palavras = palavrao.ToLower().Split(" ");
            Selecionar();
            acertos = new char[palavraParaAdivinhar.Length];

        }


        private void Selecionar()
        {
            Random random = new Random();
            palavraParaAdivinhar = palavras[Convert.ToInt32(random.Next(palavras.Length))];
        }

        public void Responder()
        {
            string resposta = " ";

            do
            {

                Console.WriteLine("Escolha uma letra A...Z: ");
                resposta = Console.ReadLine().ToLower();
                letrasUsada.Add(resposta);

                Console.WriteLine("Letras usadas: ");
                foreach (string letra in letrasUsada)
                {
                    Console.Write(letra);
                }

                Console.WriteLine("\n ");

                bool acertouPalavra = false;
                for (int i = 0; i < palavraParaAdivinhar.Length; i++)
                {
                    if (resposta[0] == palavraParaAdivinhar[i])
                    {
                        acertos[i] = palavraParaAdivinhar[i];
                        acertouPalavra = true;
                    }
                }
                if (acertouPalavra is false)
                {
                    erros++;
                }

                foreach (char letra in acertos)
                {
                    Console.WriteLine("certa resposta, a palavra era: " + letra);
                }
            }
            while (this.AcertouPalavraCheia() is false && erros < 5);
        }

        private bool AcertouPalavraCheia()
        {
            for (int i = 0; i < palavraParaAdivinhar.Length; i++)
            {
                if (acertos[i] != palavraParaAdivinhar[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
