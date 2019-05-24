// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Config;
using Microsoft.Web.Mvc.Services;
using Xunit;

namespace System.Web.Mvc
{
    [Collection("ConfigCollection")]
    public class CustomServicesTests
    {
        public CustomServicesTests()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebHooksConfig.Initialize(config);
        }

        [Fact]
        public void GetFilterProviders_ReturnsSingletonInstance()
        {
            // Act
            var actual1 = CustomServicesMvc.GetFilterProviders();
            var actual2 = CustomServicesMvc.GetFilterProviders();

            // Assert
            Assert.Same(actual1, actual2);
        }
    }
}
