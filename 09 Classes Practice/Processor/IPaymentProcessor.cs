using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Classes_Practice.Processor
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(ref MoneyHolder getter, ref MoneyHolder sender,
            int moneyAmmount)
        {
            MoneyHolder getterOld = getter;
            MoneyHolder senderOld = sender;

            getter.moneySet(getter.moneyGet() + moneyAmmount);
            sender.moneySet(sender.moneyGet() - moneyAmmount);

            if (getter.moneyGet() < 0 || sender.moneyGet() < 0)
            {
                RefundPayment(ref getter, ref sender, getterOld, senderOld);
            }
        }

        void RefundPayment(ref MoneyHolder getter, ref MoneyHolder sender,
            MoneyHolder getterOld, MoneyHolder senderOld)
        {
            getter.moneySet(getterOld.moneyGet());
            sender.moneySet(senderOld.moneyGet());
        }
    }
}
