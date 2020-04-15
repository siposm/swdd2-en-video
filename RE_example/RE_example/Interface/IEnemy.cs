using RE_example.DataStructure;
using RE_example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example.Interface
{
    public delegate void EnemyDeath_EventHandler();
    public delegate void EnemyHealthCritical_EventHandler();

    public interface IEnemy
    {
        int Health { get; set; }
        Position Pos { get; set; }
        event EnemyHealthCritical_EventHandler EnemyHealthCritical;
        event EnemyDeath_EventHandler EnemyDied;
    }

    public interface IZombie : IEnemy
    {
        void TakeDamage(int amount);
        int BulletsToDie { get; set; } // how many bullets can it take before dying
        void BiteAttack(IPlayerCharacter player);
    }

    public interface IBossEnemy : IEnemy
    {
        void Heal();
    }

    public interface INemesis : IBossEnemy
    {
        ChainedList<IPlayerCharacter> KilledPlayers { get; set; }
    }

    public interface IMrX : IBossEnemy
    {

    }
}
