using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WareDotWolves
{
    class Animation
    {
        public TextureAtlas TexAtlas { get; set; }
        public int[] Frames { get; set; }
        public int CurrentFrame { get; set; }
        public int CurrentIndex { get; set; }
        public float Tick { get; set; }
        public Animation(TextureAtlas texAtlas, int[] frames)
        {
            TexAtlas = texAtlas;
            Frames = frames;
            Tick = 1;
        }

        public void Update(GameTime gameTime)
        {
            if (Frames != null)
            {
                float et = (float)gameTime.ElapsedGameTime.TotalSeconds;
                Tick += et * 60.0f;

                if (Tick > 6)
                {
                    if (CurrentIndex + 1 < Frames.Length)
                    {
                        CurrentIndex++;
                        CurrentFrame = Frames[CurrentIndex];
                        Tick = 0;
                    }
                    else
                    {
                        CurrentIndex = 0;
                        CurrentFrame = Frames[CurrentIndex];
                        Tick = 0;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            TexAtlas.Draw(spriteBatch, position, CurrentFrame);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, float layerDepth)
        {
            TexAtlas.Draw(spriteBatch, position, CurrentFrame, layerDepth);
        }

    }
}
