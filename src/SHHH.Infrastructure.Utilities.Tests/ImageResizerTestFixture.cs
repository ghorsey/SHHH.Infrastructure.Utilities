// <copyright file="ImageResizerTestFixture.cs" company="SHHH Innovations">
//   Copyright © SHHH Innovations. All rights reserved.
// </copyright>

namespace SHHH.Infrastructure.Utilities.Tests
{
    using System.Drawing;
    using System.IO;
    using NUnit.Framework;
    using SHHH.Infrastructure.Utilities.Graphics;
    using SHHH.Infrastructure.Utilities.IO;

    /// <summary>
    /// <see cref="ImageResizer"/> test fixture
    /// </summary>
    [TestFixture]
    public class ImageResizerTestFixture
    {
        /// <summary>
        /// Tests the resize image method.
        /// </summary>
        [Test]
        public void TestResizeImageMethod()
        {
            var resizer = new ImageResizer(new FileUtilities());

            using (var buffer33X50 = new MemoryStream(resizer.ResizeImage("100x150.png", 50, 50)))
            {
                using (var bmp33X50 = new Bitmap(buffer33X50))
                {
                    Assert.AreEqual(33, bmp33X50.Width);
                    Assert.AreEqual(50, bmp33X50.Height);
                }
            }

            using (var buffer50X33 = new MemoryStream(resizer.ResizeImage("150x100.png", 50, 50)))
            {
                using (var bmp50X33 = new Bitmap(buffer50X33))
                {
                    Assert.AreEqual(50, bmp50X33.Width);
                    Assert.AreEqual(33, bmp50X33.Height);
                }
            }

            using (var bufferFits = new MemoryStream(resizer.ResizeImage("100x150.png", 150, 150)))
            {
                using (var bmpFits = new Bitmap(bufferFits))
                {
                    Assert.AreEqual(100, bmpFits.Width);
                    Assert.AreEqual(150, bmpFits.Height);
                }
            }
        }
    }
}
