using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stegary
{
    class Opap
    {
        public Color OPAP(Color cover, Color stego, int bitselect)
        {

            int deltaR, deltaG, deltaB;
            int opapR = 0, opapG = 0, opapB = 0;
            Color coverC, stegoC, opapC;
            coverC = cover;
            stegoC = stego;
            deltaR = stegoC.R - coverC.R;
           // Console.WriteLine("deltaR :"+deltaR);
            deltaG = stegoC.G - coverC.G; 
          //  Console.WriteLine("deltaG :" + deltaG);
            deltaB = stegoC.B - coverC.B;
           // Console.WriteLine("deltaB :" + deltaB);

            // ********************************* Red component ***************************************
            if (((int)Math.Pow(2, bitselect - 1) < deltaR) && (deltaR < (int)Math.Pow(2, bitselect)))
            {
                if (stegoC.R >= (int)Math.Pow(2, bitselect))
                {
                    opapR = stegoC.R - (int)Math.Pow(2, bitselect);
                }
                else
                {
                    opapR = stegoC.R;
                }

            }

            if (((-1) * (int)Math.Pow(2, bitselect - 1) <= deltaR) && (deltaR <= (int)Math.Pow(2, bitselect - 1)))
            {
                opapR = stegoC.R;
            }

            if (((-1) * (int)Math.Pow(2, bitselect) < deltaR) && (deltaR < (-1) * (int)Math.Pow(2, bitselect - 1)))
            {
                if (stegoC.R < 256 - (int)Math.Pow(2, bitselect))
                {
                    opapR = stegoC.R + (int)Math.Pow(2, bitselect);
                }
                else
                {
                    opapR = stegoC.R;
                }
            }

            // ********************************* Green component **************************************
            if (((int)Math.Pow(2, bitselect - 1) < deltaG) && (deltaG < (int)Math.Pow(2, bitselect)))
            {
                if (stegoC.G >= (int)Math.Pow(2, bitselect))
                {
                    opapG = stegoC.G - (int)Math.Pow(2, bitselect);
                }
                else
                {
                    opapG = stegoC.G;
                }

            }

            if (((-1) * (int)Math.Pow(2, bitselect - 1) <= deltaG) && (deltaG <= (int)Math.Pow(2, bitselect - 1)))
            {
                opapG = stegoC.G;
            }

            if (((-1) * (int)Math.Pow(2, bitselect) < deltaG) && (deltaG < (-1) * (int)Math.Pow(2, bitselect - 1)))
            {
                if (stegoC.G < 256 - (int)Math.Pow(2, bitselect))
                {
                    opapG = stegoC.G + (int)Math.Pow(2, bitselect);
                }
                else
                {
                    opapG = stegoC.G;
                }
            }

            // ********************************* Blue component ***************************************
            if (((int)Math.Pow(2, bitselect - 1) < deltaB) && (deltaB < (int)Math.Pow(2, bitselect)))
            {
                if (stegoC.B >= (int)Math.Pow(2, bitselect))
                {
                    opapB = stegoC.B - (int)Math.Pow(2, bitselect);
                }
                else
                {
                    opapB = stegoC.B;
                }

            }

            if (((-1) * (int)Math.Pow(2, bitselect - 1) <= deltaB) && (deltaB <= (int)Math.Pow(2, bitselect - 1)))
            {
                opapB = stegoC.B;
            }

            if (((-1) * (int)Math.Pow(2, bitselect) < deltaB) && (deltaB < (-1) * (int)Math.Pow(2, bitselect - 1)))
            {
                if (stegoC.B < 256 - (int)Math.Pow(2, bitselect))
                {
                    opapB = stegoC.B + (int)Math.Pow(2, bitselect);
                }
                else
                {
                    opapB = stegoC.B;
                }
            }

            opapC = Color.FromArgb(opapR, opapG, opapB);
            return opapC;
        }
    }
}
