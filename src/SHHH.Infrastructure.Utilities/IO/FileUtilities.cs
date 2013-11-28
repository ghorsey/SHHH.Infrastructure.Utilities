// <copyright file="FileUtilities.cs" company="SHHH Innovations">
//   Copyright © SHHH Innovations. All rights reserved.
// </copyright>
namespace SHHH.Infrastructure.Utilities.IO
{
    using System.Drawing;
    using System.IO;

    /// <summary>
    /// Implementations of the <see cref="IFileUtilities"/> interface
    /// </summary>
    public class FileUtilities : IFileUtilities
    {
        /// <summary>
        /// Checks if a file the exists.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>
        ///   <c>true</c> if the file exists; otherwise <c>false</c>
        /// </returns>
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Creates an images from a file on the file system.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>
        /// Creates a <see cref="Image" /> from the specified image path
        /// </returns>
        public Image ImageFromFile(string path)
        {
            return Image.FromFile(path);
        }

        /// <summary>
        /// Creates a new <see cref="Graphics" /> from the specified <see cref="Image" />.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <returns>
        /// A new <see cref="Graphics" />
        /// </returns>
        public Graphics GraphicsFromImage(Image image)
        {
            return Graphics.FromImage(image);
        }

        /// <summary>
        /// Opens a binary file, reads all the bytes into a byte array, closes the file
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>
        /// A byte array representing the file
        /// </returns>
        public byte[] ReadAllBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        /// <summary>
        /// Creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="buffer">The buffer.</param>
        public void WriteAllBytes(string path, byte[] buffer)
        {
            File.WriteAllBytes(path, buffer);
        }
    }
}