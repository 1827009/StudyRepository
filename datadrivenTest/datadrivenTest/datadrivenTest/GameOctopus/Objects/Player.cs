using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace datadrivenTest.GameOctopus
{
    class Player
    {
        public int position = 0;
        float moveWeit = 0;
        float getItemWeit = 0;
        public int totalItems = 0;
        public bool getItem = false;

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
            // 操作
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
            if (getItemWeit > 0)
                getItemWeit -= (float)time.ElapsedGameTime.TotalSeconds;

            if (getItemWeit <= 0 && position == 0)
            {
                if (InputManager.IsKeyDown(Keys.Left) || InputManager.IsKeyDown(Keys.A))
                {
                    totalItems+=3;
                    getItem = false;
                    return;
                }
            }

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
            if (moveWeit > 0)
                moveWeit -= (float)time.ElapsedGameTime.TotalSeconds;
        }

        public void Damage()
        {
            getItem = false;
            stock--;
            if (stock < 0)
                return;

            position = 0;
            moveWeit = 2;
        }
    }
}
