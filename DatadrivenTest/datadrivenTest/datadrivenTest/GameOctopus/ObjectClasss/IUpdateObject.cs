using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace datadrivenTest.GameOctopus.ObjectClasss
{
    /// <summary>
    /// エンティティの基礎クラス
    /// </summary>
    interface IUpdateObject
    {
        public void Update(GameTime time) { }
    }
}
