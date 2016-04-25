using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class BodySlam : Finisher
    {
        public BodySlam()
        {
            string finisher = "The crushing body slam.";
        }

        public override int buildFinisher()
        { return 12; }
    }
}
