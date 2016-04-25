using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    class MonsterIterator : Iterator
    {
        List<Monster> monsters;
        int index = 0;

        public MonsterIterator(List<Monster> monsters)
        {
            this.monsters = monsters;
        }

        public void reset()
        {
            index = 0;
        }

        public Monster next()
        {
            if (hasNext())
            {
                index += 1;
                return monsters[index];
            }

            return null;
        }

        public bool hasNext()
        { return !(index == monsters.Count - 1); }

        public bool isEmpty()
        { return monsters.Count == 0; }

        public void Add(Monster monster)
        {
            monsters.Insert(index, monster);
            index += 1;
        }

        public void Remove()
        {
            if (index > 0)
            {
                monsters.Remove(monsters[index]);
                index -= 1;
            }
        }

        public List<Monster> getMonsters()
        { return monsters; }
    }
}
