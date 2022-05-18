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

        Stage stage;

        public Action updateAction;

        public States states;

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
            updateAction?.Invoke();

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
            else if (position == stage.tentacles.Count - 1)
            {
                if (InputManager.IsKeyDown(Keys.Right) || InputManager.IsKeyDown(Keys.D))
                {
                    states = States.Geting;
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
                    states = States.House;
                    totalItems += 3;
                    getItem = false;
                    houseItemWeit = houseItemRespons;
                    return;
                }
            }

            // 被ダメージ
            if (damegeWeit > 0)
            {
                states = States.Damage;
                moveWeit = damegeWeit;
                damegeWeit -= (float)time.ElapsedGameTime.TotalSeconds;
            }
            else if(states==States.Damage)
            {
                states = States.Normal;
            }

            // 移動
            if (moveWeit <= 0)
            {
                if (getItemWeit <= 0 && houseItemWeit <= 0)
                    states = States.Normal;

                if (InputManager.IsJustKeyDown(Keys.Left) || InputManager.IsJustKeyDown(Keys.A))
                {
                    if (position > 0)
                    {
                        states = States.Normal;
                        moveWeit = moveResponse;
                        position--;
                    }
                }
                if (InputManager.IsJustKeyDown(Keys.Right) || InputManager.IsJustKeyDown(Keys.D))
                {
                    if (position < stage.tentacles.Count - 1)
                    {
                        states = States.Normal;
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

            damegeWeit = 3f;
            states = States.Damage;
            position = 0;
        }

    }

    enum States {
        Normal,
        Damage,
        House,
        Geting
    }
}
