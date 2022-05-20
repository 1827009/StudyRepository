using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace datadrivenTest.GameOctopus.ObjectClasss
{
    class Tentacle:UpdateObject
    {
        public int position;

        public float speed;
        public int maxStep;
        List<int> pattern;

        int step = 0;
        public virtual int Step
        {
            get { return step; }
            set
            {
                step = value;
                if (step < 0) step = 0;
                if (step > maxStep) step = maxStep;
            }
        }

        public Tentacle(int id, int pos)
        {
            position = pos;
            LoadCSV(id);
        }
        public Tentacle(Tentacle tentacle)
        {
            position = tentacle.position;
            speed = tentacle.speed;
            maxStep = tentacle.maxStep;
            pattern = tentacle.pattern;
            step = tentacle.step;
        }
        public void LoadCSV(int id)
        {
            var data = Utility.ReadCSV("config/enemy.csv");
            var patternData = Utility.ReadCSV("config/tentcle_pattern.csv");

            speed = float.Parse(data[id.ToString()]["speed"]);
            maxStep = int.Parse(data[id.ToString()]["tentacle_step"]);
            pattern = new List<int>();
            foreach (var i in patternData[data[id.ToString()]["tentacle_pattern"]])
            {
                pattern.Add(int.Parse(i.Value));
            }
        }

        public override void Update(GameTime time)
        {
            Move(time);
        }
        float moveCoolTime = 0f;
        int patternIndex = 0;
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

        public bool OnAttack
        {
            get { return Step == maxStep; }
        }

    }
}
