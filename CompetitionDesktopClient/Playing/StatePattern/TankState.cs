using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionDesktopClient.Playing.StatePattern
{
    public class TankState : ISiegeTankState
    {
        public SiegeTank _siegeTank;

        public TankState(SiegeTank siegeTank)
        {
            _siegeTank = siegeTank;
        }

        public int GetDamage()
        {
            return 10;
        }

        public Boolean CanMove()
        {
            return true;
        }

        public Color GetColor()
        {
            return Color.Green;
        }
    }
}
