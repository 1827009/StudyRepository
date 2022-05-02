class Business
{
    // データクラス
    public Account account = new Account(10000);
    public Passbook passbook = new Passbook();
    public Cashs cashs = new Cashs(10000);
    
    // 処理用クラス
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