using RE_example.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example.Model
{
    class MoldedZombie : ZombieBase, IZombie
    {
        public int BulletsToDie { get; set; }
        public int DamageCounter { get; private set; }

        public MoldedZombie(int bullets)
        {
            this.BulletsToDie = bullets;
            DamageCounter = 0;
        }
        public MoldedZombie(int health, Position pos)
            : base(health, pos)
        {
            DamageCounter = 0;
        }
        public MoldedZombie()
        {
            DamageCounter = 0;
        }

        public void TakeDamage(int amount)
        {
            this.Health -= amount + new Random().Next(1, 10);
            if (++DamageCounter == 4)
                this.Health += (int)(this.Health * 0.4);

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
