using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doge
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] gras = { '@', '_', '_', '_', '_', '_', '_', '_', '_', '_', };
            int i = 0;
            int HP = 100;
            Random rnd = new Random();
            char temp = gras[i];
            char swap = gras[i + 1];
            int bomb = rnd.Next(1, 10);
            gras[bomb] = '*';
            int heal = 0;
            for (int k = 0; k < 99; k++)
            {
               
                heal = rnd.Next(1, 10);
                if (bomb == heal)
                {
                    continue;

                }
                else
                {
                    gras[heal] = '+';
                    break;
                }
            }

            for (int h = 0; h < 99; h++)
            {
                
                if (HP <= 0)
                {
                    Console.WriteLine("Bark(LOSE)");
                    break;
                }

                for (int j = 0; j < gras.Length; j++)
                {

                    Console.Write(gras[j]);


                }
                Console.Write("  HP="+HP);
                Console.WriteLine();
                
                if (gras[gras.Length - 1] == '@')
                {

                    Console.WriteLine("WIN");
                    break;
                }



                switch (Console.ReadLine())
                {
                    case "D":
                    case "d":
                        HP -= 5;
                        gras[i] = swap;
                        gras[i + 1] = temp;
                        i++;
                        if (i == bomb)
                        {
                            HP -= 40;
                            bomb = -1;
                        }
                        if (i == heal)
                        {
                            HP += 40;
                            heal = -1;
                        }
                        break;
                    case "A":
                    case "a":
                        if (i==0)
                        {
                            Console.Clear();
                            continue;
                        }
                        HP -= 5;
                        char back = gras[i - 1];
                        gras[i] = back;
                        gras[i - 1] = temp;
                        i--;
                        break;


                }
                Console.Clear();
            }
            
            Console.ReadKey();
        }
    }
}
