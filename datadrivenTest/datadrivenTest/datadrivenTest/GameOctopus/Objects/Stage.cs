using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace datadrivenTest.GameOctopus
{
    public class Stage
    {
        const float CLEAR_WEIT_TIME = 3;

        delegate void ObjectUpdates(GameTime time);
        ObjectUpdates tentacleUpdates;
        Action initializeEvent;

        public Player player;
        public List<Tentacle> tentacles;

        int stageId = 0;
        public int Id
        {
            get { return stageId; }
        }
        int maxId = 0;
        public int clearPoint = 0;
        public bool gameover = false;
        bool gameClear = false;
        public bool GameClear {
            get { return gameClear; }
            set { gameClear = value;
                if (value)
                    clearWeitTime = CLEAR_WEIT_TIME;
            }
        }

        float clearWeitTime = 0;

        public Stage(Action initializeEvent)
        {
            this.initializeEvent = initializeEvent;

            player = new Player();
            player.updateAction += ClearCheck;

            LoadCSV(int.Parse(Utility.ReadCSV("stage_select.csv")["0"]["stage"]));
        }
        public Stage(int id, Action initializeEvent)
        {
            this.initializeEvent = initializeEvent;

            player = new Player();
            player.updateAction += ClearCheck;

            LoadCSV(id);
        }
        public void LoadCSV(int id)
        {
            var data = Utility.ReadCSV("stage.csv");
            var dataClearPoint = Utility.ReadCSV("stage_clear_point.csv");

            maxId = data.Count;
            stageId = id > maxId ? maxId - 1 : id;
            clearPoint = int.Parse(dataClearPoint[stageId.ToString()]["clear_point"]);

            tentacles = new List<Tentacle>(data.Count);

            for (int i = 0; i < data[stageId.ToString()].Count; i++)
            {
                // 触手を生成
                int tentcleId = int.Parse(data[stageId.ToString()][i.ToString()]);
                Tentacle tentacle = new Tentacle(tentcleId, this);
                if (tentcleId != 0)
                    tentacleUpdates += tentacle.Update;
                tentacles.Add(tentacle);
            }

        }

        public void Update(GameTime time)
        {
            if (gameover) return;
            if (GameClear)
            {
                if (clearWeitTime > 0)
                    clearWeitTime -= Game1.gameTime;
                else if (stageId + 1 != maxId)
                    initializeEvent();

                return;
            }

            player.Update(time, this);
            tentacleUpdates(time);

            if (HitCheck())
            {
                gameover = true;
            }

        }
        /// <summary>
        /// 残機がなくなっていたらtrue
        /// </summary>
        /// <returns></returns>
        private bool HitCheck()
        {
            if (tentacles[player.position].active && tentacles[player.position].Step == tentacles[player.position].maxStep)
            {
                System.Diagnostics.Debug.WriteLine("ヒット");
                player.Injured();

                if (player.stock <= 0)
                    return true;
            }
            return false;
        }
        public void ClearCheck()
        {
            if (player.totalItems >= clearPoint)
            {
                GameClear = true;
            }
        }

        public Stage NextStage()
        {
            return new Stage(stageId+1, initializeEvent);
        }
    }
}
