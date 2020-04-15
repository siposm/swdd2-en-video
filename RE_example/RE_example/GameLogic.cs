using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RE_example.DataStructure;
using RE_example.Interface;
using RE_example.Model;

namespace RE_example
{
    class GameLogic : IGameLogic
    {
        public GameLogic()
        {
            Enemies = new ChainedList<IEnemy>();
            rand = new Random();
        }

        static Random rand;
        public ChainedList<IEnemy> Enemies { get; set; }

        public void AddEnemy(IEnemy enemy)
        {
            Enemies.InsertToBack(enemy);
        }

        public void GenerateEnemies()
        {
            for (int i = 0; i < 10; i++)
            {
                switch (rand.Next(1,5))
                {
                    case 1:
                        Insert_CVirusZombie();
                        break;
                    case 2:
                        Insert_LasPlagasHostZombie(); break;
                    case 3:
                        Insert_MoldedZombie(); break;
                    case 4:
                        Insert_TVirusZombie();
                        break;
                }
            }

            this.Subscribe();
        }

        private void Insert_CVirusZombie()
        {
            Enemies.InsertToBack(new CVirusZombie()
            {
                BulletsToDie = 10,
                KnifeHits = 23,
                Health = 90,
                Pos = new Position() { PosX = 10, PosY = 3 }
            });
        }

        private void Insert_LasPlagasHostZombie()
        {
            Enemies.InsertToBack(new LasPlagasHostZombie()
            {
                BulletsToDie = 14,
                Health = 80,
                Pos = new Position() { PosX = 22, PosY = 6 }
            });
        }

        private void Insert_MoldedZombie()
        {
            Enemies.InsertToBack(new MoldedZombie()
            {
                BulletsToDie = 50,
                Health = 100,
                Pos = new Position() { PosX = 3, PosY = 5 }
            });
        }

        private void Insert_TVirusZombie()
        {
            Enemies.InsertToBack(new TVirusZombie()
            {
                BulletsToDie = 4,
                Health = 100,
                Pos = new Position() { PosX = 4, PosY = 23 }
            });
        }

        private void Subscribe()
        {
            foreach (IEnemy item in Enemies)
                item.EnemyDied += OnEnemyDiedMethod;

            foreach (IEnemy item in Enemies)
                item.EnemyHealthCritical += OnEnemyCriticalLevel;
        }

        private void OnEnemyDiedMethod(object sender, EventArgs e)
        {
            Console.WriteLine($" >> EVENT LOG: { (e as EnemyDeathEventArgs).DiedEnemy } HAS DIED.");
        }

        private void OnEnemyCriticalLevel(object sender, EventArgs e)
        {
            Console.WriteLine($" >> EVENT LOG: { (e as EnemyCriticalLevelEventArgs).Enemy } HAS REACHED CRITICAL HEALTH LEVEL.");
        }

        public IEnemy[] GetEnemiesToArray()
        {
            return this.Enemies.CopyToArray();
        }

        public void RemoveEnemy(IEnemy enemy)
        {
            // TODO LATER
            throw new NotImplementedException();
        }
    }
}
