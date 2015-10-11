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

    /// <summary>
    /// Creates and stores ImageBrush objects and passed reference to them
    /// </summary>
    public class CellBrush 
    {
        /// <summary>
        /// Stores the path to the Images folder
        /// </summary>
        private const string FilePathToImages = "../Images/";

        /// <summary>
        /// Stores the <see cref="ImageBrush"/>  objects
        /// </summary>
        private Dictionary<string, ImageBrush> brushes = new Dictionary<string, ImageBrush>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CellBrush" /> class
        /// </summary>
        public CellBrush()
        {
            this.brushes = new Dictionary<string, ImageBrush>();
        }

        /// <summary>
        /// Get a reference to <see cref="ImageBrush"/> object
        /// </summary>
        /// <param name="fileName">Used to identify the specific object</param>
        /// <returns>Reference to <see cref="ImageBrush"/> object </returns>
        public ImageBrush GetBrush(string fileName)
        {
            if (!this.brushes.ContainsKey(fileName))
            {
                this.brushes[fileName] = this.CreateBrush(CellBrush.FilePathToImages + fileName + ".jpg");
            }

            return this.brushes[fileName];
        }

        /// <summary>
        /// Creates <see cref="ImageBrush"/>  objects
        /// </summary>
        /// <param name="filePath">File path to image</param>
        /// <returns><see cref="ImageBrush"/> object</returns>
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
