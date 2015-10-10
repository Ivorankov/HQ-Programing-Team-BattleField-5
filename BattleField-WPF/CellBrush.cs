//-----------------------------------------------------------------------
// <copyright file="CellBrush.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace BattleFieldWpf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Resources;

    public class CellBrush 
    {
        private const string FilePathToImages = "../Images/";

        private Dictionary<string, ImageBrush> brushes = new Dictionary<string, ImageBrush>();

        public CellBrush()
        {
            this.brushes = new Dictionary<string, ImageBrush>();
        }

        public ImageBrush GetBrush(string fileName)
        {
            if (!this.brushes.ContainsKey(fileName))
            {
                this.brushes[fileName] = this.CreateBrush(CellBrush.FilePathToImages + fileName + ".jpg");
            }

            return this.brushes[fileName];
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
