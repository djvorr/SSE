using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class LineFormationCommand : KnightCommand
    {
        Knights knights;
        Room room;
        Location heroLocation;
        KnightsIterator iter;

        public LineFormationCommand(Knights target, Room room, Location location)
        {
            knights = target;
            this.room = room;
            heroLocation = location;
            iter = new KnightsIterator(knights.getKnights());
        }

        public bool execute()
        {
            iter.reset();
            //facing east
            if (heroLocation.getDirection() == 1)
            {
                //if they all fit
                if (heroLocation.getX() - knights.Count() > 0)
                {
                    try
                    {
                        int curr = heroLocation.getX();
                        while (iter.hasNext())
                        {
                            iter.next().setLocation(
                                new Location(heroLocation.getX() - 1 - iter.getIndex(),
                                    heroLocation.getY(), heroLocation.getDirection()));
                        }

                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            }
            //west
            else if(heroLocation.getDirection() == 3)
            {
                //fit
                if (heroLocation.getX() + knights.Count() < room.getBounds().getBoundX())
                {
                    try
                    {
                        int curr = heroLocation.getX();
                        while (iter.hasNext())
                        {
                            iter.next().setLocation(
                                new Location(heroLocation.getX() + 1 + iter.getIndex(),
                                    heroLocation.getY(), heroLocation.getDirection()));
                        }

                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            }

            //north
            else if (heroLocation.getDirection() == 0)
            {
                //fit
                if (heroLocation.getY() + knights.Count() < room.getBounds().getBoundY())
                {
                    try
                    {
                        int curr = heroLocation.getY();
                        while (iter.hasNext())
                        {
                            iter.next().setLocation(
                                new Location(heroLocation.getX(), 
                                    heroLocation.getY() + 1 + iter.getIndex(),
                                    heroLocation.getDirection()));
                        }

                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }

            }
            //south
            else if (heroLocation.getDirection() == 2)
            {
                //fit
                if (heroLocation.getY() - knights.Count() > 0)
                {
                    try
                    {
                        int curr = heroLocation.getY();
                        while (iter.hasNext())
                        {
                            iter.next().setLocation(
                                new Location(heroLocation.getX(),
                                    heroLocation.getY() - 1 - iter.getIndex(),
                                    heroLocation.getDirection()));
                        }

                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }

            }
            return false;
            
        }
    }
}
