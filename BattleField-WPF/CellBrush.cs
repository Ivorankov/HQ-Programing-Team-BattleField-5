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
    class CellBrush : IItem
    {
        private const string FilePathToImages = "../Images/";

        public CellBrush()
        {
            this.brushDirt = CreateBrush(FilePathToImages + "Dirt.jpg"); 
            this.brushExplodedDirt = CreateBrush(FilePathToImages + "ExplodedDirt.png");
            this.brushTiny = CreateBrush(FilePathToImages + "Mine1.png");
            this.brushSmall = CreateBrush(FilePathToImages + "Mine2.png");
            this.brushMedium = CreateBrush(FilePathToImages + "Mine3.png");
            this.brushBig = CreateBrush(FilePathToImages + "Mine4.png");
            this.brushHuge = CreateBrush(FilePathToImages + "Mine5.png");
        }

        private ImageBrush brushDirt;

        private ImageBrush brushExplodedDirt;

        private ImageBrush brushTiny;

        private ImageBrush brushSmall;

        private ImageBrush brushMedium;

        private ImageBrush brushBig;

        private ImageBrush brushHuge;

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
                return this.brushTiny;
            } 
            else if(index == 3)
            {
                return this.brushSmall;
            }
            else if (index == 4)
            {
                return this.brushMedium;
            }
            else if (index == 5)
            {
                return this.brushBig;
            }
            else
            {
                return this.brushHuge;
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
