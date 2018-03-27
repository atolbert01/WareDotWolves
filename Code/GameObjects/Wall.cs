using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WareDotWolves
{
    class Wall : GameObject
    {
        public Texture2D Texture { get; set; }
        public TextureAtlas Sprites { get; set; }
        public Vector2 Position { get; set; }
        public Wall() { }

        public Wall(Texture2D texture, int spriteIndex, Vector2 position)
        {
            Texture = texture;
            Sprites = new TextureAtlas(texture, 32, new int[] { spriteIndex });
            Position = position;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprites.Draw(spriteBatch, Position);
        }
    }
}
