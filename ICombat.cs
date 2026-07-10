using System;
using System.Collections.Generic;
using System.Text;

namespace Colia
{
    internal interface ICombat
    {
        string Name { get; set; }
        int Hp { get; set; }
        int Atk { get; set; }
        int Def { get; set; }
        int MaxHp { get; set; }
        bool isDead { get; set; }

        void Damage(int TrueDamage);
        void Attack(Unit targets);
        void UseUltimate(List<Unit> team, List<Unit> boss);
    }
}
