class Business
{
    // データクラス
    public Account account = new Account(10000);
    public Passbook passbook = new Passbook();

    // 処理クラス
    public Cashs cashs = new Cashs(10000);
    public Transaction transaction;
    public Calender calender = new Calender();

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