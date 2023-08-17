using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace game.Screens.States
{
    public class Menu: State
    {
        private List<Screen> screen;
        private Texture2D buttont, beginbackg, button2;
        private SpriteFont buttonf;
        public Menu(Game1 game, GraphicsDevice graphics, ContentManager content, bool nextlevel) : base(game, graphics, content)
        {
            InitializeContent();
            ButtonDraw(nextlevel);
        }
        private void InitializeContent()
        {
            buttont = content.Load<Texture2D>("Background/button");
            button2 = content.Load<Texture2D>("Background/button2");
            buttonf = content.Load<SpriteFont>("font");
            beginbackg = content.Load<Texture2D>("Background/game");
        }
        public void ButtonDraw(bool nextlevel)
        {
            var button = new Knop(buttont, buttonf);
            var buttonQ = new Knop(buttont, buttonf);
            
            if (nextlevel)
            {
                button = new Knop(button2, buttonf)
                {
                    pos = new Vector2(400, 200),
                    displaytext = "Ga naar level 2",

                };

                button.clicker += GOTONEXTLEVEL;

                buttonQ = new Knop(button2, buttonf)
                {
                    pos = new Vector2(400, 250),
                    displaytext = "Exit",
                };

                buttonQ.clicker += STOP_CLICK;
            }
            else
            {
                button = new Knop(buttont, buttonf)
                {

                    pos = new Vector2(430, 200),
                    displaytext = "Nieuw spel",

                };

                button.clicker += NEWGameButton_Click;


                buttonQ = new Knop(buttont, buttonf)
                {
                    pos = new Vector2(430, 300),
                    displaytext = "Exit",
                };

                buttonQ.clicker += STOP_CLICK;
            }
            screen = new List<Screen>()
            {
                button,
                buttonQ,
                
               
            };
           
        }
        public override void Draw(GameTime gameTime, SpriteBatch sprite)
        {
            sprite.Begin();
            sprite.Draw(beginbackg, new Rectangle(0, 0, 1000, 500), Color.White);
            foreach (var screen in screen)
                screen.Draw(gameTime, sprite);
            sprite.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var screen in screen)
                screen.Update(gameTime);
        }
        public void STOP_CLICK(object sender, EventArgs e)
        {
            gamee.Exit();
        }
        public void NEWGameButton_Click(object sender, EventArgs e)
        {
            gamee.State(new Games(gamee, graphicsDevice, content, false));
        }
        public void GOTONEXTLEVEL(object sender, EventArgs e)
        {
            gamee.State(new Games(gamee, graphicsDevice, content, true));
        }
    }
}
