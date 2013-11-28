// <copyright file="FileUtilitiesTestFixture.cs" company="SHHH Innovations">
//   Copyright © SHHH Innovations. All rights reserved.
// </copyright>

namespace SHHH.Infrastructure.Utilities.Tests
{
    using System.Drawing;
    using System.Text;
    using NUnit.Framework;
    using SHHH.Infrastructure.Utilities.IO;

    /// <summary>
    /// Test fixture for the <see cref="FileUtilities"/> class
    /// </summary>
    [TestFixture]
    public class FileUtilitiesTestFixture
    {
        /// <summary>
        /// Tests the file exists method.
        /// </summary>
        [Test]
        public void TestFileExistsMethod()
        {
            var utils = new FileUtilities();

            Assert.IsTrue(utils.FileExists("100x150.png"));
            Assert.IsFalse(utils.FileExists("whoWhat.fil"));
        }

        /// <summary>
        /// Tests the image from path and graphics from image methods.
        /// </summary>
        [Test]
        public void TestImageFromPathAndGraphicsFromImageMethods()
        {
            var utils = new FileUtilities();
            var image = utils.ImageFromFile("100x150.png");
            var bmp = new Bitmap(image, 100, 150);
            var graphics = utils.GraphicsFromImage(bmp);

            Assert.AreEqual(100, image.Width);
            Assert.AreEqual(150, image.Height);

            Assert.IsNotNull(graphics);
        }

        /// <summary>
        /// Tests the write read all bytes.
        /// </summary>
        [Test]
        public void TestWriteReadAllBytes()
        {
            var utils = new FileUtilities();

            const string Text = "Sample";

            var buffer = Encoding.ASCII.GetBytes(Text);

            utils.WriteAllBytes("temp.txt", buffer);
            var fromFile = utils.ReadAllBytes("temp.txt");

            Assert.AreEqual(Text, Encoding.ASCII.GetString(fromFile));
        }
    }
}
