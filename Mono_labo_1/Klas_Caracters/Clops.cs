using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono_labo_1.interfaces;
using Mono_labo_1.Klas_Frames;
using Mono_labo_1.Klas_Interfaces;
using Mono_labo_1.Klas_Move;
using System;
using System.Collections.Generic;

namespace Mono_labo_1.Caracters
{
    class Clops : IGameObject, IMovable
    {
        // PROPERTIES
        private Texture2D texture;
        private Dictionary<string, Animation> animations;
        private MovementManager movementManager;
        private Animation currentAnimation;
        private bool isMovingLeft;
        private int frameWidth;  // Declareer frameWidth als een veld
        private int frameHeight; // Declareer frameHeight als een veld
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }
        private GraphicsDevice graphicsDevice;

        // CONSTRUCTOR
        public Clops(Texture2D texture, IInputReader inputReader, GraphicsDevice graphicsDevice)
        {
            this.texture = texture;
            this.InputReader = inputReader;
            animations = new Dictionary<string, Animation>();
            movementManager = new MovementManager();
            Position = new Vector2(1, 1);
            Speed = new Vector2(2, 2);
            this.graphicsDevice = graphicsDevice;

            SetupAnimations();
            SetCurrentAnimation("idleleft");

            // Get the screen width and height from the GraphicsDevice
            frameWidth = currentAnimation.CurrentFrame.SourceRectangle.Width;
            frameHeight = currentAnimation.CurrentFrame.SourceRectangle.Height;

        }

        private void SetCurrentAnimation(string animationName)
        {
            if (animations.ContainsKey(animationName))
            {
                currentAnimation = animations[animationName];

                // Update frameWidth en frameHeight met de breedte en hoogte van het huidige frame
                frameWidth = currentAnimation.CurrentFrame.SourceRectangle.Width;
                frameHeight = currentAnimation.CurrentFrame.SourceRectangle.Height;
            }
            else
            {
                currentAnimation = animations.ContainsKey("idleleft") ? animations["idleleft"] : null;

                if (currentAnimation == null)
                {
                    throw new ArgumentException("Animation with the specified name does not exist: " + animationName);
                }
            }
        }

        private void SetupAnimations()
        {
            // Voeg verschillende animaties toe aan de dictionary
            Animation idleLeftAnimation = new Animation();
            idleLeftAnimation.GetAnimationFromTextureRow(11, 15, 64,64, 0);
            animations.Add("idleleft", idleLeftAnimation);

            Animation idleRightAnimation = new Animation();
            idleRightAnimation.GetAnimationFromTextureRow(1, 15, 64, 64, 0);
            animations.Add("idleright", idleRightAnimation);

            Animation walkLeftAnimation = new Animation();
            walkLeftAnimation.GetAnimationFromTextureRow(12, 12, 64, 64, 2);
            animations.Add("walkleft", walkLeftAnimation);

            Animation walkRightAnimation = new Animation();
            walkRightAnimation.GetAnimationFromTextureRow(2, 12, 64, 64, 2);
            animations.Add("walkright", walkRightAnimation);
        }

        // METHODS
        public void Draw(SpriteBatch spriteBatch)
        {
            // Bepaal de gewenste schaalvergroting
            float scale = 1.3f; // Pas deze waarde naar wens aan

            // Bereken de positie waarop de tekenfiguur moet worden weergegeven (rekening houdend met de schaal)
            Vector2 drawPosition = Position - (currentAnimation.CurrentFrame.SourceRectangle.Size.ToVector2() * scale - currentAnimation.CurrentFrame.SourceRectangle.Size.ToVector2()) / 2;

       

            // Tekenen met de opgegeven schaal en positie
            spriteBatch.Draw(texture, drawPosition, currentAnimation.CurrentFrame.SourceRectangle, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            int screenWidth = graphicsDevice.Viewport.Width;
            int screenHeight = graphicsDevice.Viewport.Height;

            Move();

            CheckCollisionWithConsoleBounds();

            currentAnimation.Update(gameTime);
        }

        private void Move()
        {
            //CheckCollisionWithConsoleBounds();
            Vector2 movement = InputReader.ReadInput();
            if (movement.X < 0) // Voer bewegingslogica uit voor naar links lopen
            {
                isMovingLeft = true;
                SetCurrentAnimation("walkleft");
            }
            else if (movement.X > 0) // Voer bewegingslogica uit voor naar rechts lopen
            {
                isMovingLeft = false;
                SetCurrentAnimation("walkright");
            }
            else if (isMovingLeft) // Voer bewegingslogica uit voor naar links idle
            {
                SetCurrentAnimation("idleleft");
            }
            else
            {
                SetCurrentAnimation("idleright");
            }
            movementManager.Move(this);
        }

        private void CheckCollisionWithConsoleBounds()
        {
            int consoleWidth = graphicsDevice.Viewport.Width;
            int consoleHeight = graphicsDevice.Viewport.Height;

            // Aftrekken van het vaste bedrag van de breedte en hoogte
            int adjustedFrameWidth = frameWidth; // + 10;  // Vervang 10 door de gewenste waarde om eraf te halen
            int adjustedFrameHeight = frameHeight; // + 10;  // Vervang 10 door de gewenste waarde om eraf te halen

            // Maak een kopie van de huidige positie
            Vector2 currentPosition = Position;

            // Controleer of de kopie van de positie buiten de grenzen van de console valt
            if (currentPosition.X < -15)
            {
                currentPosition.X = -15;
            }
            else if (currentPosition.X + adjustedFrameWidth > consoleWidth + 15)
            {
                currentPosition.X = consoleWidth - adjustedFrameWidth + 15;
            }

            if (currentPosition.Y < -15)
            {
                currentPosition.Y = -15;
            }
            else if (currentPosition.Y + adjustedFrameHeight > consoleHeight - 10)
            {
                currentPosition.Y = consoleHeight - adjustedFrameHeight -10;
            }

            // Wijs de bijgewerkte positie terug naar de eigenschap
            Position = currentPosition;
        }




    }
}
