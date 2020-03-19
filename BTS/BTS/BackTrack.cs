using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS
{
    static class BackTrack
    {
        private static bool Ft(int level, Person x) { return true; }

        private static bool Fk(Person[] results, int level, Person x)
        {
            for (int i = 0; i < level; i++)
                if (results[i].Equals(x))
                    return false;

            return true;
        }

        public static void Search(int level, ref Person[] R, ref bool HAVE, int[] S, Person[,] P)
        {
            int i = -1;
            while (!HAVE && i < S[level])
            {
                i++;
                if (Ft(level, P[level, i]))
                {
                    if (Fk(R, level, P[level, i]))
                    {
                        R[level] = P[level, i];
                        if (level == P.GetLength(0) - 1)
                            HAVE = true;
                        else
                            Search(level + 1, ref R, ref HAVE, S, P);
                    }
                }
            }
        }
    }
}
