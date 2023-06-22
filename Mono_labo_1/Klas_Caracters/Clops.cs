using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mono_labo_1.interfaces;
using Mono_labo_1.Klas_Frames;
using Mono_labo_1.Klas_Interfaces;
using Mono_labo_1.Klas_Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_labo_1.Caracters
{
     class Clops : IGameObject, IMovable
    {
       

        //PROPERTIES
        private Texture2D texture;
        Animation animation;
        private MovementManager movementManager;

        public Vector2 Position { get ; set ; }
        public Vector2 Speed { get ; set ; }
        public IInputReader InputReader { get ; set ; }







        //CONSTRUCTOR
        public Clops(Texture2D texture, IInputReader inputReader)
        {
            this.texture = texture;
            this.InputReader = inputReader;
            animation = new Animation();
            movementManager = new MovementManager();    
            animation.GetAnimationFromTextureRow(2, 12);
            Position = new Vector2(1, 1);
            Speed = new Vector2(2,2);



            //animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 15, 20);
        }

      






        //METHODS
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,Position, animation.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            
            Move();

            animation.Update(gameTime);
            
        }

        private void Move()
        {
            movementManager.Move(this); 
            

        }


    }
}
