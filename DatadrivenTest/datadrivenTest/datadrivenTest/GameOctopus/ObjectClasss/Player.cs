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
        const float BLINKING_TIME = 0.25f;
        const float DAMEGE_WEIT = 2f;

        Stage stage;


        public Ready states;

        public int position = 0;
        public int totalItems = 0;
        public bool getItem = false;

        public float stock;
        public readonly float moveResponse;
        public readonly float getItemRespons;
        public readonly float houseItemRespons;

        public Player(Stage stage)
        {
            this.stage = stage;

            var data = Utility.ReadCSV("player.csv");
            stock= float.Parse(data["stock"]["status"]);
            moveResponse = float.Parse(data["move_respons"]["status"]);
            getItemRespons = float.Parse(data["get_item_respons"]["status"]);
            houseItemRespons = float.Parse(data["house_item_weit"]["status"]);
        }

        public override void Update(GameTime time)
        {
            Control(time);
        }
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
            else if (position == stage.size - 1)
            {
                if (InputManager.IsKeyDown(Keys.Right) || InputManager.IsKeyDown(Keys.D))
                {
                    states = Ready.Geting;
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
                    states = Ready.House;
                    totalItems += 3;
                    getItem = false;
                    houseItemWeit = houseItemRespons;
                    return;
                }
            }

            // 被ダメージ
            if (damegeWeit > 0)
            {
                states = Ready.Damage;
                moveWeit = damegeWeit;
                damegeWeit -= (float)time.ElapsedGameTime.TotalSeconds;
            }
            else if(states==Ready.Damage)
            {
                states = Ready.Normal;
            }

            // 移動
            if (moveWeit <= 0)
            {
                if (getItemWeit <= 0 && houseItemWeit <= 0)
                    states = Ready.Normal;

                if (InputManager.IsJustKeyDown(Keys.Left) || InputManager.IsJustKeyDown(Keys.A))
                {
                    if (position > 0)
                    {
                        states = Ready.Normal;
                        moveWeit = moveResponse;
                        position--;
                    }
                }
                if (InputManager.IsJustKeyDown(Keys.Right) || InputManager.IsJustKeyDown(Keys.D))
                {
                    if (position < stage.size - 1)
                    {
                        states = Ready.Normal;
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
            states = Ready.Damage;
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
