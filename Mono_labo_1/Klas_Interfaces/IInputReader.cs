using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_labo_1.Klas_Interfaces
{
    internal interface IInputReader
    {
        Vector2 ReadInput();

        public bool IsDestinationInput { get; }
    }
}
