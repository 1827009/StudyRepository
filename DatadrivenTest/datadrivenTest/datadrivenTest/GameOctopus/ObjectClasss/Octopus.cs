using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace datadrivenTest.GameOctopus.ObjectClasss
{
    class Octopus:UpdateObject
    {
        public static readonly int TENTACLE_COUNT = 5;
        public EnemyReady ready=EnemyReady.Normal;

        public List<Tentacle> tentacles = new List<Tentacle>();

        int id = 0;

        public Octopus(Stage stage, int id, int position)
        {
            this.id = id;

            var data = My.CsvControler.ReadCSV("config/enemy.csv");
            for (int i = 0; i < TENTACLE_COUNT; i++)
            {
                if (i == 1)
                    this.tentacles.Add(new SpritTentacle(int.Parse(data[id.ToString()]["tentacle" + i]), i + position, tentacles[0]));

                this.tentacles.Add(new Tentacle(int.Parse(data[id.ToString()]["tentacle" + i]), i + position));
            }

            tentacles[0].maxStep = 3;
            tentacles[1].maxStep = 4;
            tentacles[2].maxStep = 5;
            tentacles[3].maxStep = 4;
            tentacles[4].maxStep = 3;

            My.FileDataUpdater.Instance.AddUpdateAction("enemy.csv", CsvUpdate);
            My.FileDataUpdater.Instance.AddUpdateAction("tentacle.csv", CsvUpdate);
            My.FileDataUpdater.Instance.AddUpdateAction("tentacle_pattern.csv", CsvUpdate);
        }
        public void CsvUpdate()
        {

            for (int i = 0; i < TENTACLE_COUNT; i++)
            {
                tentacles[i].CsvLoad();
            }
            System.Diagnostics.Debug.WriteLine("enemyのパラメータを更新しました");
        }

        public override void Update(GameTime time)
        {
            base.Update(time);
                        
            if (ready == EnemyReady.Attack)
            {
                    ready = EnemyReady.Normal;
            }

            for (int i = 1; i < tentacles.Count; i++)
            {
                tentacles[i].Update(time);
            }

        }

        public void EatingMode(Player player)
        {
            ready = EnemyReady.Attack;
            tentacles[2].Step = 2;
        }
    }
    enum EnemyReady
    {
        Normal,
        Attack
    }
}
