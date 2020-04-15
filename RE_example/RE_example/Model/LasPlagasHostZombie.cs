using RE_example.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example.Model
{
    class LasPlagasHostZombie : ZombieBase, IZombie
    {
        public int BulletsToDie { get; set; }
        public int damageCounter { get; private set; }

        public LasPlagasHostZombie()
        {
            damageCounter = 0;
        }

        public void TakeDamage(int amount)
        {
            this.Health--;
            if (++damageCounter == 3) // decrease by on BUT only every 3rd attemt is successfully hits
            {
                this.Health -= amount;
                damageCounter = 0;
            }

            if (this.Health < 0)
                base.OnDied(new EnemyDeathEventArgs()
                {
                    DiedEnemy = this
                });
        }

        public void BiteAttack(IPlayerCharacter player)
        {
            throw new NotImplementedException();
        }
    }
}
