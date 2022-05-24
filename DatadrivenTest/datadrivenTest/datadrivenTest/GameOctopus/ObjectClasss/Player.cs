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
        public const float HOUSE_ITEM_TIME = 2f;

        Stage stage;

        // プレイヤーの状態
        public Ready ready;

        public int Position { get; set; }
        public int TotalPoint { get; set; }
        // 帰還時得点の権利
        public bool getPoint = false;

        // csvファイルに依存するパラメータ
        public float stock;// 残機
        public float moveResponse;// 移動速度
        public float getItemRespons;// 得点所得速度

        public Player(Stage stage)
        {
            this.stage = stage;

            CsvUpdate();

            // ファイルが更新されると反映されるように
            My.FileDataUpdater.Instance.AddUpdateAction("player.csv", CsvUpdate);
        }
        public void CsvUpdate()
        {
            var data = My.CsvControler.ReadCSV("config/player.csv");
            stock= float.Parse(data["stock"]["status"]);
            moveResponse = float.Parse(data["move_respons"]["status"]);
            getItemRespons = float.Parse(data["get_item_respons"]["status"]);

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
            else if (Position == stage.Size - 1)
            {
                if (MyXNA.InputManager.IsKeyDown(Keys.Right) || MyXNA.InputManager.IsKeyDown(Keys.D))
                {
                    ready = Ready.Geting;
                    TotalPoint++;
                    getPoint = true;
                    getItemWeit = getItemRespons;
                    moveWeit = moveResponse;
                    return;
                }
            }

            if (houseItemWeit > 0)
            {
                houseItemWeit -= (float)time.ElapsedGameTime.TotalSeconds;
            }
            else if (Position == 0)
            {
                // 船へ帰還
                if (getPoint)
                {
                    ready = Ready.House;
                    TotalPoint += stage.gohomePoint;
                    getPoint = false;
                    houseItemWeit = HOUSE_ITEM_TIME;
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
                    if (Position > 0)
                    {
                        ready = Ready.Normal;
                        moveWeit = moveResponse;
                        Position--;
                    }
                }
                if (MyXNA.InputManager.IsJustKeyDown(Keys.Right) || MyXNA.InputManager.IsJustKeyDown(Keys.D))
                {
                    if (Position < stage.Size - 1)
                    {
                        ready = Ready.Normal;
                        Position++;
                        moveWeit = moveResponse;
                    }
                }

            }
            else
                moveWeit -= (float)time.ElapsedGameTime.TotalSeconds;

        }

        // 被ダメージ
        public void Injured()
        {
            getPoint = false;
            stock--;

            damegeWeit = DAMEGE_WEIT;
            ready = Ready.Damage;
            Position = 0;
        }

    }

    /// <summary>
    /// プレイヤーの状態
    /// </summary>
    enum Ready {
        Normal,
        Damage,
        House,
        Geting
    }
}
