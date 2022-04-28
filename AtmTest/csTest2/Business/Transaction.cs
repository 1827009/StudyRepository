class Transaction
{
    Business business;

    public Transaction(Business business)
    {
        this.business = business;
    }

    public void Drawer(int v)
    {
        if (business.account.money < v)
            throw new MoneyOfOut();

        business.cashs -= v;
        business.account.history.addLog(v + " 引出");
        business.account.money -= v;
    }

    public void Deposit(int v)
    {
        business.account.history.addLog(v + " 預入");
        business.account.money += v;
        business.cashs += Cashs.ScalarToCashs(v);
    }

    public Cashs CurrencyExchange(Cashs before, int after)
    {
        int amount = Cashs.CashsToScalar(before);
        Cashs result = new Cashs(0);

        if (amount % after > 0) return before;

        result.quantity[Array.IndexOf(Cashs.Worth, after)] = amount / after;
        
        business.cashs += before;
        business.cashs -= result;

        return result;
    }
}