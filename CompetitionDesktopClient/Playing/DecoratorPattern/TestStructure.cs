using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionDesktopClient.Playing.DecoratorPattern
{
    public class TestStructure
    {

        public void WorkIt()
        {
            IInfantry marine1 = new Marine();

            int d1 = marine1.GetDamage();
            int d2 = marine1.GetArmor();

            marine1 = new WeaponUpgrade(marine1);
            int d3 = marine1.GetDamage();
            int d4 = marine1.GetArmor();
        }
    }
}
