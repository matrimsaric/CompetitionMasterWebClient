using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionDesktopClient.Playing.DecoratorPattern
{
    public class InfantryDecorator :IInfantry
    {
        protected IInfantry _infantry;
        public InfantryDecorator(IInfantry infantry) 
        {
            _infantry = infantry;
        }

        public virtual int GetArmor()
        {
            return _infantry.GetArmor();
        }

        public virtual int GetDamage()
        {
            return _infantry.GetDamage();
        }
    }
}
