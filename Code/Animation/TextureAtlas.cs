using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WareDotWolves
{
    class TextureAtlas
    {
        //public Vector2 Position { get; set; }
        public int SpriteIndex { get; set; }
        public int SpriteSize { get; set; }
        public float Scale { get; set; }
        public float Rotation { get; set; }
        public Rectangle[] SourceRects { get; set; }
        private Texture2D texture;
        public TextureAtlas(Texture2D texture, int spriteSize)
        {
            this.texture = texture;
            SpriteSize = spriteSize;
            SourceRects = SliceTexture(this.texture);
            Scale = 1.0f;
            Rotation = 0f;
        }

        /// <summary>
        /// Use this constructor to specify specific indexes on the texture from which to create a TextureAtlas.
        /// Useful if you want to use only a part of a Texture2D.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="spriteSize"></param>
        /// <param name="imageIndexes"></param>
        public TextureAtlas(Texture2D texture, int spriteSize, int[] imageIndexes)
        {
            this.texture = texture;
            SpriteSize = spriteSize;
            SourceRects = SliceTexture(this.texture, imageIndexes);
            Scale = 1.0f;
            Rotation = 0f;
        }

        private Rectangle[] SliceTexture(Texture2D texture)
        {
            Rectangle[] slicedRects = new Rectangle[0];
            int spriteCount = 0;
            int columns = 0;
            int rows = 0;

            columns = texture.Bounds.Width / SpriteSize;
            rows = texture.Bounds.Height / SpriteSize;
            slicedRects = new Rectangle[columns * rows];
            for (int i = 0; i < texture.Bounds.Height / SpriteSize; i++)
            {
                for (int j = 0; j < texture.Bounds.Width / SpriteSize; j++)
                {
                    slicedRects[spriteCount] = new Rectangle(j * SpriteSize, i * SpriteSize, SpriteSize, SpriteSize);//new SourceRectangleInfo(tex, new Rectangle(j * gridSize, i * gridSize, gridSize, gridSize));
                    spriteCount++;
                }
            }
            return slicedRects;
        }

        /// <summary>
        /// Can be used to gather specific source rectangles from a texture.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="imageIndexes"></param>
        /// <returns></returns>
        private Rectangle[] SliceTexture(Texture2D texture, int[] imageIndexes)
        {
            Rectangle[] slicedRects = new Rectangle[imageIndexes.Length];
            int columns = texture.Bounds.Width / SpriteSize;

            for (int i = 0; i < slicedRects.Length; i++)
            {
                slicedRects[i] = new Rectangle((imageIndexes[i] % columns) * SpriteSize, ((int)(imageIndexes[i] / 8)) * SpriteSize, SpriteSize, SpriteSize);
            }
            return slicedRects;
        }

        /// <summary>
        /// Returns
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public Rectangle[] GetSourceRectangle(int startIndex, int endIndex)
        {
            Rectangle[] srcRects = new Rectangle[1];
            return srcRects;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(texture, position, SourceRects[SpriteIndex], Color.White, Rotation, new Vector2(0, 0), Scale, SpriteEffects.None, 0f);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, int spriteIndex, float layerDepth)
        {
            spriteBatch.Draw(texture, position, SourceRects[spriteIndex], Color.White, Rotation, new Vector2(0, 0), Scale, SpriteEffects.None, layerDepth);
        }

        /// <summary>
        /// Can specify a spriteIndex in the case of an animation that requires specific indices.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="position"></param>
        /// <param name="spriteIndex"></param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position, int spriteIndex)
        {
            spriteBatch.Draw(texture, position, SourceRects[spriteIndex], Color.White, Rotation, new Vector2(0, 0), Scale, SpriteEffects.None, 0f);
        }
    }
}
