using RE_example.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example
{
    public interface IGameLogic
    {
        void AddEnemy(IEnemy enemy);
        void RemoveEnemy(IEnemy enemy);
        void GenerateEnemies();
        IEnemy[] GetEnemiesToArray();
    }
}
