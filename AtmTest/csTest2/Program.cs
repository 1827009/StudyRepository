static class Program
{
    static void Main(string[] args)
    {
        AtmUi ui = new AtmUi();

        ui.Draw();
        ui.Control("drawer", 10000);
        ui.Control("deposit", 10000);
        ui.Control("print", 10000);

        ui.Draw();
        ui.Control("drawer", 119000);
        ui.Control("deposit", 10000);
        ui.Control("print", 10000);

        Cashs cashs = new Cashs(0);
        cashs.cashs[2].quantity = 10;
        ui.Control("currency_exchange", 5000, cashs);
    }


}
