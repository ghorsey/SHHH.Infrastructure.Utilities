// <copyright file="ImageResizer.cs" company="SHHH Innovations">
//   Copyright © SHHH Innovations. All rights reserved.
// </copyright>
namespace SHHH.Infrastructure.Utilities.Graphics
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using SHHH.Infrastructure.Utilities.IO;

    /// <summary>
    /// Implementation of a utility class that resizes images
    /// </summary>
    public class ImageResizer : IImageResizer
    {
        /// <summary>
        /// The file utilities
        /// </summary>
        private readonly IFileUtilities fileUtilities;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageResizer"/> class.
        /// </summary>
        /// <param name="fileUtilities">The file utilities.</param>
        public ImageResizer(IFileUtilities fileUtilities)
        {
            this.fileUtilities = fileUtilities;
        }

        /// <summary>
        /// Resizes the image.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <returns>
        /// A <see cref="byte" /> array of the resized image
        /// </returns>
        public byte[] ResizeImage(string path, int height, int width)
        {
            var image = this.fileUtilities.ImageFromFile(path);
            using (var dst = this.CreateScaledBitmap(image, width, height))
            {
                using (var g = this.fileUtilities.GraphicsFromImage(dst))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(image, 0, 0, dst.Width, dst.Height);

                    var result = new System.IO.MemoryStream();
                    dst.Save(result, System.Drawing.Imaging.ImageFormat.Png);
                    result.Position = 0; // reset position;

                    var buffer = result.GetBuffer();
                    return buffer;
                }
            }
        }

        /// <summary>
        /// Creates the size of the constrained.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="maxWidth">Width of the max.</param>
        /// <param name="maxHeight">Height of the max.</param>
        /// <returns>The constrained size</returns>
        private Size CreateConstrainedSize(Size original, int maxWidth, int maxHeight)
        {
            if (original.Width <= maxWidth && original.Height <= maxHeight)
            {
                return original; // we're done, the image fits within our max constraints
            }

            float maxRatio = (float)maxWidth / maxHeight;
            float sizeRatio = (float)original.Width / original.Height;

            if (sizeRatio < maxRatio)
            {
                return new Size((int)Math.Round(maxHeight * sizeRatio), maxHeight);
            }
            
            return new Size(maxWidth, (int)Math.Round(maxWidth / sizeRatio));
        }

        /// <summary>
        /// Creates the scaled bitmap.
        /// </summary>
        /// <param name="src">The SRC.</param>
        /// <param name="maxWidth">Width of the max.</param>
        /// <param name="maxHeight">Height of the max.</param>
        /// <returns>The scaled image</returns>
        private Bitmap CreateScaledBitmap(Image src, int maxWidth, int maxHeight)
        {
            Size newSize = this.CreateConstrainedSize(src.Size, maxWidth, maxHeight);

            return new Bitmap(newSize.Width, newSize.Height);
        }
    }
}