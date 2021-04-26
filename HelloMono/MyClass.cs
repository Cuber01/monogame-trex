using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class MyClass
    {
        public string name;

        public MyClass()
        { name = "My First Class"; }

        public void ChangeName(string newName)
        { name = newName; }
    }
}