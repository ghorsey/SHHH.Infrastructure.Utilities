// <copyright file="WebClientTestFixture.cs" company="SHHH Innovations">
//   Copyright © SHHH Innovations. All rights reserved.
// </copyright>

namespace SHHH.Infrastructure.Utilities.Tests
{
    using System.IO;
    using NUnit.Framework;
    using SHHH.Infrastructure.Utilities.WebClient;

    /// <summary>
    /// <see cref="WebClientWrapper"/> test fixture
    /// </summary>
    [TestFixture]
    public class WebClientTestFixture
    {
        /// <summary>
        /// Tests the open read method.
        /// </summary>
        [Test]
        public void TestOpenReadMethod()
        {
            var client = new WebClientWrapper();

            using (var stream = client.OpenRead("http://www.google.com"))
            {
                using (var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    Assert.AreNotEqual(0, ms.Length);
                }
            }
        }
    }
}
