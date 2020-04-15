using RE_example.DataStructure;
using RE_example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example
{
    // Interfaces for model classes
    // --------------------------------------------
    public interface IEnemy
    {
        int Health { get; set; }
        Position Pos { get; set; }
    }

    public interface IBossEnemy : IEnemy
    {
        void Attack();
    }

    public interface IZombie : IEnemy
    {
        void TakeDamage(int amount);
        int BulletsToDie { get; set; } // how many bullets can it take before dying
    }

    public interface INemesis : IBossEnemy
    {
        ChainedList<IPlayerCharacter> KilledPlayers { get; set; }
    }

    public interface IMrX : IBossEnemy
    {

    }

    // Interfaces for data structures
    // --------------------------------------------
    public interface DataStructureLogic
    {
        void InsertItem();
        void RemoveItem();
    }


    // Interfaces for logic
    // --------------------------------------------
    public interface IGameLogic
    {
        void AddEnemy(IEnemy enemy);
        void RemoveEnemy(IEnemy enemy);
        void GenerateEnemies();
        List<IEnemy> GetEnemies();
    }

    // Interfaces for player classes
    // --------------------------------------------
    public interface IPlayerCharacter : IComparable
    {

    }
}
