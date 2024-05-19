using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CompetitionDesktopClient.Playing.DecoratorPattern
{
    public class WeaponUpgrade : InfantryDecorator
    {
        public WeaponUpgrade(IInfantry infantry) : base(infantry)
        {
        }


        public override int GetDamage()
        {
            return base.GetDamage() + 1;
        }
    }
}
