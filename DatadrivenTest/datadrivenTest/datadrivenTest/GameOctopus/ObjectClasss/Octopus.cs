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

        public Octopus(Stage stage, int position)
        {
            for (int i = 0; i < TENTACLE_COUNT; i++)
            {
                this.tentacles.Add(new Tentacle(i, i + position));
            }
            tentacles[0] = new SpritTentacle(tentacles[0], tentacles[1], 2);
            tentacles[1] = new SpritTentacle(tentacles[1], tentacles[0], 2);


            My.FileDataUpdater.Instance.AddUpdateAction("enemy.csv", CsvUpdate);
        }
        public void CsvUpdate()
        {
            for (int i = 0; i < TENTACLE_COUNT; i++)
            {
                tentacles[i].CsvLoad(i);
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

            foreach (var item in tentacles)
            {
                item.Update(time);
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
