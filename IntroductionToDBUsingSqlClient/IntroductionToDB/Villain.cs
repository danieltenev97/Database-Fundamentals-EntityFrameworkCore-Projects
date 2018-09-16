using System;
using System.Collections.Generic;
using System.Text;

namespace IntroductionToDBusingSQLCLIENT
{
    class Villain
    {
        private string Name { get; set; }
        private int NumberOfMinions { get; set; }

        public Villain(string name,int numberofminions)
        {
            this.Name = name;
            this.NumberOfMinions = numberofminions;
        }

        public override string ToString()
        {
            return $"{this.Name} -> {this.NumberOfMinions}";
        }
    }
}
