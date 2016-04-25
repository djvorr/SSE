using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Titans
{
    public class Portal
    {
        Character character;
        public Location location;
        private static int HOME = 0;
        private static int TEMPLE = 1;
        private static int LAIR = 2;

        public TeleportBehavior getPortal(int portal)
        {
            if (portal == HOME)
                return new HomeTeleport();
            else if (portal == TEMPLE)
                return new TempleTeleport();
            else if (portal == LAIR)
                return new LairTeleport();

            else return null;
        }

        public void setLocation(Location location)
        { this.location = location; }

        public void Draw()
        {
            Console.WriteLine("Stub for the graphics drawing.");
        }
    }
}
