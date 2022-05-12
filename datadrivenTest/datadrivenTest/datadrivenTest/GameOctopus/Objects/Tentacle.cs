using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace datadrivenTest.GameOctopus
{
    public class Tentacle
    {
        public int position;

        public float speed;
        public int maxStep;
        List<int> pattern;

        public bool active = true;
        float moveCoolTime = 0f;
        int step = 0;
        public int Step
        {
            get { return step; }
            set
            {
                step = value;
                if (step < 0) step = 0;
                if (step > maxStep) step = maxStep;
            }
        }
        int patternIndex = 0;

        public Tentacle(int id, Stage stage)
        {
            LoadCSV(id);
        }
        void LoadCSV(int id)
        {
            if (id == 0)
            {
                active = false;
                return;
            }

            var data = Utility.ReadCSV("enemy.csv");
            var patternData = Utility.ReadCSV("tentcle_pattern.csv");

            position = id;

            speed = float.Parse(data[id.ToString()]["speed"]);
            maxStep = int.Parse(data[id.ToString()]["tentacle_step"]);
            pattern = new List<int>();
            foreach (var i in patternData[data[id.ToString()]["tentacle_pattern"]])
            {
                pattern.Add(int.Parse(i.Value));
            }
        }

        public void Update(GameTime time)
        {
            Move(time);
        }
        void Move(GameTime time)
        { 
            if (moveCoolTime > 0)
            {
                moveCoolTime -= (float)time.ElapsedGameTime.TotalSeconds;
                return;
            }
            moveCoolTime = speed;
            Step += pattern[patternIndex];
            patternIndex = (patternIndex + 1) % pattern.Count;
        }

    }
}
