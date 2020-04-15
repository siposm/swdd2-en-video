using RE_example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example
{
    class CVirusZombie : ZombieBase, IZombie
    {
        public int BulletsToDie { get; set; }
        public int KnifeHits { get; set; }

        public void TakeDamage(int amount)
        {
            this.Health -= (int)Math.Round(amount * 0.5);
        }
    }
}
