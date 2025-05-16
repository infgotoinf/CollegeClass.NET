using _09_Classes_Practice;

void PayPalProcessor(ref MoneyHolder getter, ref MoneyHolder sender, int moneyAmmount)
{
    ProcessPayment(getter, sender, moneyAmmount);
};

bool CreditCardProcessor(ref MoneyHolder getter, ref MoneyHolder sender, int moneyAmmount)
{
    MoneyHolder getterOld = getter;
    MoneyHolder senderOld = sender;
    ProcessPayment(getter, sender, moneyAmmount);
    return ValidatePayment(getter, getterOld, sender, senderOld, moneyAmmount);
};

void CryptoCurrencyProcessor(ref MoneyHolder getter, ref MoneyHolder sender, int moneyAmmount)
{
    ProcessPayment(getter, sender, moneyAmmount);
};

class Program
{
    static int main()
    {
        MoneyHolder loh1;
        MoneyHolder loh2;
        return 0;
    }
}