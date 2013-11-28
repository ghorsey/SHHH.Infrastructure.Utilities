// <copyright file="IWebClient.cs" company="SHHH Innovations">
//   Copyright © SHHH Innovations. All rights reserved.
// </copyright>
namespace SHHH.Infrastructure.Utilities.WebClient
{
    using System.IO;
    using System.Net;

    /// <summary>
    /// A wrapper for an <see cref="WebClient"/> object.
    /// </summary>
    public interface IWebClient
    {
        /// <summary>
        /// Opens a readable stream for the data downloaded from the specified address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>A readable <see cref="Stream"/> for the data downloaded at the specified address.</returns>
        Stream OpenRead(string address);
    }
}