// <copyright file="IImageResizer.cs" company="SHHH Innovations">
//   Copyright © SHHH Innovations. All rights reserved.
// </copyright>
namespace SHHH.Infrastructure.Utilities.Graphics
{
    /// <summary>
    /// A utility which will resize an image.
    /// </summary>
    public interface IImageResizer
    {
        /// <summary>
        /// Resizes the image.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <returns>A <see cref="byte"/> array of the resized image</returns>
        byte[] ResizeImage(string path, int height, int width);
    }
}