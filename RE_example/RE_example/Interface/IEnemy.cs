using RE_example.DataStructure;
using RE_example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example.Interface
{
    public delegate void EnemyDeath_EventHandler(object sender, EventArgs args);
    public delegate void EnemyHealthCritical_EventHandler();

    public class EnemyDeathEventArgs : EventArgs
    {
        public IEnemy DiedEnemy { get; set; }
    }

    public interface IEnemy : IComparable
    {
        bool Dead { get; set; }
        int Health { get; set; }
        Position Pos { get; set; }
        event EnemyHealthCritical_EventHandler EnemyHealthCritical;
        event EnemyDeath_EventHandler EnemyDied;
    }

    public interface IZombie : IEnemy
    {
        int BulletsToDie { get; set; } // how many bullets can it take before dying
        void TakeDamage(int amount);
        void BiteAttack(IPlayerCharacter player);
    }

    public interface IBossEnemy : IEnemy
    {
        void Heal();
        ChainedList<IPlayerCharacter> KilledPlayers { get; set; }
    }
}
