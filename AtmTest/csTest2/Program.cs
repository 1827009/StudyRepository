static class Program
{
    static void Main(string[] args)
    {
        AtmUi ui = new AtmUi();

        // 取引用テスト命令
        ui.Draw();
        ui.Control("drawer", 10000);
        ui.Control("deposit", 10000);
        ui.Control("print", 10000);

        ui.Draw();
        ui.Control("drawer", 119000);
        ui.Control("deposit", 10000);
        ui.Control("print", 10000);

        Cashs cashs = new Cashs(0);
        cashs.quantity[2] = 10;
        ui.Control("currency_exchange", 5000, cashs);
    }


}
