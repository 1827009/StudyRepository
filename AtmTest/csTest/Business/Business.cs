class Business
{
    public Account account = new Account();
    public Calender calender = new Calender();
    public Passbook passbook = new Passbook();

    public Cashs cashs = new Cashs(1);

    public void Drawer(int v)
    {
        if (account.money < v)
            throw new MoneyOfOut();

        cashs -= v;
        account.history.addLog(v + " 引出");
        account.money += v;
    }

    public void Deposit(int v)
    {
        account.history.addLog(v + " 預入");
        account.money += v;
        cashs += Cashs.ScalarToCashs(v);
    }

    public void PrintPassbook()
    {
        passbook.text = account.history.getLog();
    }
}

class MoneyOfOut : Exception
{

}