using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using datadrivenTest.GameOctopus.DrawClasss;

namespace datadrivenTest.GameOctopus
{
    public class Player
    {
        const float BLINKING_TIME = 0.25f;

        public Action updateAction;

        public int position = 0;
        float moveWeit = 0;
        float getItemWeit = 0;
        public int totalItems = 0;
        public bool getItem = false;
        float onBlinking = 0f;

        float moveResponse;
        public float stock;
        float getItemRespons;

        public Player()
        {
            LoadCSV();
        }
        void LoadCSV()
        {
            var data = Utility.ReadCSV("player.csv");
            moveResponse = float.Parse(data["move_respons"]["status"]);
            stock= float.Parse(data["stock"]["status"]);
            getItemRespons = float.Parse(data["get_item_respons"]["status"]);
        }

        public void Update(GameTime time, Stage stage)
        {
            updateAction?.Invoke();

            Control(time, stage);
        }
        void Control(GameTime time, Stage stage)
        {
            // 宝取得
            if (getItemWeit <= 0 && position == stage.tentacles.Count - 1)
            {
                if (InputManager.IsKeyDown(Keys.Right) || InputManager.IsKeyDown(Keys.D))
                {
                    totalItems++;
                    getItem = true;
                    getItemWeit = getItemRespons;
                    moveWeit = moveResponse;
                    return;
                }
            }
            else
                getItemWeit -= (float)time.ElapsedGameTime.TotalSeconds;
            // 船へ帰還
            if (getItem && position == 0 && (InputManager.IsJustKeyDown(Keys.Left) || InputManager.IsJustKeyDown(Keys.A)))
            {
                totalItems += 3;
                getItem = false;
                return;
            }

            // 移動
            if (moveWeit <= 0)
            {
                if (InputManager.IsKeyDown(Keys.Left) || InputManager.IsKeyDown(Keys.A))
                {
                    if (position > 0)
                    {
                        position--;
                        moveWeit = moveResponse;
                    }
                }
                if (InputManager.IsKeyDown(Keys.Right) || InputManager.IsKeyDown(Keys.D))
                {
                    if (position < stage.tentacles.Count - 1)
                    {
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
            if (stock < 0)
                return;

            position = 0;
            moveWeit = 2;
            onBlinking = 2f;
        }

        float blinkingTime = 0;
        public bool Blinking()
        {
            if (onBlinking > 0)
            {
                onBlinking -= Game1.gameTime;
                if (blinkingTime > 0)
                {
                    blinkingTime -= Game1.gameTime;
                    return true;
                }
                else
                    blinkingTime = BLINKING_TIME;
            }
            return false;
        }
    }
}
