using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTF2_Graf
{
    class Person
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public Person(string Name)
        {
            this.Name = Name;
        }
    }
}
