// <copyright file="WebClientWrapper.cs" company="SHHH Innovations">
//   Copyright © SHHH Innovations. All rights reserved.
// </copyright>
namespace SHHH.Infrastructure.Utilities.WebClient
{
    using System.IO;
    using System.Net;

    /// <summary>
    /// A wrapper class for <see cref="WebClient"/> that implements the <see cref="IWebClient"/> interface
    /// </summary>
    public class WebClientWrapper : IWebClient
    {
        /// <summary>
        /// The web client instance.
        /// </summary>
        private readonly WebClient webClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebClientWrapper"/> class.
        /// </summary>
        public WebClientWrapper()
        {
            this.webClient = new WebClient();
        }

        /// <summary>
        /// Opens a readable stream for the data downloaded from the specified address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>
        /// A readable <see cref="Stream" /> for the data downloaded at the specified address.
        /// </returns>
        public Stream OpenRead(string address)
        {
            return this.webClient.OpenRead(address);
        }
    }
}