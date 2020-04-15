using RE_example.Interface;
using RE_example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example.Model
{
    class CVirusZombie : ZombieBase, IZombie
    {
        public int BulletsToDie { get; set; }
        public int KnifeHits { get; set; }

        public void BiteAttack(IPlayerCharacter player)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int amount)
        {
            this.Health -= (int)Math.Round(amount * 0.5);

            if (this.Health < 0)
                base.OnDied(new EnemyDeathEventArgs() { DiedEnemy = this });

            if (this.Health < (this.Health * 0.1))
                base.OnCriticalLevel(new EnemyCriticalLevelEventArgs() { Enemy = this });
        }
    }
}
