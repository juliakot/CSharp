using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conectivity_graph
{
    class Program
    {
        class Graf
        {
            private int rozmir;
            private List<Int32>[] rebro;

            public Graf(int v)
            {
                rozmir = v;
                rebro = new List<Int32>[v];
                for (int i = 0; i < v; i++)
                {
                    rebro[i] = new List<int>();
                }
            }

            public void addRebro(int c, int v)
            {
                rebro[c].Add(v);
                rebro[v].Add(c);
                // 1--2
                // 2--1,3,4
                // 3--4,2
                // 4--2,3,5
                // 5--4
            }

            public void DFS(int v)
            {
                int x = 0;
                int[] masNomer = new int[rozmir];
                int[] masDalnist = new int[rozmir];
                bool k = true;
                bool[] vidvidana = new bool[rozmir];
                Stack<Int32> stack = new Stack<int>();
                vidvidana[v] = true;
                stack.Push(v);
                int a = 1;
                while (stack.Count != 0)
                {
                    a--;
                    v = stack.Pop();

                    masNomer[x] = v;
                    masDalnist[x] = rozmir - a;
                    x++;

                    foreach (int i in rebro[v])
                    {
                        a++;
                        if (vidvidana[i] == false)
                        {
                            a++;
                            vidvidana[i] = true;
                            stack.Push(i);

                        }

                    }

                }



                for (int i = 1; i < rozmir; i++)
                {

                    if (vidvidana[i] == false)
                    {
                        Console.WriteLine("Ne vsi stantsii zyednani!");
                        return;
                    }
                }

                //return k;

                // kinec while;

                Console.WriteLine();

                //// sortuyemo
                for (int i = 0; i < rozmir - 1; i++)
                {
                    for (int j = 0; j < rozmir - 1; j++)
                    {
                        if (masDalnist[j] > masDalnist[j + 1])
                        {
                            int tmp = masDalnist[j];
                            masDalnist[j] = masDalnist[j + 1];
                            masDalnist[j + 1] = tmp;

                            tmp = masNomer[j];
                            masNomer[j] = masNomer[j + 1];
                            masNomer[j + 1] = tmp;

                        }
                    }
                }

                // vyvodymo
                int p = 1;
                for (int z = 0; z < rozmir; z++)
                {
                    if (masNomer[z] != 0)
                    {
                        Console.WriteLine("Stantsia #" + masNomer[z] + "  Vydalyty " + p + "-oyu");
                        p++;
                    }
                }



            }

        }
        static void Main(string[] args)
        {
            int N, M, a, b;
            string c;
            string[] c2 = new string[2];
            Console.Write("N = ");
            N = Convert.ToInt32(Console.ReadLine());
            Console.Write("M = ");
            M = Convert.ToInt32(Console.ReadLine());

            Graf g = new Graf(N + 1);

            for (int i = 0; i < M; i++)
            {
                Console.Write((i + 1) + "-a linia: ");
                c = Console.ReadLine();
                c2 = c.Split(' ');
                a = Convert.ToInt32(c2[0]);
                b = Convert.ToInt32(c2[1]);
                if (a > N || b > N)
                {
                    Console.WriteLine("Neisnuye stantsiy dlya linii #" + a + " - #" + b);
                    break;
                }
                g.addRebro(a, b);
            }

            g.DFS(1);


            Console.ReadKey();




        }
    }
}