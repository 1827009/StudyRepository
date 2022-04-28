
struct Cashs
{
    public int[] quantity={0,0,0,0,0,0,0,0,0};
    public static readonly int[] Worth={10000,5000,1000,500,100,50,10,5,1};

    public Cashs(int moneyStock = 0)
    {
        for (int i = 0; i < quantity.Length; i++)
        {
            quantity[i]=moneyStock;
        }
    }

    public static Cashs ScalarToCashs(int scalar)
    {
        Cashs result = new Cashs(0);
        for (int i = 0; i < Cashs.Worth.Length; i++)
        {
            result.quantity[i] = (int)(scalar / Cashs.Worth[i]);
            scalar %= Cashs.Worth[i];
        }
        return result;
    }
    public static int CashsToScalar(Cashs cashs)
    {
        int result = 0;
        foreach (int i in cashs.quantity)
        {
            result += i * Cashs.Worth[i];
        }
        return result;
    }

    public static Cashs operator +(Cashs a, Cashs b)
    {
        Cashs result = new Cashs(0);
        for (int i = 0; i < Cashs.Worth.Length; i++)
        {
            result.quantity[i] = a.quantity[i] + b.quantity[i];
        }
        return result;
    }
    public static Cashs operator -(Cashs a, int b)
    {
        Cashs result = new Cashs(0);
        for (int i = 0; i < Cashs.Worth.Length; i++)
        {
            result.quantity[i] = (int)(b / Cashs.Worth[i]);
            a.quantity[i] -= result.quantity[i];
            b %= Cashs.Worth[i];

            if (a.quantity[i] < 0)
            {
                b += Math.Abs(a.quantity[i]) * Cashs.Worth[i];
                result.quantity[i] -= Math.Abs(a.quantity[i]);
                a.quantity[i] = 0;
            }
        }
        if (b > 0)
            throw new MoneyOfOut();

        return a;
    }
    public static Cashs operator -(Cashs a, Cashs b)
    {
        Cashs result = new Cashs(0);
        for (int i = 0; i < Cashs.Worth.Length; i++)
        {
            result.quantity[i]=a.quantity[i]-b.quantity[i];
            if(result.quantity[i]<0)
                throw new MoneyOfOut();
        }

        return result;
    }
}
