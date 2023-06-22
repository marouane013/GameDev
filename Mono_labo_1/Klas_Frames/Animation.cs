﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_labo_1.Klas_Frames
{
    internal class Animation
    {
        //CONSTRUCTOR
        public Animation()
        {
            frames = new List<AnimationFrame>();
        }



        //FIELDS
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;
        private double secondCounter = 0;




        //METHODS
        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 15;

            if (secondCounter >= 1d/fps)
            {
                counter++;
                secondCounter = 0;  
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

        public void GetAnimationFromTextureRow(int row, int rowSize)
        {
            for (int i = 0; i < rowSize; i++)
            {
                frames.Add(new AnimationFrame(new Rectangle(64 * i, 64 * (row-1), 64, 64)));
            }
        }
        public void GetFramesFromTextureProperties(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;

            for (int y = 0; y <= height-heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width-widthOfFrame; x+= widthOfFrame)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }
        }


    }
}
