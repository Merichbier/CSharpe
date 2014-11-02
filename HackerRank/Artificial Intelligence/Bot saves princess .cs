using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class BotSavesPrincess
    {


        static void Main(String[] args)
        {
            int n;

            n = int.Parse(Console.ReadLine());
            String[] grid = new String[n];
            for (int i = 0; i < n; i++)
            {
                grid[i] = Console.ReadLine();
            }
            nextMove(n, grid);
            Console.ReadLine();

        }

        static void nextMove(int n, String[] grid)
        {
            int[] princess_pos = new int[2];
            findCharacter('p',grid, out princess_pos[0], out princess_pos[1]);
            int[] bot_pos = new int[2];
            findCharacter('m', grid, out bot_pos[0], out bot_pos[1]);
            computeMove(bot_pos, princess_pos);
        }

        static void findCharacter(char character, String[] grid, out int princess_posX, out int princess_posY)
        {
            for (int i = 0; i < grid.Length; ++i)
            {
                if (grid.ElementAt(i).Contains(character))
                {
                    princess_posY = i;
                    for (int j = 0; j < grid.ElementAt(i).Length; ++j)
                    {
                        if (grid.ElementAt(i).ElementAt(j).Equals(character))
                        {
                            princess_posX = j;
                            return;
                        }
                    }
                }
            }
            princess_posX = -1;
            princess_posY = -1;
        }

        static void computeMove(int[] bot, int[] princess)
        {
            int x = princess[0] - bot[0];
            if (x < 0)
            {
                printMult("LEFT", -x);
            }
            else if (x > 0)
            {
                printMult("RIGHT",x);
            }
            int y = princess[1] - bot[1];
            if (y < 0)
            {
                printMult("UP", -y);
            }
            else if (y > 0)
            {
                printMult("DOWN", y);
            }
        }

        static void printMult(String str, int nb)
        {
            for (int n = 0; n < nb; ++n)
            {
                Console.WriteLine(str);
            }

        }
    }


}
