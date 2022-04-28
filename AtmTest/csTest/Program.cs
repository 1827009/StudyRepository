static class Program
{
    static void Main(string[] args)
    {
        AtmUi ui=new AtmUi();

        ui.Draw();
        ui.Control("drawer", 10000);
        ui.Control("deposit", 10000);
        ui.Control("print", 10000);
        
        ui.Draw();
        ui.Control("drawer", 19000);
        ui.Control("deposit", 10000);
        ui.Control("print", 10000);
        
        ui.Draw();
        ui.Control("drawer", 119000);
        ui.Control("deposit", 10000);
        ui.Control("print", 10000);
    }

    
}
