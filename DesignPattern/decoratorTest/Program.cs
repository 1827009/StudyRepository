static class Program
{
    static void Main(string[] args)
    {
        StringDisplay display1=new StringDisplay("testText");
        display1.show();

        Display display2=new SideBorder(display1);
        display2.show();

        Display display3=new FullBorder(display2);
        display3.show();

        Display display4=
            new FullBorder(
                new SideBorder(
                    new FullBorder(
                        new StringDisplay("Hello japan")
                    )
                )
            );
        display4.show();
    }
}
