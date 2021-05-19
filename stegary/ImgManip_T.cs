using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stegary
{
    public class ImageEventArgs : EventArgs
    {
        public Bitmap bmap { get; set; }
        public string secretMessage { get; set; }
        public byte[] FileBytes { get; set; }

    }

    class ImgManip_T
    {
        public event EventHandler<ImageEventArgs> ImageFinished;
        public string message { get; set; }
        public int bitSelecT { get; set; }
        public bool crypted = false;
        private const int reserved = 10;



        protected virtual void OnImageFinished(Bitmap bmap, string secretMessage)
        {

            ImageFinished?.Invoke(this, new ImageEventArgs() { bmap = bmap, secretMessage = secretMessage });
        }



        public void Insert_T(object bmp,bool useOpap)
        {
            DateTime start = DateTime.Now;
            Opap methodOPAP = new Opap();
            Bitmap bmap = (Bitmap) bmp;
            int k = 0, i = 0, j = 0, p = 0;
            int newR, newG, newB;
            int bitSelect = bitSelecT, bitMove;
            Color theColor = new Color();
            Color originColor= new Color();
            int msgL = message.Length;
            int intCounter = 0;

            //calcul de pas
            float stop = ((float)msgL * 8) / ((float)bitSelect * 3);
            if (8 % bitSelect != 0)
            {
                int stopPixelL = (bitSelect - (8 % bitSelect)) * msgL;
                stop = (((float)msgL * 8) + (float)stopPixelL) / ((float)bitSelect * 3);
            }

            if (stop % 1 != 0)
            {
                stop++;
            }
            int stride = (bmap.Height * bmap.Width - reserved) / (int)stop;




            //insertion du watermark "YOZ" sur 4 pixels debut

            string watermarked = "yoz";


            theColor = bmap.GetPixel(j, i);
            newR = theColor.R - theColor.R % 4 + 1;
            newG = theColor.G - theColor.G % 4 + 2;
            newB = theColor.B - theColor.B % 4 + 3;
            theColor = Color.FromArgb(newR, newG, newB);
            bmap.SetPixel(j, i, theColor);
            j++;
            theColor = bmap.GetPixel(j, i);
            newR = theColor.R - theColor.R % 4 + 1;
            newG = theColor.G - theColor.G % 4 + 3;
            newB = theColor.B - theColor.B % 4 + 3;
            theColor = Color.FromArgb(newR, newG, newB);
            bmap.SetPixel(j, i, theColor);
            j++;
            theColor = bmap.GetPixel(j, i);
            newR = theColor.R - theColor.R % 4 + 2;
            newG = theColor.G - theColor.G % 4 + 1; //if crypted we insert "yoc" instead of "yoz"
            newB = theColor.B - theColor.B % 4 + 2; if(crypted) newB = theColor.B - theColor.B % 4 + 3;
            theColor = Color.FromArgb(newR, newG, newB);
            bmap.SetPixel(j, i, theColor);
            j++;
            theColor = bmap.GetPixel(j, i);
            newR = theColor.R - theColor.R % 4 + 2; if(crypted) newR = theColor.R - theColor.R % 4 + 0;
            newG = theColor.G - theColor.G % 4 + 3; if(crypted) newG = theColor.G - theColor.G % 4 + 2;
            newB = theColor.B - theColor.B % 4 + 1; if(crypted) newB = theColor.B - theColor.B % 4 + 1;
            theColor = Color.FromArgb(newR, newG, newB);
            bmap.SetPixel(j, i, theColor);
            j++;




            //insertion de la taille sur 6 pixels

            while (intCounter < 30)
            {
                theColor = bmap.GetPixel(j, i);
                newR = theColor.R - theColor.R % 4 + msgL % 4;
                msgL >>= 2;
                newG = theColor.G - theColor.G % 4 + msgL % 4;
                msgL >>= 2;
                newB = theColor.B - theColor.B % 4 + msgL % 4;
                msgL >>= 2;
                theColor = Color.FromArgb(newR, newG, newB);
                bmap.SetPixel(j, i, theColor);
                j++;
                intCounter += 6;
            }

            theColor = bmap.GetPixel(j, i);
            newR = theColor.R - theColor.R % 4 + msgL % 4; // 31 +32 eme bit du int
            int temp = bitSelect;
            newG = theColor.G - theColor.G % 4 + temp % 4; // 4 bits pour le bitSelect
            temp >>= 2;
            newB = theColor.B - theColor.B % 4 + temp % 4;

            theColor = Color.FromArgb(newR, newG, newB);
            bmap.SetPixel(j, i, theColor);

            j = reserved;


            //insertion du message
            for (k = 0; k < message.Length; k++)
            {
                char letter = Convert.ToChar(message.Substring(k, 1));
                int letterI = Convert.ToInt32(letter);

                bitMove = bitSelect;
                while ((bitMove - bitSelect) < 8)
                {

                    theColor = bmap.GetPixel(j, i);
                    originColor = theColor;


                    while (p < 3 && (bitMove - bitSelect) < 8)
                    {

                        switch (p)
                        {
                            case 0:
                                newR = theColor.R - theColor.R % (int)Math.Pow(2, bitSelect);
                                newR += letterI % (int)Math.Pow(2, bitSelect);
                                letterI >>= bitSelect;
                                theColor = Color.FromArgb(newR, theColor.G, theColor.B);

                                break;

                            case 1:
                                newG = theColor.G - theColor.G % (int)Math.Pow(2, bitSelect);
                                newG += letterI % (int)Math.Pow(2, bitSelect);
                                letterI >>= bitSelect;
                                theColor = Color.FromArgb(theColor.R, newG, theColor.B);

                                break;

                            case 2:
                                newB = theColor.B - theColor.B % (int)Math.Pow(2, bitSelect);
                                newB += letterI % (int)Math.Pow(2, bitSelect);
                                letterI >>= bitSelect;
                                theColor = Color.FromArgb(theColor.R, theColor.G, newB);

                                break;
                        }

                        bitMove += bitSelect;
                        p++;
                    }

                    bmap.SetPixel(j, i, theColor);
                    if (useOpap)
                    {
                        bmap.SetPixel(j,i,methodOPAP.OPAP(originColor, theColor, bitSelect));

                    }

                    if (p == 3)
                    {
                        p = 0;
                        if (j + stride <= bmap.Width - 1)
                        {
                            j += stride;

                        }
                        else
                        {
                            int stridesLeft;
                            stridesLeft = stride - (bmap.Width - 1 - j);
                            i++;

                            while (stridesLeft > bmap.Width)
                            {
                                stridesLeft -= bmap.Width;
                                i++;
                            }

                            j = stridesLeft - 1;
                        }
                    }


                }
            }

            TimeSpan timeItTook = DateTime.Now - start;
            Console.WriteLine("Time elapsed : Minutes: {0}  Seconds: {1} Milliseconds: {2}", timeItTook.Minutes, timeItTook.Seconds, timeItTook.Milliseconds);
            crypted = false;
            OnImageFinished(bmap, null);
        }


        public void Extract_T(object bmp)
        {
            Bitmap bmap = (Bitmap)bmp;
            string text = "";
            Color theColor = new Color();
            int i = 0, j = 0;
            int charCounter = 0, bitSelect = 0, size = 0, textInt = 0;

            float stop;

            // recuperer le bitSelect et la taille du message

            theColor = bmap.GetPixel(9, i);
            bitSelect += theColor.B % 4;
            bitSelect <<= 2;
            bitSelect += theColor.G % 4;
            size += theColor.R % 4;
            size <<= 2;

            for (j = 8; j >= 4; j--)
            {
                theColor = bmap.GetPixel(j, i);
                size += theColor.B % 4;
                size <<= 2;
                size += theColor.G % 4;
                size <<= 2;
                size += theColor.R % 4;
                if (j != 4)
                {
                    size <<= 2;
                }
            }


            byte[] textBytes = new byte[size];
            int k = 0;
            //recuperer le message
            // first we have to know the exact finish line

            int stopPixelL = 0;
            stop = ((float)size * 8) / ((float)bitSelect * 3);
            if (8 % bitSelect != 0)
            {
                stopPixelL = (bitSelect - (8 % bitSelect)) * size;
                stop = (((float)size * 8) + (float)stopPixelL) / ((float)bitSelect * 3);
            }

            if (stop % 1 != 0)
            {
                stop++;
            }
            int stride = (bmap.Height * bmap.Width - reserved) / (int)stop;
            if (stop % 1 != 0)
            {
                stop--;
            }

            int blanks = ((int)stop - 1) * (stride - 1);
            stop += reserved;

            i = ((int)stop + blanks) / bmap.Width;
            j = (((int)stop + blanks) % bmap.Width) - 1;
            float border = ((float)(int)stop + blanks) / (float)bmap.Width;
            if (border % 1 == 0)
            {
                if (i > 0) { i--; }
                j = bmap.Width - 1;
            }
            if (stop % 1 != 0)
            { //+1 pas
                if (j + stride <= bmap.Width - 1)
                {
                    theColor = bmap.GetPixel(j + stride, i);
                }
                else
                {
                    int jump = i + 1;
                    int j2 = stride - (bmap.Width - 1 - j);

                    while (j2 > bmap.Width)
                    {
                        j2 -= bmap.Width;
                        jump++;
                    }

                    j2--;
                    theColor = bmap.GetPixel(j2, jump);

                }


                int stopPixel = (size * 8) % (bitSelect * 3); // bit left always < bitselect *3
                if (8 % bitSelect != 0)
                {
                    stopPixel = ((size * 8) + stopPixelL) % (bitSelect * 3);
                }
                float stopRGB = (float)stopPixel / (float)bitSelect; // always < 3
                bool R = false, G = false, B = false;
                switch ((int)stopRGB)
                {
                    case 0:
                        R = stopRGB > 0;
                        G = false;
                        B = false;
                        break;
                    case 1:
                        R = true;
                        G = stopRGB > 1;
                        B = false;
                        break;
                    case 2:

                        R = true;
                        G = true;
                        B = stopRGB > 2;
                        break;
                }



                if (B)
                {
                    textInt += theColor.B % (int)Math.Pow(2, bitSelect);
                    charCounter += bitSelect;
                    if (charCounter >= 8)
                    {
                        char letter = Convert.ToChar(textInt);
                        textBytes[k] = Convert.ToByte(letter);
                        k++;
                        charCounter = 0;
                        textInt = 0;

                    }
                    else
                    {
                        textInt <<= bitSelect;
                        textInt -= textInt % (int)Math.Pow(2, bitSelect);
                    }
                }
                if (G)
                {
                    textInt += theColor.G % (int)Math.Pow(2, bitSelect);
                    charCounter += bitSelect;
                    if (charCounter >= 8)
                    {
                        char letter = Convert.ToChar(textInt);
                        textBytes[k] = Convert.ToByte(letter);
                        k++;
                        charCounter = 0;
                        textInt = 0;
                    }
                    else
                    {
                        textInt <<= bitSelect;
                        textInt -= textInt % (int)Math.Pow(2, bitSelect);
                    }
                }
                if (R)
                {
                    textInt += theColor.R % (int)Math.Pow(2, bitSelect);
                    charCounter += bitSelect;
                    if (charCounter >= 8)
                    {
                        char letter = Convert.ToChar(textInt);
                        textBytes[k] = Convert.ToByte(letter);
                        k++;
                        charCounter = 0;
                        textInt = 0;
                    }
                    else
                    {
                        textInt <<= bitSelect;
                        textInt -= textInt % (int)Math.Pow(2, bitSelect);
                    }
                }


            }


            while (i >= 0)
            {

                if (j <= reserved - 1 && i == 0)
                {
                    break;
                }

                theColor = bmap.GetPixel(j, i);

                textInt += theColor.B % (int)Math.Pow(2, bitSelect);
                charCounter += bitSelect;
                if (charCounter >= 8)
                {
                    char letter = Convert.ToChar(textInt);
                    textBytes[k] = Convert.ToByte(letter);
                    k++;
                    charCounter = 0;
                    textInt = 0;

                }
                else
                {
                    textInt <<= bitSelect;
                    textInt -= textInt % (int)Math.Pow(2, bitSelect);
                }

                textInt += theColor.G % (int)Math.Pow(2, bitSelect);
                charCounter += bitSelect;
                if (charCounter >= 8)
                {
                    char letter = Convert.ToChar(textInt);
                    textBytes[k] = Convert.ToByte(letter);
                    k++;
                    charCounter = 0;
                    textInt = 0;
                }
                else
                {
                    textInt <<= bitSelect;
                    textInt -= textInt % (int)Math.Pow(2, bitSelect);
                }

                textInt += theColor.R % (int)Math.Pow(2, bitSelect);
                charCounter += bitSelect;
                if (charCounter >= 8)
                {
                    char letter = Convert.ToChar(textInt);
                    textBytes[k] = Convert.ToByte(letter);
                    k++;
                    charCounter = 0;
                    textInt = 0;
                }
                else
                {
                    textInt <<= bitSelect;
                    textInt -= textInt % (int)Math.Pow(2, bitSelect);
                }



                if (j - stride >= 0)
                {
                    j -= stride;
                }
                else
                {
                    int line = stride - j;
                    i--;

                    while (line > bmap.Width)
                    {
                        line -= bmap.Width;
                        i--;
                    }

                    j = bmap.Width - line;
                }

            }

            

            Array.Reverse(textBytes, 0, textBytes.Length);
            text += Encoding.Default.GetString(textBytes);
            

            OnImageFinished(null, text);


        }
    }
}
