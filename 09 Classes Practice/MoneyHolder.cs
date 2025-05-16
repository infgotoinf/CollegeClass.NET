using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Classes_Practice
{
    public class MoneyHolder
    {
        public int money;
        public int moneyGet()
        { return this.money; }
        public void moneySet(int money)
        { this.money = money; }
        public MoneyHolder(int money)
        {
            this.money = money;
        }
    }
}
