namespace JogoDaForca
{
    public class Verificador
    {
        public static List<string> CriarJogo(string palavraRamdom)
        {

            List<string> enigma;
            enigma = palavraRamdom.Split().ToList();

            return enigma;
        }

        public static void Responder(List<string> enigma)
        {
            string resposta = " ";
            int erros = 0;
            List<string> acertos = new List<string>();
            List<string> letrasUsada = new List<string>();

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

                Console.WriteLine(" ");

                for (int i = 0; i < enigma.Count; i++)
                {

                    if (resposta == enigma[i])
                    {

                        acertos[i] = enigma[i];

                    }
                }



                if (acertos == null)
                {
                    erros = letrasUsada.Count;
                    Console.WriteLine("Errou!!!");
                }

                else
                {
                    foreach (string letra in acertos)
                        Console.WriteLine(letra);
                }

            }
            while (acertos.Count < enigma.Count && erros < 6);
        }

    }
}


