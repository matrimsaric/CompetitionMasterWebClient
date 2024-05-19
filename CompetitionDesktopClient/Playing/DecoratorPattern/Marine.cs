using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionDesktopClient.Playing.DecoratorPattern
{
    public class Marine : IInfantry
    {
        public int GetArmor()
        {
            return 0;
        }
        public int GetDamage()
        {
            return 6;
        }
    }
}
