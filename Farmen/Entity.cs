using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen
{
    internal class Entity
    {
        public int Id { get; set; }
        public static int nextId = 1;

        public Entity()
        {
            Id = nextId;
            nextId++;
        }
    }
}
