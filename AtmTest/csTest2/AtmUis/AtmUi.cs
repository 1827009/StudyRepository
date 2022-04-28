class AtmUi
{
    Business business = new Business();

    public void Draw()
    {
        Console.WriteLine("残高: " + business.account.money);
        Console.Write("ATM内: ");
        for (int i = 0; i < Cashs.Worth.Length; i++)
            Console.Write(Cashs.Worth[i] + "円: " + business.cashs.quantity[i] + "枚 | ");
        Console.WriteLine();
    }
    public void Control(string order, int value)
    {
        try
        {
            if (order == "drawer")
            {
                business.transaction.Drawer(value);
                Console.WriteLine(value + "円　引出");
            }
            else if (order == "deposit")
            {
                business.transaction.Deposit(value);
                Console.WriteLine(value + "円　預入");
            }
            else if (order == "print")
            {
                business.PrintPassbook();
                Console.WriteLine("通帳");
                Console.WriteLine(business.passbook.text);
            }
        }
        catch (MoneyOfOut)
        {
            Console.WriteLine("error：残高・ATM内の現金が足りない");
        }
    }
    public void Control(string order, int price, Cashs cashs)
    {
        try
        {
            if(order=="currency_exchange")
            {
                Cashs result = business.transaction.CurrencyExchange(cashs, price);
                for (int i = 0; i < Cashs.Worth.Length; i++)
                {
                    Console.WriteLine(Cashs.Worth[i]+"円が "+result.quantity+"枚");
                }
                Console.WriteLine("を引き出した");
            }
        }
        catch (MoneyOfOut)
        {
            Console.WriteLine("error：残高・ATM内の現金が足りない");
        }
    }
}