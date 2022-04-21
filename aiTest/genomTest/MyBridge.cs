// 参考サイト:https://qiita.com/Azunyan1111/items/975c67129d99de33dc21

// 素材
class Genom
{
    public const int GENOM_LENGTH = 100;
    public const int MAX_GENOM_LIST = 100;
    public const int SELECT_GENOM = 20;
    public const decimal INDIVIDUAL_MUTATION = 0.01m;
    public const decimal GENOM_MUTATION = 0.01m;
    public const int MAX_GENERATION = 40;
    static Random random = new Random();

    public List<bool> genomArrey;
    public decimal evaluation;
    public Genom(List<bool> glist, int ev)
    {
        genomArrey = glist;
        evaluation = ev;
    }

    public static Genom CreateGenom(int length = GENOM_LENGTH)
    {
        List<bool> ge = new List<bool>(GENOM_LENGTH);
        for (int i = 0; i < length; i++)
        {
            ge.Add(random.Next(2) == 1);
        }
        return new Genom(ge, 0);
    }

    // 評価
    public decimal Evaluate()
    {
        return Evaluate(this);
    }
    public decimal Evaluate(Genom genom)
    {
        decimal total = 0;

        for (int i = 0; i < GENOM_LENGTH; i++)
        {
            if (genom.genomArrey[i])
                total++;
        }
        total /= GENOM_LENGTH;

        return total;
    }

    // エリート遺伝子達を抽出
    public static List<Genom> ElitesSelect(List<Genom> genoms, int genomListLength = SELECT_GENOM)
    {
        genoms.Sort(SortConditions);
        Genom[] output = new Genom[genomListLength];
        genoms.CopyTo(0, output, 0, genomListLength);

        return new List<Genom>(output);
    }
    public static void Sort(List<Genom> genoms){
        genoms.Sort(SortConditions);
    }
    static int SortConditions(Genom a, Genom b)
    {
        decimal x = a.Evaluate() - b.Evaluate();
        if (x < 0)
            return 1;
        else if (x > 0)
            return -1;
        return 0;
    }

    // 子孫を生成
    public static List<Genom> Crossover(Genom genom1, Genom genom2)
    {
        List<bool> secondGenomList = new List<bool>(GENOM_LENGTH);

        // 遺伝子を入れ替える境目を決定
        int crossOne = random.Next(0, GENOM_LENGTH);
        int crossSecond = random.Next(crossOne, GENOM_LENGTH);

        bool[] progeny1 = new bool[GENOM_LENGTH];
        bool[] progeny2 = new bool[GENOM_LENGTH];

        // 交叉する
        genom1.genomArrey.CopyTo(0, progeny1, 0, crossOne);
        genom2.genomArrey.CopyTo(crossOne, progeny1, crossOne, crossSecond - crossOne);
        genom1.genomArrey.CopyTo(crossSecond, progeny1, crossSecond, GENOM_LENGTH - crossSecond);

        genom2.genomArrey.CopyTo(0, progeny2, 0, crossOne);
        genom1.genomArrey.CopyTo(crossOne, progeny2, crossOne, crossSecond - crossOne);
        genom2.genomArrey.CopyTo(crossSecond, progeny2, crossSecond, GENOM_LENGTH - crossSecond);

        List<Genom> genoms = new List<Genom>(2);
        genoms.Add(new Genom(new List<bool>(progeny1), 0));
        genoms.Add(new Genom(new List<bool>(progeny2), 0));

        return genoms;
    }

    // 突然変異！
    public static  List<Genom> Mutation(List<Genom> genoms, decimal individualMutation = INDIVIDUAL_MUTATION, decimal genomMutation = GENOM_MUTATION)
    {
        List<Genom> output = new List<Genom>();
        for (int i = 0; i < genoms.Count; i++)
        {
            if (individualMutation < (random.Next(0, 100) / 100.0m))
            {
                for (int j = 0; j < genoms[i].genomArrey.Count; j++)
                {
                    if (genomMutation > (random.Next(0, 100) / 100.0m))
                    {
                        genoms[i].genomArrey[j] = random.Next(2) == 1;
                    }
                }
                output.Add(genoms[i]);
            }
        }

        return output;
    }

    // そして次世代へ
    public static  List<Genom> NextGenerationGeneCreate(List<Genom> genoms, List<Genom> elites, List<Genom> progenys)
    {
        Genom[] output = new Genom[genoms.Count];

        genoms.Sort(SortConditions);
        genoms.Reverse();
        genoms.CopyTo(0, output, 0, genoms.Count);
        elites.CopyTo(0, output, 0, elites.Count);
        progenys.CopyTo(0, output, elites.Count, progenys.Count);

        return new List<Genom>(output);
    }
}