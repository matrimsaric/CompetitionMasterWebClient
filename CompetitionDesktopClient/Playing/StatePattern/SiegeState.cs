using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionDesktopClient.Playing.StatePattern
{
    public class SiegeState : ISiegeTankState
    {
        public SiegeTank _siegeTank;

        public SiegeState(SiegeTank siegeTank)
        {
            _siegeTank = siegeTank;
        }

        public int GetDamage()
        {
            return 20;
        }

        public Boolean CanMove()
        {
            return false;
        }

        public Color GetColor()
        {
            return Color.Red;
        }
    }
}
