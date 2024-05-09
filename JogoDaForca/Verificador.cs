using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaForca
{
    public class Verificador
    {
        public static List<string> CriarJogo(string palavraRamdom) 
        {

            List<string> enigma = new List<string>();

            return enigma = palavraRamdom.Split().ToList();
        }

        public static void Responder(List<string> enigma) 
        {
            string resposta = " ";
            int erros = 0;
            List<string> acertos = new List<string>();
            List<string> letrasUsada = new List<string>();
            

            for(int i = 0; acertos.Count < enigma.Count && erros < 6; i++) 
            {
                
                Console.WriteLine("Escolha uma letra A...Z: ");
                resposta = Console.ReadLine().ToLower();
                letrasUsada.Add(resposta);

                Console.WriteLine("Letras usadas: ");

                foreach (string letra in letrasUsada)
                {
                 Console.WriteLine(letra);
                }

                foreach(string letra in enigma) 
                {
                    if (resposta == letra)
                    {
                        acertos[i] = letra;

                        foreach (string letras in acertos)
                        {
                            Console.Write(letra);
                        }
                    }

                    else if (resposta != letra)
                    {
                        erros++;
                        Console.WriteLine("Errou!!!");
                    }

                }

                
            }

            }
        }    
    }

