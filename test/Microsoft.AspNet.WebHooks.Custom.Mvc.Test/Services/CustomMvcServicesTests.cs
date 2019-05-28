// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Config;
using Microsoft.AspNet.WebHooks.Custom.Api.Config;
using Microsoft.Web.Mvc.Services;
using Xunit;

namespace System.Web.Mvc
{
    [Collection("ConfigCollection")]
    public class CustomMvcServicesTests
    {
        public CustomMvcServicesTests()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebHooksConfigMvc.Initialize(config);
        }

        [Fact]
        public void GetFilterProviders_ReturnsSingletonInstance()
        {
            // Act
            var actual1 = CustomMvcServices.GetFilterProviders();
            var actual2 = CustomMvcServices.GetFilterProviders();

            // Assert
            Assert.Same(actual1, actual2);
        }
    }
}
