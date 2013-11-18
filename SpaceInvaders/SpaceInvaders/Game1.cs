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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game 
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ShipPic;
        Texture2D AsteroidPic;
        Texture2D GameBackground;
        Texture2D ExplosionPic;
        Texture2D LaserPic;
        Ship player;
         List<Asteroid> asteroids;
         List<Laser> lasers;

         Random r = new Random();
   
         public void GenerateAsteroids()
         {
             if (r.Next(50) == 1) {
                 
                 Rectangle rect = new Rectangle(0, 0, AsteroidPic.Width, AsteroidPic.Height);
                 var ast = new Asteroid(AsteroidPic, ExplosionPic, 100, rect); asteroids.Add(ast); }
         }

         public void MoveAsteroids()
         {
             for (int i = 0; i < asteroids.Count; i++)
             {
                 Asteroid ast = asteroids[i];

                 ast.Box.Y += 4;

                 if (ast.Box.Y == 1000)
                     asteroids.RemoveAt(i--);



                 ast.dying -= 1;
                 if (ast.dying == 0)



                     if (ast.Box.Intersects(player.Box) && ast.alive == true)
                     {
                         ast.alive = false;
                     };

                 asteroids.RemoveAt(i--);

                 for (int j = 0; j < lasers.Count; j++)
                 {
                     Laser l = lasers[j];


                 }
             }
         }


         public void GenMoveLasers()
         {
             for (int j = 0; j < lasers.Count; j++)
             {
                 Laser ast = lasers[j];
                 Rectangle rect1 = new Rectangle(ShipPic.Bounds.X, ShipPic.Bounds.Y, LaserPic.Width, LaserPic.Height);
                 var las = new Laser("laser", LaserPic, 100, rect1); lasers.Add(las);
                 las.Box.Y += 4;

                 if (las.Box.Y == -1000)
                     lasers.RemoveAt(j--);
             }
         }
         
        
        public Game1()
            : base()
        {
            try
            {
                graphics = new GraphicsDeviceManager(this);
            }
            catch { }
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ShipPic = Content.Load<Texture2D>("Spaceship_tut.png");
            AsteroidPic = Content.Load<Texture2D>("Asteroid.png");
            GameBackground = Content.Load<Texture2D>("Space.png");
            //ExplosionPic = Content.Load<Texture2D>("explosion.png");
            LaserPic = Content.Load<Texture2D>("laser.png");


            player = new Ship("Spaceship",ShipPic, 100 ,ShipPic.Bounds);
            asteroids = new List<Asteroid>();
           // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
                player.Box.X -= 4;
            
            if (state.IsKeyDown(Keys.Right))
                player.Box.X += 4;
            
            if (state.IsKeyDown(Keys.Up))
                player.Box.Y -= 4;
            
            if (state.IsKeyDown(Keys.Down))
                player.Box.Y += 4;

            GenerateAsteroids();
            MoveAsteroids();

            if (state.IsKeyDown(Keys.Space))
            {
                GenMoveLasers();
            }

            base.Update(gameTime);
           
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            spriteBatch.Begin();
            var back = new Rectangle(0,0, GameBackground.Bounds.Width*2, GameBackground.Bounds.Height*2);
            spriteBatch.Draw(GameBackground, back, Color.White);
            spriteBatch.Draw(player.Picture, player.Box, Color.White);
            foreach (var asteroid in asteroids)
            {
                spriteBatch.Draw(asteroid.Picture, asteroid.Box, Color.White);
            }

            spriteBatch.End();

        }
    }
}
