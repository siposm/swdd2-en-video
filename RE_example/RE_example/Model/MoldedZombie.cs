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
        public int damageCounter { get; private set; }

        public MoldedZombie(int bullets)
        {
            this.BulletsToDie = bullets;
            damageCounter = 0;
        }
        public MoldedZombie(int health, Position pos)
            : base(health, pos)
        {
            damageCounter = 0;
        }
        public MoldedZombie()
        {
            damageCounter = 0;
        }

        public void TakeDamage(int amount)
        {
            this.Health -= amount + new Random().Next(1, 10);
            if (++damageCounter == 4)
                this.Health += (int)(this.Health * 0.4);

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
