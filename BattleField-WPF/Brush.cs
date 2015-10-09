using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace BattleField_WPF
{
    class Brush : IItem
    {
        private const string FilePathToImages = "../Images/";

        public Brush()
        {
            this.brushDirt = CreateBrush(FilePathToImages + "Dirt.jpg");// This was the first way it actually worked.. from 75 on load to 24mb ram 
            this.brushExplodedDirt = CreateBrush(FilePathToImages + "ExplodedDirt.png");// Dheam went from over 120mb ram when exploded dirt shows to 40 ish(put smaller imgs also)
            this.brushMine1 = CreateBrush(FilePathToImages + "Mine1.png");
            this.brushMine2 = CreateBrush(FilePathToImages + "Mine2.png");
            this.brushMine3 = CreateBrush(FilePathToImages + "Mine3.png");
            this.brushMine4 = CreateBrush(FilePathToImages + "Mine4.png");
            this.brushMine5 = CreateBrush(FilePathToImages + "Mine5.png");// Stays at 30-something mbs sweeeeettttt 
        }

        private ImageBrush brushDirt;

        private ImageBrush brushExplodedDirt;

        private ImageBrush brushMine1;

        private ImageBrush brushMine2;

        private ImageBrush brushMine3;

        private ImageBrush brushMine4;

        private ImageBrush brushMine5;

        public ImageBrush GetBrush(int index)
        {
            if (index == 0)
            {
                return this.brushDirt;
            }
            else if(index == 1)
            {
                return this.brushExplodedDirt;
            }
            else if (index == 2)
            {
                return this.brushMine1;
            } 
            else if(index == 3)
            {
                return this.brushMine2;
            }
            else if (index == 4)
            {
                return this.brushMine3;
            }
            else if (index == 5)
            {
                return this.brushMine4;
            }
            else
            {
                return this.brushMine5;
            }
        }

        private ImageBrush CreateBrush(string filePath)
        {
            Uri uriPathToImg = new Uri(filePath, UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(uriPathToImg);
            BitmapFrame imageData = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = imageData;

            return brush;
        }
    }
}
