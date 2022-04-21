static class Program
{
    static void Main(string[] args)
    {
        List<Genom> genoms = new List<Genom>(Genom.MAX_GENOM_LIST);
        for (int i = 0; i < Genom.MAX_GENOM_LIST; i++)
        {
            genoms.Add(Genom.CreateGenom());
        }

        for (int i = 1; i < Genom.MAX_GENERATION + 1; i++)
        {
            // 評価
            for (int j = 0; j < Genom.GENOM_MUTATION; j++)
            {
                decimal evaluation = genoms[j].Evaluate();
                genoms[j].evaluation = evaluation;
            }

            List<Genom> elites = Genom.ElitesSelect(genoms);
            List<Genom> progenys = new List<Genom>();
            for (int j = 0; j < elites.Count - 1; j++)
            {
                List<Genom> cr=Genom.Crossover(elites[j], elites[j+1]);
                progenys.Add(cr[0]);
                progenys.Add(cr[1]);
            }

            genoms = Genom.NextGenerationGeneCreate(genoms, elites, progenys);

            Genom.Mutation(genoms);

            Genom.Sort(genoms);
            decimal max = genoms[0].Evaluate();
            decimal min = genoms[genoms.Count - 1].Evaluate();

            Console.WriteLine(i + "世代の結果　最大：" + max + "　最小：" + min);
        }
        Console.WriteLine("最も優れた個体：" + genoms[0].Evaluate());
    }
}
