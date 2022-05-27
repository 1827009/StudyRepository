using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyXNA
{
    static class TimeManager
    {
        static Dictionary<string, float> timers=new Dictionary<string, float>();

        static public void Update(GameTime gameTime)
        {
            List<string> keys = new List<string>(timers.Keys);
            foreach (var item in keys)
            {
                if (timers[item] > 0)
                    timers[item] -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        static public bool GetTimerZero(string timer)
        {
            if (timers[timer] <= 0)
            {
                timers.Remove(timer);
                return true;
            }
            return false;
        }
        static public float GetTime(string timer)
        {
            return timers[timer];
        }

        static public void AddTimer(string key, float time) {
            timers.Add(key, time);
        }
    }
}
