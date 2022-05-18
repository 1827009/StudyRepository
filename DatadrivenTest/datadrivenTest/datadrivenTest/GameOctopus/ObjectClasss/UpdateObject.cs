using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace datadrivenTest.GameOctopus.ObjectClasss
{
    /// <summary>
    /// エンティティの基礎クラス
    /// </summary>
    class UpdateObject
    {
        public UpdateObject()
        {

        }

        public virtual void Update(GameTime time) { }
    }
}
