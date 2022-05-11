using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace datadrivenTest.GameOctopus
{
    class Tentacle
    {
        public int position;

        public float speed;
        public int maxStep;
        public List<int> pattern;
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
            var data = Utility.ReadCSV("enemy.csv");
            var patternData = Utility.ReadCSV("tentcle_pattern.csv");

            position = id;

            speed = float.Parse(data[id.ToString()]["speed"]);
            maxStep = int.Parse(data[id.ToString()]["tentacle_step"]);
            pattern = new List<int>();
            foreach (var i in patternData)
            {
                pattern.Add(int.Parse(i.Value[data[id.ToString()]["tentacle_pattern"]]));
            }
        }

        public void Update(GameTime time)
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
