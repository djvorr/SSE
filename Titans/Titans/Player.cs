using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class Player : Hero
    {
        Knights knights;
        KnightCommand commander;
        Room currentRoom;

        public Player(Room room)
        {
            currentRoom = room;
            knights = new Knights();
        }

        public void addKnight(Hero hero)
        { knights.addKnight(hero); }

        public void removeKnight(Hero hero)
        { knights.removeKnight(hero); }

        public void CommandLine()
        {
            commander = new LineFormationCommand(knights, 
                                                    currentRoom, 
                                                    this.location);
            commander.execute();
        }
    }
}
