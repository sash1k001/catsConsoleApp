using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Cat : ICat
    {
        private string _Name = null!;
        private int _Energy = 0;
        public string getName()
        {
            return _Name;
        }
        public void setName(string name)
        {
            _Name = name;
        }

        public int getEnergy()
        {
            return _Energy;
        }

        public void Eat()
        {
            _Energy += 25;
        }

        public string Meow()
        {
            return "мррррмррррррмрррр...";
        }
    }
}