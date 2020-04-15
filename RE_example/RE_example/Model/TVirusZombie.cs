using RE_example.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example.Model
{
    class TVirusZombie : ZombieBase, IZombie
    {
        public int BulletsToDie { get; set; }

        public event EnemyHealthCritical_EventHandler EnemyHealthCritical;
        public event EnemyDeath_EventHandler EnemyDied;

        public void TakeDamage(int amount)
        {
            this.Health -= amount;
        }
    }
}
