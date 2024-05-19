using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionDesktopClient.Playing.StatePattern
{
    public interface ISiegeTankState
    {
        public int GetDamage();

        public Boolean CanMove();

        public Color GetColor();
    }
}
