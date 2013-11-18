#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace GameName1
{
    class Ship : GameObjectBase
    {
        public string Name {get;set;}
           public Ship(string name,Texture2D picture, uint MaxHealth, Rectangle box):base(picture,MaxHealth,box)
           {
                 // ...
            }

    }
}
