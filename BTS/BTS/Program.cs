using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS
{
    enum Projects
    {
        Marketing,
        SupplyChain,
        InfTechnology,
        HumanResource,
        Networking,
        Research
    }

    class Person
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return (obj as Person).Name.Equals(this.Name);
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }

    class Program
    {
        static bool Ft(int level, Person x) { return true; }

        static bool Fk(Person[] results, int level, Person x)
        {
            for (int i = 0; i < level; i++)
                if (results[i].Equals(x))
                    return false;

            return true;
        }

        static void BTS(int level, ref Person[] R, ref bool HAVE, int[] S, Person[,] P)
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
                            BTS(level + 1, ref R, ref HAVE, S, P);
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            Person[,] P = new Person[6, 3];

            // MARKETING
            P[0, 0] = new Person() { Name = "Claudia" };
            P[0, 1] = new Person() { Name = "Mike" };

            // SUPPLY CHAIN
            P[1, 0] = new Person() { Name = "Mike" };
            P[1, 1] = new Person() { Name = "Zack" };

            // IT
            P[2, 0] = new Person() { Name = "Andrew" };

            // HR
            P[3, 0] = new Person() { Name = "Zack" };
            P[3, 1] = new Person() { Name = "Peter" };
            P[3, 2] = new Person() { Name = "Andrew" };

            // NETWORKING
            P[4, 0] = new Person() { Name = "Gregor" };
            P[4, 1] = new Person() { Name = "Andrew" };

            // RESEARCH
            P[5, 0] = new Person() { Name = "Mike" };
            P[5, 1] = new Person() { Name = "Gregor" };


            int[] S = { 1, 1, 0, 2, 1, 1 };

            Person[] R = new Person[6];

            bool van = false;

            BTS(0, ref R, ref van, S, P);



            string[] projects = Enum.GetNames(typeof(Projects));

            for (int i = 0; i < R.Length; i++)
            {
                Console.WriteLine("\tPROJECT: {0} \tPERSON: {1}",
                    projects[i],
                    R[i]);
            }




            Console.WriteLine("\n\n\n");
        }
    }

}
