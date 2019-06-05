﻿using System;
using System.ComponentModel;
using System.Web.Http.Dependencies;
using Microsoft.AspNet.WebHooks.Config;
using Microsoft.AspNet.WebHooks.Diagnostics;
using Microsoft.AspNet.WebHooks.Services;

namespace CustomSender.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IDependencyScope"/> facilitating getting the services used by custom WebHooks APIs.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class DependencyScopeExtensions
    {
        /// <summary>
        /// Gets an <see cref="ILogger"/> implementation registered with the Dependency Injection engine
        /// or a default <see cref="System.Diagnostics.Trace"/> implementation if none are registered.
        /// </summary>
        /// <param name="services">The <see cref="IDependencyScope"/> implementation.</param>
        /// <returns>The registered <see cref="ILogger"/> instance or a default implementation if none are registered.</returns>
        public static ILogger GetLogger(this IDependencyScope services)
        {
            ILogger logger = services.GetService<ILogger>();
            return logger ?? CommonServices.GetLogger();
        }

        /// <summary>
        /// Gets a <see cref="SettingsDictionary"/> instance registered with the Dependency Injection engine
        /// or a default implementation based on application settings if none are registered.
        /// </summary>
        /// <param name="services">The <see cref="IDependencyScope"/> implementation.</param>
        /// <returns>The registered <see cref="SettingsDictionary"/> instance or a default implementation if none are registered.</returns>
        public static SettingsDictionary GetSettings(this IDependencyScope services)
        {
            SettingsDictionary settings = services.GetService<SettingsDictionary>();
            return settings != null && settings.Count > 0 ? settings : CommonServices.GetSettings();
        }

        /// <summary>
        /// Gets the <typeparamref name="TService"/> instance registered with the Dependency Injection engine or
        /// null if none are registered.
        /// </summary>
        /// <typeparam name="TService">The type of services to lookup.</typeparam>
        /// <param name="services">The <see cref="IDependencyScope"/> implementation.</param>
        /// <returns>The registered instance or null if none are registered.</returns>
        public static TService GetService<TService>(this IDependencyScope services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            return (TService)services.GetService(typeof(TService));
        }
    }
}
