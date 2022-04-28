
struct Cashs
{
    public Cash[] cashs;

    public Cashs(int moneyStock = 0)
    {
        cashs = new Cash[9];
        cashs[0] = new Cash(10000, moneyStock);
        cashs[1] = new Cash(5000, moneyStock);
        cashs[2] = new Cash(1000, moneyStock);
        cashs[3] = new Cash(500, moneyStock);
        cashs[4] = new Cash(100, moneyStock);
        cashs[5] = new Cash(50, moneyStock);
        cashs[6] = new Cash(10, moneyStock);
        cashs[7] = new Cash(5, moneyStock);
        cashs[8] = new Cash(1, moneyStock);
    }

    public static Cashs ScalarToCashs(int scalar)
    {
        Cashs result = new Cashs(0);
        for (int i = 0; i < result.cashs.Length; i++)
        {
            result.cashs[i].quantity = (int)(scalar / result.cashs[i].Worth);
            scalar %= result.cashs[i].Worth;
        }
        return result;
    }
    public static int CashsToScalar(Cashs cashs)
    {
        int result = 0;
        foreach (Cash i in cashs.cashs)
        {
            result += i.quantity * i.Worth;
        }
        return result;
    }

    public static Cashs operator +(Cashs a, Cashs b)
    {
        Cashs result = new Cashs(0);
        for (int i = 0; i < a.cashs.Length; i++)
        {
            result.cashs[i].quantity = a.cashs[i].quantity + b.cashs[i].quantity;
        }
        return result;
    }
    public static Cashs operator -(Cashs a, int b)
    {
        Cashs result = new Cashs(0);
        for (int i = 0; i < a.cashs.Length; i++)
        {
            result.cashs[i].quantity = (int)(b / a.cashs[i].Worth);
            a.cashs[i].quantity -= result.cashs[i].quantity;
            b %= a.cashs[i].Worth;

            if (a.cashs[i].quantity < 0)
            {
                b += Math.Abs(a.cashs[i].quantity) * a.cashs[i].Worth;
                result.cashs[i].quantity -= Math.Abs(a.cashs[i].quantity);
                a.cashs[i].quantity = 0;
            }
        }
        if (b > 0)
            throw new MoneyOfOut();

        return a;
    }
    public static Cashs operator -(Cashs a, Cashs b)
    {
        Cashs result = new Cashs(0);
        for (int i = 0; i < a.cashs.Length; i++)
        {
            result.cashs[i].quantity=a.cashs[i].quantity-b.cashs[i].quantity;
            if(result.cashs[i].quantity<0)
                throw new MoneyOfOut();
        }

        return result;
    }
    public struct Cash
    {
        int worth;
        public int Worth
        {
            get { return worth; }
        }
        public int quantity = 0;

        public Cash(int worth, int quantity = 0)
        {
            this.worth = worth;
            this.quantity = quantity;
        }

        public static Cash operator +(Cash a, Cash b)
        {
            return new Cash(a.Worth, a.quantity + b.quantity * (a.Worth / b.Worth));
        }
    }
}
