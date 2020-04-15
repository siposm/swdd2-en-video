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
        public int DamageCounter { get; private set; }

        public LasPlagasHostZombie()
        {
            DamageCounter = 0;
        }

        public void TakeDamage(int amount)
        {
            this.Health--;
            if (++DamageCounter == 3) // decrease by on BUT only every 3rd attemt is successfully hits
            {
                this.Health -= amount;
                DamageCounter = 0;
            }

            if (this.Health < 0)
                base.OnDied(new EnemyDeathEventArgs() { DiedEnemy = this });

            if (this.Health < (this.Health * 0.1))
                base.OnCriticalLevel(new EnemyCriticalLevelEventArgs() { Enemy = this });
        }

        public void BiteAttack(IPlayerCharacter player)
        {
            throw new NotImplementedException();
        }
    }
}
