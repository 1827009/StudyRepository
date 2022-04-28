class Business
{
    public Account account = new Account();
    public Calender calender = new Calender();
    public Passbook passbook = new Passbook();

    public Cashs cashs = new Cashs(10000);

    public Transaction transaction;

    public Business()
    {
        transaction = new Transaction(this);
    }

    public void PrintPassbook()
    {
        passbook.text = account.history.getLog();
    }
}

class MoneyOfOut : Exception
{

}