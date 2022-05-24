using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace datadrivenTest.GameOctopus.ObjectClasss
{
    class Tentacle:IUpdateObject
    {
        public int position;

        int id;
        public int maxStep;

        public float speed;
        List<int> pattern;

        int step = 0;
        bool returnMode = false;
        public virtual int Step
        {
            get { return step; }
            set
            {
                step = value;
                if (step <= 0)
                {
                    returnMode = false;
                    step = 0;
                }
                if (step >= maxStep) 
                {
                    returnMode = true;
                    step = maxStep;
                }
            }
        }

        public Tentacle(int id, int pos)
        {
            position = pos;
            this.id = id;
            CsvLoad(id);
        }
        public void CsvLoad(int id)
        {
            var data = My.CsvControler.ReadCSV("config/tentacles.csv");
            var patternData = My.CsvControler.ReadCSV("config/tentacle_pattern.csv");

            speed = float.Parse(data[id.ToString()]["speed"]);
            //maxStep = int.Parse(data[id.ToString()]["tentacle_step"]);
            pattern = new List<int>();
            foreach (var i in patternData[data[id.ToString()]["tentacle_pattern"]])
            {
                if (i.Value != "")
                    pattern.Add(int.Parse(i.Value));
            }
        }

        public void Update(GameTime time)
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
            Step += returnMode ? -pattern[patternIndex] : pattern[patternIndex];
            patternIndex = (patternIndex + 1) % pattern.Count;
        }

        public bool OnAttack
        {
            get { return Step == maxStep; }
        }

    }
}
