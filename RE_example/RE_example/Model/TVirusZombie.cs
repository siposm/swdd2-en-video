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

        public void BiteAttack(IPlayerCharacter player)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int amount)
        {
            this.Health -= amount;

            if (this.Health < 0)
                base.OnDied(new EnemyDeathEventArgs()
                {
                    DiedEnemy = this
                });
        }
    }
}
