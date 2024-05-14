using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    public class Sorteador
    {

        public Sorteador() { }

        public static string[] PopularLista(string[] palavras)
        {
            palavras = new string[30];
            string palavrao = "ABACATE ABACAXI ACEROLA AÇAÍ ARAÇA ABACATE BACABA BACURI BANANA CAJÁ CAJÚ CARAMBOLA CUPUAÇU GRAVIOLA GOIABA JABUTICABA JENIPAPO MAÇÃ MANGABA MANGA MARACUJÁ MURICI PEQUI PITANGA PITAYA SAPOTI TANGERINA UMBU UVA UVAIA";

            palavras = palavrao.ToLower().Split(" ");

            return palavras;
        }

        public static string Selecionar(string[] palavras) 
        {
            string palavraRamdom = " ";
            Random randNum = new Random();

            palavraRamdom = palavras[Convert.ToInt32(randNum.Next(30))];


            return palavraRamdom;
        }
    }
}
 