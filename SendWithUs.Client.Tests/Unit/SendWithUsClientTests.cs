﻿// Copyright © 2015 Mimeo, Inc.

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace SendWithUs.Client.Tests.Unit
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SendWithUs.Client;

    [TestClass]
    public class SendWithUsClientTests
    {
        #region SendAsync

        [TestMethod]
        public void SendAsync_NullRequest_Throws()
        {
            // Arrange
            var apiKey = TestHelper.GetUniqueId();
            var client = new SendWithUsClient(apiKey);

            // Act
            var exception = TestHelper.CaptureException(() => client.SendAsync(null));

            // Assert
            Assert.IsInstanceOfType(exception, typeof(ArgumentNullException));
        }

        #endregion

        #region DripCampaignActivateAsync

        [TestMethod]
        public void SingleAsync_NullRequest_Throws()
        {
            // Arrange
            var apiKey = TestHelper.GetUniqueId();
            var client = new SendWithUsClient(apiKey);

            // Act
            var exception = TestHelper.CaptureException(() => client.SingleAsync(null));

            // Assert
            Assert.IsInstanceOfType(exception, typeof(ArgumentNullException));
        }

        #endregion

        #region BatchAsync

        [TestMethod]
        public void BatchAsync_NullRequest_Throws()
        {
            // Arrange
            var apiKey = TestHelper.GetUniqueId();
            var client = new SendWithUsClient(apiKey);

            // Act
            var exception = TestHelper.CaptureException(() => client.BatchAsync(null));

            // Assert
            Assert.IsInstanceOfType(exception, typeof(ArgumentException));
        }

        #endregion
    }
}
