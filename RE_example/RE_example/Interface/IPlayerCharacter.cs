using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE_example.Interface
{
    public interface IPlayerCharacter : IComparable
    {
        string Name { get; set; }
        int Health { get; set; }
        void Attack(IEnemy enemyToBeAttacked);
    }
}
