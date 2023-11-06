using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal abstract class Entity
    {
        public int Id { get; set; }
        public static int nextId = 1;
        public string Name { get; set; }

        public Entity(string name)
        {
            Id = nextId;
            nextId++;
            Name = name;
        }

        public abstract void GetDescription();       
    }
}
