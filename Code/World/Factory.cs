using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WareDotWolves
{
    static class Factory
    {
        static Texture2D FactionsTexture { get; set; }
        static Texture2D TilesTexture { get; set; }
        static int ViewHeight { get; set; }
        public static void Load(Texture2D factionsTex, Texture2D tilesTex, int tileSize, int viewHeight)
        {
            FactionsTexture = factionsTex;
            TilesTexture = tilesTex;
            ViewHeight = viewHeight;
        }

        public static GameObject GetObject(string id, Vector2 position)
        {
            GameObject newObj = new GameObject();

            switch(id)
            {
                case ("w000"):
                    newObj = new Wall(TilesTexture, 40, position);
                    break;
                case ("w001"):
                    newObj = new Wall(TilesTexture, 41, position);
                    break;
                case ("w002"):
                    newObj = new Wall(TilesTexture, 42, position);
                    break;
                case ("w003"):
                    newObj = new Wall(TilesTexture, 43, position);
                    break;
                case ("w004"):
                    newObj = new Wall(TilesTexture, 44, position);
                    break;
                case ("w005"):
                    newObj = new Wall(TilesTexture, 45, position);
                    break;
                case ("w006"):
                    newObj = new Wall(TilesTexture, 46, position);
                    break;
                case ("w007"):
                    newObj = new Wall(TilesTexture, 47, position);
                    break;
                case ("w008"):
                    newObj = new Wall(TilesTexture, 48, position);
                    break;
                case ("w009"):
                    newObj = new Wall(TilesTexture, 49, position);
                    break;
                case ("w010"):
                    newObj = new Wall(TilesTexture, 50, position);
                    break;
                case ("w011"):
                    newObj = new Wall(TilesTexture, 51, position);
                    break;
                case ("w012"):
                    newObj = new Wall(TilesTexture, 52, position);
                    break;
                case ("w013"):
                    newObj = new Wall(TilesTexture, 53, position);
                    break;
                case ("w014"):
                    newObj = new Wall(TilesTexture, 54, position);
                    break;
                case ("w016"):
                    newObj = new Wall(TilesTexture, 56, position);
                    break;
                case ("w017"):
                    newObj = new Wall(TilesTexture, 57, position);
                    break;
                case ("w018"):
                    newObj = new Wall(TilesTexture, 58, position);
                    break;
                case ("p000"):
                    newObj = new Kilroy(PlayerIndex.One, FactionsTexture, position, ViewHeight);
                    break;
                case ("p001"):
                    newObj = new Rosco(PlayerIndex.Two, FactionsTexture, position, ViewHeight);
                    break;
            }

            return newObj;
        }
    }
}
