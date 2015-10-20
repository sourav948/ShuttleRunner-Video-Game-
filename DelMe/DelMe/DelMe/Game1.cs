using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace DelMe
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Texture2D omnom;
        Vector2 position;
   
        KeyboardState currentState;
        private Texture2D background;
        private SpriteFont font;
          private int score = 0;
          private SpriteFont font1;
          private int Time = 0;
          private SpriteFont font3;
   
        List<Enemies> enemies = new List<Enemies>();
        Random random = new Random();
       
        Rectangle player, quad;

       // private Texture2D gameover;
      
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

      
        protected override void Initialize()
        {
            

            base.Initialize();
        }

        
        protected override void LoadContent()
        { omnom = Content.Load<Texture2D>("shuttle");
        background = Content.Load<Texture2D>("photo");
       // gameover = Content.Load<Texture2D>("Game");

        
          position = new Vector2(100f, 100f);
          font = Content.Load<SpriteFont>("Score");
          font1 = Content.Load<SpriteFont>("Time");
          font = Content.Load<SpriteFont>("Text");
            
            Song song = Content.Load<Song>("music");  
              MediaPlayer.Play(song);
        
         
           
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
        }


  
        
       
        float spawn = 0;


        protected override void Update(GameTime gameTime)
        {
            LoadEnemies();
            spawn +=(float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Enemies enemy in enemies)
            {   enemy.Update(graphics.GraphicsDevice);
           
            }
            //base.Update(gameTime);
           
            player = new Rectangle((int)position.X,(int) position.Y, 200, 600);
           // player = new Rectangle()

            foreach (Enemies enemy in enemies)
            {
                quad = new Rectangle((int)enemy.location.X, (int)enemy.location.Y, 400, 40);

            }
            // quad = new Rectangle( , 100, 100, 100);

            
            if(player.Intersects(quad))
            {


                
                 
                //background = Content.Load<Texture2D>("keep");
                score ++;
               // omnom = Content.Load<Texture2D>("keep");
                //Content.Load<Texture2D>("shuttle");
                //
       
                 
                //break;
           
            }
            else
            {

                //
            }

            Time++;
            

                
                    
             

            
            currentState = Keyboard.GetState();
            if (currentState.IsKeyDown(Keys.Up))
            { position.Y -= 5; }
            if (currentState.IsKeyDown(Keys.Down))
            { position.Y += 5; }
            if (currentState.IsKeyDown(Keys.Left))
            { position.X -= 5; }
            if (currentState.IsKeyDown(Keys.Right))
            {
                position.X += 5;
                // Allows the game to exit
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();

                // TODO: Add your update logic here

                base.Update(gameTime);
            }
        }
        public void LoadEnemies()
        {
            int randY = random.Next(100, 400);

            if (spawn >= 1)
            {
                spawn = 0;
                if (enemies.Count() < 4)
                    enemies.Add(new Enemies(Content.Load<Texture2D>("teri"), new Vector2(1100, randY)));
  }
            for (int i = 0; i < enemies.Count; i++)
                if (!enemies[i].isVisible)
                {

                    enemies.RemoveAt(i);
                    i--;

                }
        }
        protected override void UnloadContent()
        {
            Content.Unload();
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.Orange);
         
            spriteBatch.Draw(omnom, position, Color.White);
            spriteBatch.DrawString(font, "Game will Reset after 1 minute", new Vector2(40, 40), Color.White);
            if (Time / 60 < 30)
            {
               //
                spriteBatch.DrawString(font, "Score: " + score, new Vector2(100, 100), Color.White);
                spriteBatch.DrawString(font, "Time(seconds):" + Time / 60, new Vector2(600, 100), Color.White);

            }

            else
            {
                background = Content.Load<Texture2D>("04");
                Time = 0;
                score = 0;
            }
            
            spriteBatch.DrawString(font, "Score: " + score, new Vector2(100, 100), Color.White);
            spriteBatch.DrawString(font, "Time(seconds):" +Time/60, new Vector2(600, 100), Color.White);
           
            foreach (Enemies enemy in enemies)
                enemy.Draw(spriteBatch);
           // spriteBatch.Draw(gameover, position, Color.White);
            spriteBatch.End(); 

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
