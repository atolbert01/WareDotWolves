using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WareDotWolves
{
    class GameObject
    {
        public GameObject() { }

        public virtual void Update(GameTime gameTime){ }

        public virtual void Draw(SpriteBatch spriteBatch){ }
    }
}
