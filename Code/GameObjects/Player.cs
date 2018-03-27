using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WareDotWolves
{
    enum PlayerState { Idle, Walking }
    class Player : GameObject
    {
        public TextureAtlas Sprites { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Animation[] IdleAnimSet { get; set; }
        public Animation CurrentAnim { get; set; }
        public int Facing { get; set; }
        public PlayerState State { get; set; }
        public PlayerIndex PlayerNumber { get; set; }
        public GamePadState PadState { get; set; }
        public float MoveSpeed { get; set; }
        public Rectangle BoundingBox
        {
            get { return new Rectangle((int)(Position.X + 10), (int)(Position.Y + 12), 12, 12); }
        }
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        Vector2 velocity;
        //private float movement = 0.0f;
        private Vector2 movement;
        private int viewHeight;

        // constants for controlling movement
        //private const float MoveSpeed = 5200.0f;

        public Player(PlayerIndex playerNumber, Texture2D texture, Vector2 position, int viewHeight)
        {
            PlayerNumber = playerNumber;
            //Sprites = sprites;
            Texture = texture;
            Position = position;
            this.viewHeight = viewHeight;
        }

        public override void Update(GameTime gameTime)
        {
            GetInput();
            ApplyPhysics(gameTime);
            switch (State)
            {
                case (PlayerState.Idle):
                    CurrentAnim = IdleAnimSet[Facing];
                    break;
                case (PlayerState.Walking):
                    break;
            }
            CurrentAnim.Update(gameTime);

            // Clear input.
            //movement = Vector2.Zero;
        }

        private void GetInput()
        {
            PadState = GamePad.GetState(PlayerNumber);
            movement = PadState.ThumbSticks.Left;

            // Ignore small movements to prevent running in place.
            if (Math.Abs(movement.X) < 0.05f) { movement.X = 0.0f; }
            if (Math.Abs(movement.Y) < 0.05f) { movement.Y = 0.0f; }

            if (movement.X < 0) { movement.X = -1; }
            if (movement.X > 0) { movement.X = 1; }
            if (movement.Y < 0) { movement.Y = -1; }
            if (movement.Y > 0) { movement.Y = 1; }
        }

        private void ApplyPhysics(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 previousPosition = Position;
            velocity = new Vector2((movement.X * MoveSpeed) * elapsed, (-movement.Y) * MoveSpeed * elapsed);

            // Apply velocity.
            Position += velocity;
            //Position = new Vector2((float)Math.Round(Position.X), (float)Math.Round(Position.Y));

            // If the player is now colliding with the level, separate them.
            HandleCollisions();

            // If the collision stopped us from moving, reset the velocity to zero.
            if (Position.X == previousPosition.X) { velocity.X = 0; }
            if (Position.Y == previousPosition.Y) { velocity.Y = 0; }

            Vector2 posChange = Vector2.Normalize(Position - previousPosition);

            if (posChange.X > 0 && posChange.Y == 0) { Facing = FacingDirection.E; }
            else if (posChange.X > 0 && posChange.Y > 0) { Facing = FacingDirection.SE; }
            else if (posChange.X == 0 && posChange.Y > 0) { Facing = FacingDirection.S; }
            else if (posChange.X < 0 && posChange.Y > 0) { Facing = FacingDirection.SW; }
            else if (posChange.X < 0 && posChange.Y == 0) { Facing = FacingDirection.W; }
            else if (posChange.X < 0 && posChange.Y < 0) { Facing = FacingDirection.NW; }
            else if (posChange.X == 0 && posChange.Y < 0) { Facing = FacingDirection.N; }
            else if (posChange.X > 0 && posChange.Y < 0) { Facing = FacingDirection.NE; }
        }

        private void HandleCollisions()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            CurrentAnim.Draw(spriteBatch, Position);
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D pixelTex)
        {
            CurrentAnim.Draw(spriteBatch, Position, ((viewHeight - Position.Y) / viewHeight));
            //spriteBatch.Draw(pixelTex, BoundingBox, Color.White * 0.5f);
        }
    }

    /// <summary>
    /// A ferocious lycanthropean scrapper.
    /// </summary>
    class Rosco : Player
    {
        public Rosco(PlayerIndex playerNumber, Texture2D texture, Vector2 position, int viewHeight) : base(playerNumber, texture, position, viewHeight)
        {
            Sprites = new TextureAtlas(texture, 32, new int[] { 8, 9, 10, 11, 12, 13, 14, 15 });
            IdleAnimSet = new Animation[]
            {
                new Animation(Sprites, new int[] { 0 }),
                new Animation(Sprites, new int[] { 1 }),
                new Animation(Sprites, new int[] { 2 }),
                new Animation(Sprites, new int[] { 3 }),
                new Animation(Sprites, new int[] { 4 }),
                new Animation(Sprites, new int[] { 5 }),
                new Animation(Sprites, new int[] { 6 }),
                new Animation(Sprites, new int[] { 7 })
            };
            State = PlayerState.Idle;
            Facing = FacingDirection.S;
            CurrentAnim = IdleAnimSet[Facing];
            MoveSpeed = 90.0f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }

    /// <summary>
    /// A gun-toting monster-hunter, more machine than man. Twisted and evil...
    /// </summary>
    class Kilroy : Player
    {
        public Kilroy(PlayerIndex playerNumber, Texture2D texture, Vector2 position, int viewHeight) : base(playerNumber, texture, position, viewHeight)
        {
            Sprites = new TextureAtlas(texture, 32, new int[] { 0, 1, 2, 3, 4, 5, 6, 7 });
            IdleAnimSet = new Animation[]
            {
                new Animation(Sprites, new int[] { 0 }),
                new Animation(Sprites, new int[] { 1 }),
                new Animation(Sprites, new int[] { 2 }),
                new Animation(Sprites, new int[] { 3 }),
                new Animation(Sprites, new int[] { 4 }),
                new Animation(Sprites, new int[] { 5 }),
                new Animation(Sprites, new int[] { 6 }),
                new Animation(Sprites, new int[] { 7 })
            };
            State = PlayerState.Idle;
            Facing = FacingDirection.SE;
            CurrentAnim = IdleAnimSet[Facing];
            MoveSpeed = 75.0f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
