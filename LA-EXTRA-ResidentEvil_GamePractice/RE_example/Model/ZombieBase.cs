using RE_example.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example.Model
{
    // Various types of zombies can be found here: https://gamerant.com/resident-evil-games-zombie-types/

    abstract class ZombieBase : IComparable, IEnemy
    {
        public bool Dead { get; set; }
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

        public event EnemyHealthCritical_EventHandler EnemyHealthCritical;
        public event EnemyDeath_EventHandler EnemyDied;

        protected virtual void OnCriticalLevel(EnemyCriticalLevelEventArgs ecleargs)
        {
            if (!this.Dead)
                EnemyHealthCritical?.Invoke(this, ecleargs);
        }

        protected virtual void OnDied(EnemyDeathEventArgs edeargs)
        {
            if(!this.Dead)
            {
                this.Dead = true;
                EnemyDied?.Invoke(this, edeargs);
            }
        }

        public override int GetHashCode()
        {
            return Math.Abs(this.GetType().GetHashCode());
        }
        public Type TypeName()
        {
            return this.GetType(); // only to check polymorphism
        }

        public int CompareTo(object obj)
        {
            return this.GetHashCode().CompareTo((obj as ZombieBase).GetHashCode());
        }

        public override string ToString()
        {
            return $"[ {GetHashCode()} ] - {TypeName().ToString().Split('.')[2]} - Health: {Health} - Position: {Pos.PosX},{Pos.PosY}";
        }
    }
}
