using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using datadrivenTest.GameOctopus.DrawClasss;

namespace datadrivenTest.GameOctopus.ObjectClasss
{
    class Player:UpdateObject
    {
        const float DAMEGE_WEIT = 2f;

        Stage stage;

        // プレイヤーの状態
        public Ready ready;

        public int position = 0;
        public int totalItems = 0;
        public bool getItem = false;

        // csvファイルに依存するパラメータ
        public float stock;
        public float moveResponse;
        public float getItemRespons;
        public float houseItemRespons;
        public int gohomePoint;

        public Player(Stage stage)
        {
            this.stage = stage;

            CsvUpdate();
            My.FileDataUpdater.Instance.AddUpdateAction("player.csv", CsvUpdate);
        }
        public void CsvUpdate()
        {
            var data = My.CsvControler.ReadCSV("config/player.csv");
            stock= float.Parse(data["stock"]["status"]);
            moveResponse = float.Parse(data["move_respons"]["status"]);
            getItemRespons = float.Parse(data["get_item_respons"]["status"]);
            houseItemRespons = float.Parse(data["house_item_weit"]["status"]);

            System.Diagnostics.Debug.WriteLine("playerのパラメータを更新しました");
        }

        public override void Update(GameTime time)
        {
            Control(time);
        }
        // 時間を保持する変数
        float moveWeit = 0;
        float getItemWeit = 0;
        float houseItemWeit = 0;
        float damegeWeit = 0;
        void Control(GameTime time)
        {
            // 宝取得
            if (getItemWeit > 0)
            {
                getItemWeit -= (float)time.ElapsedGameTime.TotalSeconds;
            }
            else if (position == stage.Size - 1)
            {
                if (MyXNA.InputManager.IsKeyDown(Keys.Right) || MyXNA.InputManager.IsKeyDown(Keys.D))
                {
                    ready = Ready.Geting;
                    totalItems++;
                    getItem = true;
                    getItemWeit = getItemRespons;
                    moveWeit = moveResponse;
                    return;
                }
            }

            if (houseItemWeit > 0)
            {
                houseItemWeit -= (float)time.ElapsedGameTime.TotalSeconds;
            }
            else if (position == 0)
            {
                // 船へ帰還
                if (getItem)
                {
                    ready = Ready.House;
                    totalItems += gohomePoint;
                    getItem = false;
                    houseItemWeit = houseItemRespons;
                    return;
                }
            }

            // 被ダメージ
            if (damegeWeit > 0)
            {
                ready = Ready.Damage;
                moveWeit = damegeWeit;
                damegeWeit -= (float)time.ElapsedGameTime.TotalSeconds;
            }
            else if(ready==Ready.Damage)
            {
                ready = Ready.Normal;
            }

            // 移動
            if (moveWeit <= 0)
            {
                if (getItemWeit <= 0 && houseItemWeit <= 0)
                    ready = Ready.Normal;

                if (MyXNA.InputManager.IsJustKeyDown(Keys.Left) || MyXNA.InputManager.IsJustKeyDown(Keys.A))
                {
                    if (position > 0)
                    {
                        ready = Ready.Normal;
                        moveWeit = moveResponse;
                        position--;
                    }
                }
                if (MyXNA.InputManager.IsJustKeyDown(Keys.Right) || MyXNA.InputManager.IsJustKeyDown(Keys.D))
                {
                    if (position < stage.Size - 1)
                    {
                        ready = Ready.Normal;
                        position++;
                        moveWeit = moveResponse;
                    }
                }

            }
            else
                moveWeit -= (float)time.ElapsedGameTime.TotalSeconds;

        }

        public void Injured()
        {
            getItem = false;
            stock--;

            damegeWeit = DAMEGE_WEIT;
            ready = Ready.Damage;
            position = 0;
        }

    }

    enum Ready {
        Normal,
        Damage,
        House,
        Geting
    }
}
