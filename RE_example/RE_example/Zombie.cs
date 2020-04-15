using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RE_example.Model;

namespace RE_example
{
    abstract class ZombieBase : IComparable, IEnemy
    {
        public int Health { get; set; }
        public Position Pos { get; set; }

        public ZombieBase(int health, Position pos)
        {
            this.Health = health;
            this.Pos = pos;
        }
        public ZombieBase(Position pos)
        {
            this.Pos = pos;
        }
        public ZombieBase()
        {

        }

        public abstract int CompareTo(object obj);
        public override int GetHashCode()
        {
            return Math.Abs(this.GetType().GetHashCode());
        }
        public Type TypeName()
        {
            return this.GetType(); // to check polymorphism
        }
    }

    // src: https://gamerant.com/resident-evil-games-zombie-types/
    class TVirusZombie : ZombieBase, IZombie
    {
        public int BulletsToDie { get; set; }

        public override int CompareTo(object obj)
        {
            return BulletsToDie.CompareTo((obj as IZombie).BulletsToDie);
        }

        public void TakeDamage(int amount)
        {
            this.Health -= amount;
        }
    }

    class CVirusZombie : ZombieBase, IZombie
    {
        public int BulletsToDie { get; set; }
        public int KnifeHits { get; set; }

        public override int CompareTo(object obj)
        {
            return BulletsToDie.CompareTo((obj as IZombie).BulletsToDie);
        }

        public void TakeDamage(int amount)
        {
            this.Health -= (int) Math.Round( amount * 0.5 );
        }
    }

    class LasPlagasHostZombie : ZombieBase, IZombie
    {
        public int BulletsToDie { get; set; }
        public int damageCounter { get; private set; }

        public LasPlagasHostZombie()
        {
            damageCounter = 0;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int amount)
        {
            this.Health--; // decrease by 1
            if (++damageCounter == 3) // only every 3rd attemt is successfull
            {
                this.Health -= amount;
                damageCounter = 0;
            }
        }
    }

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

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int amount)
        {
            this.Health -= amount + new Random().Next(1, 10);
            if (++damageCounter == 4)
                this.Health += (int)(this.Health * 0.4);
        }
    }
}
