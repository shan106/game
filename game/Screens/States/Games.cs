using game.Cameras;
using game.Levels;
using game.Screens.States;
using game.Spelers;
using game.TheEnd;
using game.Valstrik;
using game.Vijand;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.Screens
{
    public class Games: State
    {
        private Camera camera;
        private Speler hero;
        private Level level;
        private Enemys enemy;
        private Exit ex;
        private Val vals;
        private bool lvl;
        private SoundEffect spring;
        private Texture2D bgtexture, texture, valsstrik, exit;
        private int backgroundsize = 1798;
        public Games(Game1 game, GraphicsDevice graphics, ContentManager content, bool lvl) : base(game, graphics, content)
        {
            this.lvl = lvl;
            LoadContent();
        }

        public void LoadContent()
        {
            level = new Level(content);
            level.CreateWorld(lvl);
            enemy = new Enemys(content, level.colli, lvl);
            enemy.CreateEnemy();
            camera = new Camera(graphicsDevice.Viewport);
            texture = content.Load<Texture2D>("Hero/hero");
            valsstrik = content.Load<Texture2D>("Wereld/dood");
            exit = content.Load<Texture2D>("Wereld/exit");
            hero = new Speler(texture, level.colli, content);
            spring = content.Load<SoundEffect>("Geluid/gamesound");
            if (!lvl) bgtexture = content.Load<Texture2D>("Background/gameMaountains"); else { bgtexture = content.Load<Texture2D>("Background/gameLandscape"); }
            ex = new Exit(exit, lvl);
            vals = new Val(valsstrik);
            vals.CreateVal();
        }

        public override void Update(GameTime gameTime)
        {
            hero.Update(gameTime, spring);
            camera.Update(hero.positie, backgroundsize, backgroundsize);
            CheckTheState();
        }

        public void CheckTheState()
        {
            if (!enemy.Geraakt(hero.CollisionRectangle))
                enemy.Update();

            if (vals.Gestorven(hero.CollisionRectangle) || enemy.Geraakt(hero.CollisionRectangle))
                gamee.State(new Dood(gamee, graphicsDevice, content));

            if (ex.CheckNextLevel(hero.CollisionRectangle))
                if (!lvl) gamee.State(new Menu(gamee, graphicsDevice, content, true)); else gamee.State(new End(gamee, graphicsDevice, content));

            // check if enemy died or the bullet hit the blok //
            foreach (int i in Enumerable.Range(0, hero.kogels.Count))
            {
                if (enemy.Geraakt(hero.kogels[i].enemybullet))
                    enemy.DeleteEnemy();

                if (level.BulletGeraakt(hero.kogels[i].enemybullet))
                    hero.kogels[i].IsRemoved = true;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sprite)
        {
            sprite.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Mat);
            sprite.Draw(bgtexture, new Rectangle(0, 510, 1798, 1291), Color.White);
            hero.Draw(sprite);
            level.DrawWorld(sprite);
            enemy.DrawEnemy(sprite);
            vals.Draw(sprite);
            ex.Draw(sprite);
            sprite.End();
        }
    }
}
