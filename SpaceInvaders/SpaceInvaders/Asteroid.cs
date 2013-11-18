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
    class Asteroid : GameObjectBase
    {

        public Asteroid(Texture2D picture, Texture2D deadpicture, uint MaxHealth, Rectangle box)
            : base(picture, MaxHealth, box)
        {

        }

        public int dying = 50;
        private bool _alive = true;
        public bool alive
        {
            get
            {
                return _alive;
            }
            set
            {
                _alive = value;
                if (_alive == true)
                    Picture = Deadpicture;
                
            }
        }

        

    }
}
