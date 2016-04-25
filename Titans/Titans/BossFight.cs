using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class BossFight
    {
        Boss boss;
        List<Monster> minions;
        MonsterIterator iterator;

        public BossFight()
        {
            boss = new Boss();
            minions = new List<Monster>();
            iterator = new MonsterIterator(minions);
        }

        public bool isOver()
        { return iterator.isEmpty(); }

        public void removeDefeated()
        {
            iterator.reset();

            while (iterator.hasNext())
            {
                /*
                Monster monster = iterator.next();

                if (monster.isDead())
                    iterator.Remove();
                */

                if (iterator.next().isDead())
                    iterator.Remove();
            }
        }

        public void Add(Monster monster)
        {
            minions.Add(monster);
            iterator = new MonsterIterator(minions);
        }
    }
}
