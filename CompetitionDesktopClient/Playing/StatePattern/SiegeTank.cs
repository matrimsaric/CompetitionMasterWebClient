using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionDesktopClient.Playing.StatePattern
{
    public class SiegeTank
    {
        public ISiegeTankState state;
        public TankState tankState;
        public SiegeState siegeState;

        public SiegeTank()
        {
            tankState = new TankState(this);
            siegeState = new SiegeState(this);
            ToTankMode();

            int dmg = state.GetDamage();
            Color col = state.GetColor();


            ToSiegeMode();
            int newDmg = state.GetDamage();
            Color newCol = state.GetColor();
        }

        public void ToTankMode()
        {
            state = tankState;
        }

        public void ToSiegeMode()
        {
            state = siegeState;
        }
    }
}
