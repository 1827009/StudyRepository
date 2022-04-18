class Program
{
    delegate int MyDelegate(string text);
    static void Main(string[] args)
    {
        MyDelegate myDelegate=new MyDelegate((new Samples()).Sample);
        myDelegate+=(new Samples()).Sample2;
        myDelegate+=(new Samples()).Sample3;

        myDelegate("SampleText");
    }

}
class Samples
{    
    public int Sample(string text){
        Console.WriteLine(text);
        return 1;
    }
    public int Sample2(string text){
        Console.WriteLine(text+"2");
        return 1;
    }
    public int Sample3(string text){
        Console.WriteLine(text+"3");
        return 1;
    }
}