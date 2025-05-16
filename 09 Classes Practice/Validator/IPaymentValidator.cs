using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Classes_Practice.Validator
{
    public interface IPaymentValidator
    {
        bool ValidatePayment(MoneyHolder getter, MoneyHolder getterOld,
            MoneyHolder sender, MoneyHolder senderOld, int moneyAmmount)
        {
            getterOld.moneySet(getterOld.moneyGet() + moneyAmmount);
            senderOld.moneySet(senderOld.moneyGet() - moneyAmmount);

            if (getterOld.moneyGet() == getter.moneyGet() ||
                senderOld.moneyGet() == sender.moneyGet())
                return true;
            else return false;
        }
    }
}
