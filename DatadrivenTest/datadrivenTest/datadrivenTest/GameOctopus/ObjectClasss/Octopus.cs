using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace datadrivenTest.GameOctopus.ObjectClasss
{
    class Octopus : UpdateObject
    {
        public static readonly int TENTACLE_COUNT = 5;
        public EnemyReady ready = EnemyReady.Normal;

        public List<Tentacle> tentacles = new List<Tentacle>();

        int id = 0;

        public Octopus(Stage stage, int id, int position)
        {
            this.id = id;

            var data = My.CsvControler.ReadCSV("config/enemy.csv");
            for (int i = 0; i < TENTACLE_COUNT; i++)
            {
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
            var data = My.CsvControler.ReadCSV("config/enemy.csv");
            for (int i = 0; i < TENTACLE_COUNT; i++)
            {
                tentacles[i].CsvLoad(int.Parse(data[id.ToString()]["tentacle" + i]));
            }
            System.Diagnostics.Debug.WriteLine("enemyのパラメータを更新しました");
        }

        bool spritSwitch = false;
        bool switchStop = false;
        public override void Update(GameTime time)
        {
            base.Update(time);

            if (ready == EnemyReady.Attack)
            {
                ready = EnemyReady.Normal;
            }

            for (int i = 0; i < tentacles.Count; i++)
            {
                if ((i == 0 && spritSwitch) || (i == 1 && !spritSwitch)) continue;

                tentacles[i].Update(time);
            }
            if (!switchStop && ((tentacles[0].Step == 0 && !spritSwitch) || (tentacles[1].Step == 0 && spritSwitch)))
            {
                spritSwitch = !spritSwitch;
                switchStop = true;
            }
            else if (tentacles[0].Step == 1 || tentacles[1].Step == 1)
            {
                switchStop = false;
            }
        }

        public void EatingMode(Player player)
        {
            ready = EnemyReady.Attack;
            tentacles[2].Step = 2;
            if (tentacles[3].Step < 3)
                tentacles[3].Step = 3;

        }
    }
    enum EnemyReady
    {
        Normal,
        Attack
    }
}
