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
    class GameObjectBase
    {
        public Texture2D Picture { get; set; }
        public Rectangle Box;
        public Texture2D Deadpicture { get; set; }
        public float Speed { get; set; }
        public uint  MaxHealth { get; set; }
        public uint CurrentHealth { get; set; }
        public double Angle { get; set; }

        public GameObjectBase(Texture2D picture, uint MaxHealth, Rectangle box)
        {
            Picture = picture;
            Deadpicture = picture;
            Box = box;
            Speed = 100;
            MaxHealth = 100;
            
            
            CurrentHealth = MaxHealth;
        }

    }
}
