using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Mono_labo_1.Klas_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_labo_1.Klas_Input
{
    internal class MouseReader : IInputReader
    {
        public bool IsDestinationInput => true;

        public bool IsKeyPressed(Keys key)
        {
            throw new NotImplementedException();
        }

        public Vector2 ReadInput()
        {
            throw new NotImplementedException();
        }
    }
}


