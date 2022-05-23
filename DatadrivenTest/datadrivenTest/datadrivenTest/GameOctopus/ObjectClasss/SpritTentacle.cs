using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace datadrivenTest.GameOctopus.ObjectClasss
{
    class SpritTentacle:Tentacle
    {
        Tentacle tentacle2;
        bool sprit = false;
        public override int Step
        {
            get { return base.Step; }
            set
            {
                // 根っこが同じで片方にしか伸びない触手のための処理
                if (sprit)
                    tentacle2.Step = value;
                else
                    base.Step = value;

                if (value <= 0)
                    sprit = !sprit;
            }
        }

        public SpritTentacle(int id, int pos, Tentacle tentacle):base(id, pos){
            tentacle2 = tentacle;
        }
    }
}
