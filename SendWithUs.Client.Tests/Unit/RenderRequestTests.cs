﻿// Copyright © 2015 Mimeo, Inc. All rights reserved.

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
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;

    [TestClass]
    public class RenderRequestTests
    {
        [TestMethod]
        public void GetMissingRequiredProperties_NullTemplateId_YieldsTemplateId()
        {
            // Arrange
            var templateId = null as string;
            var request = new RenderRequest { TemplateId = templateId };

            // Act
            var result = request.GetMissingRequiredProperties().ToList();

            // Assert
            Assert.IsTrue(result.Contains(nameof(request.TemplateId)));
        }

        [TestMethod]
        public void GetMissingRequiredProperties_EmptyTemplateId_YieldsTemplateId()
        {
            // Arrange
            var templateId = String.Empty;
            var request = new RenderRequest { TemplateId = templateId };

            // Act
            var result = request.GetMissingRequiredProperties().ToList();

            // Assert
            Assert.IsTrue(result.Contains(nameof(request.TemplateId)));
        }
    }
}
