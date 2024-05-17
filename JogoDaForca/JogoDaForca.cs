namespace Jogo
{
    public class JogoDaForca
    {
        public static string[] Palavras { get; set; }
        private char[] Acertos { get; set; }
        private List<string> LetrasUsada { get; set; }
        private string PalavraParaAdivinhar { get; set; }
        private int Erros { get; set; }
        private int Tentativas
        {
            get
            {
                return LetrasUsada.Count;
            }
        }
        private string Tentativa { get; set; }

        public JogoDaForca()
        {
            Palavras =
                [
                "ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "BACABA", "BACURI",
                "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA",
                "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA",
                "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI",
                "TANGERINA", "UMBU", "UVA", "UVAIA"
                ];
            LetrasUsada = new List<string>();
            Random random = new Random();
            PalavraParaAdivinhar = Palavras[Convert.ToInt32(random.Next(Palavras.Length))];
            Erros = 1;
            Acertos = new char[PalavraParaAdivinhar.Length];
            for (int i = 0; i < Acertos.Length; i++)
            {
                Acertos[i] = '_';
            }
        }

        public void Responder()
        {
            do
            {
                DesenharForca();

                if (EscolherLetra() is false)
                {
                    continue;
                }

                VerificarTentativa();
            }
            while (DesenharForca());
        }

        private bool EscolherLetra()
        {
            Console.WriteLine("Escolha uma letra A...Z: ");
            Tentativa = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(Tentativa) ||
                int.TryParse(Tentativa, out int numero)
                || Tentativa.Length > 1)
            {
                Console.WriteLine($"Insira uma letra");
                Console.ReadKey();
                return false;
            }
            if (LetrasUsada.Contains(Tentativa))
            {
                Console.WriteLine($"Letra já usada '{Tentativa}', tenta usar outra.");
                Console.ReadKey();
                return false;
            }
            LetrasUsada.Add(Tentativa);
            return true;
        }

        private void VerificarTentativa()
        {
            bool acertouPalavra = false;
            for (int i = 0; i < PalavraParaAdivinhar.Length; i++)
            {
                if (Tentativa[0] == PalavraParaAdivinhar[i].ToString().ToUpper()[0])
                {
                    Acertos[i] = Tentativa[0];
                    acertouPalavra = true;
                }
            }
            if (acertouPalavra is false)
            {
                Erros++;
            }
        }

        // Método para exibir o desenho do boneco baseado no número de erros
        private bool DesenharForca()
        {
            Console.Clear();
            string cabeca = Erros > 0 ? @" (oo) " : "    ";
            string bracos = Erros > 1 ? @"//  \\" : "    ";
            string tronco = Erros > 2 ? @"  || " : "    ";
            string pernas = Erros > 3 ? @"//  \\" : "    ";

            string desenho = $@"
=========
+----------+
!       {cabeca}   
!       {bracos}  
!       {tronco}
!       {pernas}
!
=========
Número de tentativas: {Tentativas}
Palavras escolhidas : {LetrasUsadas()}
Palavra: {MontarAcertos()}
";

            Console.WriteLine(desenho);
            if (Erros > 4)
            {
                Console.WriteLine("###Você perdeu!!");
                return true;
            }
            return AcertouPalavraCheia() is false;
        }

        private string LetrasUsadas()
        {
            string letras = string.Empty;
            foreach (string letra in LetrasUsada)
            {
                letras += letra;
            }
            return letras;
        }

        private string MontarAcertos()
        {
            string acerto = string.Empty;
            foreach (char letra in this.Acertos)
            {
                acerto += letra;
            }
            return acerto;
        }
        private bool AcertouPalavraCheia()
        {
            for (int i = 0; i < PalavraParaAdivinhar.Length; i++)
            {
                if (Acertos[i] != PalavraParaAdivinhar[i])
                {
                    return false;
                }
            }
            Console.WriteLine("###Você acertou!!");
            return true;
        }
    }
}
