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
    using System.Linq;
    using Moq;

    [TestClass]
    public class BatchRequestTests
    {
        [TestMethod]
        public void GetResponseType_Always_Throws()
        {
            // Arrange
            var request = new BatchRequest(null);

            // Act
            var exception = TestHelper.CaptureException(() => request.GetResponseType());

            // Assert
            Assert.IsInstanceOfType(exception, typeof(NotSupportedException));
        }

        [TestMethod]
        public void Validate_AllItemsValid_ReturnsSelf()
        {
            // Arrange
            var items = Enumerable.Repeat(1, 10).Select(x => new Mock<IRequest>()).ToList();
            var request = new BatchRequest(items.Select(m => m.Object));

            items.Select(m => m.Setup(r => r.Validate()).Returns(m.Object));

            // Act
            var result = request.Validate();

            // Assert
            Assert.AreSame(request, result);
        }

        [TestMethod]
        public void Validate_SomeItemsInvalid_Throws()
        {
            // Arrange
            var invalidCount = 0;
            var items = Enumerable.Repeat(1, 10).Select(x => new Mock<IRequest>()).ToList();
            var request = new BatchRequest(items.Select(m => m.Object));
            
            for (var index = 0; index < items.Count; index += 1)
            {
                if (index % 2 == 0)
                {
                    items[index].Setup(r => r.Validate()).Throws(new ValidationException(null));
                    invalidCount += 1;
                }
            }

            // Act
            var exception = TestHelper.CaptureException(() => request.Validate());

            // Assert
            Assert.IsInstanceOfType(exception, typeof(AggregateException));
            Assert.AreEqual(invalidCount, ((AggregateException)exception).InnerExceptions.Count);
        }
    }
}
