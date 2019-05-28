// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Microsoft.AspNet.WebHooks;
using Microsoft.AspNet.WebHooks.Config;
using Microsoft.AspNet.WebHooks.Custom.Api.Config;
using Microsoft.AspNet.WebHooks.Utilities;

namespace Microsoft.Web.Mvc.Services
{
    /// <summary>
    /// Provides singleton instances of custom WebHook services such as a default
    /// <see cref="IWebHookStore"/> implementation, <see cref="IWebHookManager"/> etc.
    /// If alternative implementations are provided by a Dependency Injection engine then
    /// those instances are used instead.
    /// </summary>
    public static class CustomMvcServices
    {
        private static IEnumerable<IWebHookFilterProvider> _filterProviders;

        /// <summary>
        /// Gets the set of <see cref="IWebHookFilterProvider"/> instances discovered by a default 
        /// discovery mechanism which is used if none are registered with the Dependency Injection engine.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> containing the discovered instances.</returns>
        public static IEnumerable<IWebHookFilterProvider> GetFilterProviders()
        {
            if (_filterProviders != null)
            {
                return _filterProviders;
            }

            IAssembliesResolver assembliesResolver = WebHooksConfigMvc.Config.Services.GetAssembliesResolver();
            ICollection<Assembly> assemblies = assembliesResolver.GetAssemblies();
            IEnumerable<IWebHookFilterProvider> instances = TypeUtilities.GetInstances<IWebHookFilterProvider>(assemblies, t => TypeUtilities.IsType<IWebHookFilterProvider>(t));
            Interlocked.CompareExchange(ref _filterProviders, instances, null);
            return _filterProviders;
        }

        /// <summary>
        /// For testing purposes
        /// </summary>
        internal static void Reset()
        {
            _filterProviders = null;
        }
    }
}
