using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WareDotWolves
{
    class Level
    {
        //public string[,] Layout { get; set; }
        public ArrayList<GameObject>[] Layers { get; set; }
        public int TileSize { get; set; }
        public Rectangle Bounds { get; set; }

        private int levelIndex;
        private string lvlFile;

        /// <summary>
        /// The levelIndex is used to specify which level file to load. 
        /// The tile size indicates the pixel dimensions of each tile and therefore the dimensions of the level.
        /// </summary>
        /// <param name="levelIndex"></param>
        /// <param name="tileSize"></param>
        public Level(int levelIndex, int tileSize)
        {
            this.levelIndex = levelIndex;
            TileSize = tileSize;
            Layers = new ArrayList<GameObject>[4];
            for(int i = 0; i < Layers.Length; i++)
            {
                Layers[i] = new ArrayList<GameObject>();
            }
        }

        public void Load()
        {
            lvlFile = OpenLevelFile();
            if (lvlFile != "")
            {
                // We make multiple passes for each layer so we can draw items on top of other tiles.
                string[] layers = lvlFile.Split('-');

                // Each layer will have the same dimensions.
                int numRows = layers[0].Split("\r\n".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries).Length;
                int numColumns = layers[0].Split("\r\n".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries)[0].Split(',').Length;
                Bounds = new Rectangle(0, 0, numColumns * TileSize, numRows * TileSize);

                // Iterate through the layer and place tiles.
                for (int layerIndex = 0; layerIndex < layers.Length; layerIndex++)
                {
                    string[] rows = layers[layerIndex].Split("\r\n".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);

                    for (int row = 0; row < numRows; row++)
                    {
                        for (int column = 0; column < numColumns; column++)
                        {
                            string tileId = rows[row].Split(',')[column];
                            if (tileId != "....")
                            {
                                Layers[layerIndex].Add(Factory.GetObject(tileId, new Vector2(column * TileSize, row * TileSize)));
                            }

                        }
                    }
                }
            }
        }

        private string OpenLevelFile()
        {
            string fileContents = "";
            try
            {
                System.IO.Stream stream = TitleContainer.OpenStream("Content/lvl/" + levelIndex.ToString() + ".lvl");
                System.IO.StreamReader sreader = new System.IO.StreamReader(stream);
                fileContents = sreader.ReadToEnd();
                stream.Close();
                return fileContents;
            }
            catch (System.IO.FileNotFoundException)
            {
                return fileContents;
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < Layers.Length; i++)
            {
                for (int j = 0; j < Layers[i].Count; j++)
                {
                    Layers[i].Items[j].Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < Layers.Length; i++)
            {
                for (int j = 0; j < Layers[i].Count; j++)
                {
                    Layers[i].Items[j].Draw(spriteBatch);
                }
            }
        }
    }
}
