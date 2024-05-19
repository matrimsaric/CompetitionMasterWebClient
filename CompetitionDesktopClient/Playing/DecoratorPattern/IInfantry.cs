using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionDesktopClient.Playing.DecoratorPattern
{
    public interface IInfantry
    {
        public int GetArmor();
        public int GetDamage();
    }
}
