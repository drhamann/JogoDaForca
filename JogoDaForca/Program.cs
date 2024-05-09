namespace JogoDaForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] palavras = new string[30];

            palavras = Sorteador.PopularLista(palavras);

            string palavraSortida = Sorteador.Selecionar(palavras);

            List<string> palavraSecreta = new List<string>();   
            
            palavraSecreta = Verificador.CriarJogo(palavraSortida);  

            Verificador.Responder(palavraSecreta);
            
        }
    }
}
