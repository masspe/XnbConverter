using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace XnbConverter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D[] tex;
        List<string> files;
        int format = 0;
        string DestDir;
        bool conversion = false;
        public Game1(List<string> files, int format,string DestDir)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.files = files;
            this.format = format;
            this.DestDir = DestDir;

                       
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
           switch (format)
            {
                case 0:
                    tex = new Texture2D[files.Count];
                    for (int i =0; i < files.Count;i++)
                    {
                        try
                        {
                            string f = files[i];
                            string path = Path.GetDirectoryName(f);
                            string fileName = Path.GetFileName(f);
                            string Extension = Path.GetExtension(f);
                            string fileNoExt = Path.GetFileNameWithoutExtension(f);
                            tex[i] = Content.Load<Texture2D>(path + "\\" + fileNoExt);
                            Stream stream = File.Create(DestDir + "\\" + fileNoExt + ".png");
                            tex[i].SaveAsPng(stream, tex[i].Width, tex[i].Height);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Conversion error:" + ex.Message);
                        }
                        
                    }
                    break;
                case 1:
                    tex = new Texture2D[files.Count];
                    for (int i = 0; i < files.Count; i++)
                    {
                        try
                        {
                            string f = files[i];
                        string path = Path.GetDirectoryName(f);
                        string fileName = Path.GetFileName(f);
                        string Extension = Path.GetExtension(f);
                        string fileNoExt = Path.GetFileNameWithoutExtension(f);
                        tex[i] = Content.Load<Texture2D>(path + "\\" + fileNoExt);
                        Stream stream = File.Create(DestDir + "\\" + fileNoExt + ".jpg");
                        tex[i].SaveAsJpeg(stream, tex[i].Width, tex[i].Height);
                    }
                        catch (Exception ex)
                    {
                        MessageBox.Show("Conversion error:" + ex.Message);
                    }
            }
                    break;
            }
            conversion = true;

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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

            if (conversion)
            {
                MessageBox.Show("Conversion Completed");
                Exit();
            }
            // TODO: Add your update logic here

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
        }
    }
}
