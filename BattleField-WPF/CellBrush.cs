//-----------------------------------------------------------------------
// <copyright file="CellBrush.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace BattleFieldWpf
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Resources;

    public class CellBrush : IItem
    {
        private const string FilePathToImages = "../Images/";

        private ImageBrush brushDirt;

        private ImageBrush brushExplodedDirt;

        private ImageBrush brushTiny;

        private ImageBrush brushSmall;

        private ImageBrush brushMedium;

        private ImageBrush brushBig;

        private ImageBrush brushHuge;

        public CellBrush()
        {
            this.brushDirt = this.CreateBrush(FilePathToImages + "Dirt.jpg");
            this.brushExplodedDirt = this.CreateBrush(FilePathToImages + "ExplodedDirt.png");
            this.brushTiny = this.CreateBrush(FilePathToImages + "Mine1.png");
            this.brushSmall = this.CreateBrush(FilePathToImages + "Mine2.png");
            this.brushMedium = this.CreateBrush(FilePathToImages + "Mine3.png");
            this.brushBig = this.CreateBrush(FilePathToImages + "Mine4.png");
            this.brushHuge = this.CreateBrush(FilePathToImages + "Mine5.png");
        }

        public ImageBrush GetBrush(int index)
        {
            if (index == 0)
            {
                return this.brushDirt;
            }
            else if (index == 1)
            {
                return this.brushExplodedDirt;
            }
            else if (index == 2)
            {
                return this.brushTiny;
            }
            else if (index == 3)
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
