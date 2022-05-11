using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace datadrivenTest.GameOctopus
{
    class Stage
    {
        delegate void ObjectUpdates(GameTime time);
        ObjectUpdates objectUpdates;

        public Player player;
        public List<Tentacle> tentacles;

        public bool gameover = false;

        public Stage()
        {
            player = new Player();

            var data = Utility.ReadCSV("stage.csv");
            tentacles = new List<Tentacle>(data.Count);

            for (int i = 0; i < data.Count; i++)
            {
                // 触手を生成
                int id = int.Parse(data[i.ToString()]["enemy"]);
                Tentacle tentacle = new Tentacle(id, this);
                if (id != 0)
                    objectUpdates += tentacle.Update;
                tentacles.Add(tentacle);
            }
        }

        public void Update(GameTime time)
        {
            if (gameover) return;

            player.Update(time, this);
            objectUpdates(time);

            if (HitCheck())
            {
                gameover = true;
            }

        }


        private bool HitCheck()
        {
            for (int i = 0; i < tentacles.Count; i++)
            {
                if (tentacles[i].maxStep!=0&&tentacles[i].Step == tentacles[i].maxStep && i == player.position)
                {
                    System.Diagnostics.Debug.WriteLine("ヒット");
                    player.Damage();

                    return true;
                }
            }
            return false;
        }
    }
}
