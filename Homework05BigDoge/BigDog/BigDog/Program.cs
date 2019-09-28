using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDog
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] gras = new char[15][];
            int HP = 100;
            char temp;
            int horiz = 1;
            int vert = 1;
            Random rnd = new Random();
            int[] bomb = new int[gras.Length];
            int[] heal = new int[gras.Length];
            
            for (int i = 0; i<gras.Length;i++)
            {
                gras[i] = new char[gras.Length];
            }
            for (int k = 0; k < gras.Length; k++)
            {
                for (int w = 0; w < gras.Length; w++)
                {
                    if (k == 0 || k == gras.Length-1 || w == 0 || w == gras[k].Length-1)
                    {
                        gras[k][w] = '#';
                    }
                }
            }
            for (int r = 1; r < gras.Length-1; r++)
            {
                if (r == 1)
                {
                    bomb[r] = rnd.Next(2, gras.Length-1);
                    gras[r][bomb[r]] = '*';
                    
                }
                else
                {
                    bomb[r] = rnd.Next(1, gras.Length-1);
                    gras[r][bomb[r]] = '*';
                    
                }
            }
            for (int y = 1; y < gras.Length - 1; y++)
            {

                heal[y] = rnd.Next(1, gras.Length-1);
                if (y == 1)
                {
                    if (heal[y] == bomb[y])
                    {
                        y--;
                    }
                    else
                    {
                        gras[y][heal[y]] = '+';

                    }
                }
                else
                {
                    if (heal[y] == bomb[y])
                    {
                        y--;
                    }
                    else
                    {
                        gras[y][heal[y]] = '+';

                    }
                }
            }
            gras[1][1] = '@';
            for (int q = 0; q < 99; q++)
            {
                
                Console.Clear();
                for (int k = 0; k < gras.Length; k++)
                {
                    for (int w = 0; w < gras.Length; w++)
                    {
                        Console.Write(gras[k][w]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(HP);
                if (HP <= 0)
                {
                    Console.WriteLine("LOSE");
                    break;
                }
                if (horiz == gras.Length-2 && vert ==gras.Length-2)
                {
                    Console.WriteLine("WIN");
                    break;
                }
                switch (Console.ReadLine())
                {
                    case "D":
                    case "d":
                        HP -= 5;
                        if (horiz == gras.Length - 2)
                        {

                            temp = gras[vert][horiz];
                            gras[vert][horiz] = gras[vert][1];
                            gras[vert][1] = temp;
                            horiz = 1;
                            if (horiz == bomb[vert])
                            {
                                HP -= 40;
                                gras[vert][gras.Length - 2] = ' ';
                                bomb[vert] = -1;
                            }
                            if (horiz == heal[vert])
                            {
                                HP += 40;
                                gras[vert][gras.Length - 2] = ' ';
                                heal[vert] = -1;
                            }
                        }
                        else
                        {
                            temp = gras[vert][horiz];
                            gras[vert][horiz] = gras[vert][horiz + 1];
                            gras[vert][horiz + 1] = temp;
                            horiz++;
                            if (horiz==bomb[vert])
                            {
                                HP -= 40;
                                gras[vert][horiz - 1] = ' ';
                                bomb[vert] = -1;
                            }
                            if (horiz == heal[vert])
                            {
                                HP += 40;
                                gras[vert][horiz - 1] = ' ';
                                heal[vert] = -1;
                            }
                        }
                        break;
                    case "A":
                    case "a":
                        HP -= 5;
                        if (horiz == 1)
                        {

                            temp = gras[vert][horiz];
                            gras[vert][horiz] = gras[vert][gras.Length - 2];
                            gras[vert][gras.Length - 2] = temp;
                            horiz = gras.Length - 2;
                            if (horiz == bomb[vert])
                            {
                                HP -= 40;
                                gras[vert][1] = ' ';
                                bomb[vert] = -1;
                            }
                            if (horiz == heal[vert])
                            {
                                HP += 40;
                                gras[vert][1] = ' ';
                                heal[vert] = -1;
                            }
                        }
                        else
                        {
                            temp = gras[vert][horiz];
                            gras[vert][horiz] = gras[vert][horiz - 1];
                            gras[vert][horiz - 1] = temp;
                            horiz--;
                            if (horiz == bomb[vert])
                            {
                                HP -= 40;
                                gras[vert][horiz + 1] = ' ';
                                bomb[vert] = -1;
                            }
                            if (horiz == heal[vert])
                            {
                                HP += 40;
                                gras[vert][horiz + 1] = ' ';
                                heal[vert] = -1;
                            }
                        }
                        break;
                    case "S":
                    case "s":
                        HP -= 5;
                        if (vert == gras.Length-2)
                        {

                            temp = gras[vert][horiz];
                            gras[vert][horiz] = gras[1][horiz];
                            gras[1][horiz] = temp;
                            vert = 1;
                            if (horiz == bomb[vert])
                            {
                                HP -= 40;
                                gras[gras.Length - 2][horiz] = ' ';
                                bomb[vert] = -1;
                            }
                            if (horiz == heal[vert])
                            {
                                HP += 40;
                                gras[gras.Length - 2][horiz] = ' ';
                                heal[vert] = -1;
                            }
                        }
                        else
                        {
                            temp = gras[vert][horiz];
                            gras[vert][horiz] = gras[vert + 1][horiz];
                            gras[vert + 1][horiz] = temp;
                            vert++;
                            if (horiz == bomb[vert])
                            {
                                HP -= 40;
                                gras[vert - 1][horiz] = ' ';
                                bomb[vert] = -1;
                            }
                            if (horiz == heal[vert])
                            {
                                HP += 40;
                                gras[vert - 1][horiz] = ' ';
                                heal[vert] = -1;
                            }
                        }
                        break;
                    case "W":
                    case "w":
                        HP -= 5;
                        if (vert == 1)
                        {

                            temp = gras[vert][horiz];
                            gras[vert][horiz] = gras[gras.Length-2][horiz];
                            gras[gras.Length - 2][horiz] = temp;
                            vert = gras.Length - 2;
                            if (horiz == bomb[vert])
                            {
                                HP -= 40;
                                gras[1][horiz] = ' ';
                                bomb[vert] = -1;
                            }
                            if (horiz == heal[vert])
                            {
                                HP += 40;
                                gras[1][horiz] = ' ';
                                heal[vert] = -1;
                            }
                        }
                        else
                        {
                            temp = gras[vert][horiz];
                            gras[vert][horiz] = gras[vert - 1][horiz];
                            gras[vert - 1][horiz] = temp;
                            vert--;
                            if (horiz == bomb[vert])
                            {
                                HP -= 40;
                                gras[vert + 1][horiz] = ' ';
                                bomb[vert] = -1;
                            }
                            if (horiz == heal[vert])
                            {
                                HP += 40;
                                gras[vert + 1][horiz] = ' ';
                                heal[vert] = -1;
                            }
                        }
                        break;
                }

                
            }
            
            Console.ReadKey();
        }
    }
}
