using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace datadrivenTest.GameOctopus.ObjectClasss
{
    class Stage
    {
        // ステージをクリアしてから次に移るまでの時間
        const float CLEAR_WEIT_TIME = 3;
        // ステージ1ページの大きさ
        public const int STAGE_SIZE = 5;

        delegate void ObjectUpdates(GameTime time);
        Action initializeEvent;

        public int size;
        public int Size { get { return size; } }

        public Player player;
        public List<Octopus> enemy;

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
            Initialize(int.Parse(Utility.ReadCSV("config\\stage_select.csv")["0"]["stage"]), initializeEvent);
        }
        public Stage(int id, Action initializeEvent)
        {
            Initialize(id, initializeEvent);
        }

        void Initialize(int id, Action initializeEvent)
        {
            this.initializeEvent = initializeEvent;
            player = new Player(this);

            LoadCSV(id);
        }
        public void LoadCSV(int id)
        {
            var data = Utility.ReadCSV("config/stage.csv");

            enemy = new List<Octopus>();
            for (int i = 0; i < int.Parse(data[id.ToString()]["size"]); i++)
            {
                enemy.Add(new Octopus(this, Octopus.TENTACLE_COUNT * i + 1));
            }
            size = int.Parse(data[id.ToString()]["size"]) * STAGE_SIZE + 1;
            clearPoint = int.Parse(data[id.ToString()]["clear_point"]);
            maxId = data.Count;
            stageId = id > maxId ? maxId - 1 : id;
            System.Diagnostics.Debug.WriteLine("stageのパラメータを更新しました");
        }

        public void LoadCSVs()
        {
            if(InputManager.IsJustKeyDown(Keys.S)){
                this.initializeEvent();
            }
            if (InputManager.IsJustKeyDown(Keys.P))
            {
                player.LoadCSV();
            }
            if (InputManager.IsJustKeyDown(Keys.E))
            {
                foreach (var item in enemy)
                {
                    item.LoadCSV();
                }
            }
        }

        public void Update(GameTime time)
        {
            if (gameover) return;
            LoadCSVs();

            if (GameClear)
            {
                if (clearWeitTime > 0)
                    clearWeitTime -= Game1.gameTime;
                else if (stageId + 1 != maxId)
                    initializeEvent();
                else
                    gameover = true;
                return;
            }

            player.Update(time);
            if (player.ready != Ready.Damage)
            {
                foreach (var item in enemy)
                {
                    item.Update(time);
                }
            }

            if (HitCheck())
            {
                gameover = true;
            }

            if (player.totalItems > clearPoint) {
                GameClear = true;
            }

        }
        /// <summary>
        /// 残機がなくなっていたらtrue
        /// </summary>
        /// <returns></returns>
        private bool HitCheck()
        {
            foreach (var item2 in enemy)
            {
                foreach (var item in item2.tentacles)
                {
                    if (item.position == player.position && item.OnAttack)
                    {
                        System.Diagnostics.Debug.WriteLine("ヒット");
                        player.Injured();
                        item2.EatingMode(player);

                        if (player.stock < 0)
                            return true;
                    }
                }
            }
            return false;
        }

        public Stage StageSelect()
        {
            if (this.GameClear)
            {
                return new Stage(Id + 1, initializeEvent);
            }
            return new Stage(initializeEvent);
        }
    }
}
