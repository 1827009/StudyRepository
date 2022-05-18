using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace datadrivenTest.GameOctopus.ObjectClasss
{
    class SpritTentacle:Tentacle
    {
        public Tentacle rootTentacle = null;
        public int rootStep = 0;
        public override int Step
        {
            get { return base.Step; }
            set
            {
                // 根っこが同じで片方にしか伸びない触手のための処理
                if (rootTentacle != null && rootStep <= rootTentacle.Step)
                    return;

                base.Step = value;
            }
        }

        public SpritTentacle(Tentacle baseTentacle, Tentacle rootTentacle, int rootStep):base(baseTentacle){
            this.rootTentacle = rootTentacle;
            this.rootStep = rootStep;
        }
    }
}
