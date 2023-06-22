using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono_labo_1.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mono_labo_1.Klas_Caracters
{
    internal class Block : IGameObject
    {
        private Texture2D texture;

        public Block(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
