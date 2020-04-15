using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example
{
    class Program
    {
        static void Main(string[] args)
        {
            ZombieBase[] zs = new ZombieBase[3];

            zs[0] = new TVirusZombie() { Health = 70, BulletsToDie = 6 };
            zs[1] = new CVirusZombie();
            zs[2] = new MoldedZombie();

            foreach (var item in zs)
                Console.WriteLine(item.TypeName());

            foreach (var item in zs)
                Console.WriteLine(item.GetHashCode());

            Console.WriteLine("--------------");

            MoldedZombie mz = new MoldedZombie();
            mz.Health = 100;
            for (int i = 0; i < 5; i++)
            {
                mz.TakeDamage(10);
                Console.WriteLine("[{0}] HEALTH STATUS: " + mz.Health, i);
            }
        }
    }
}
