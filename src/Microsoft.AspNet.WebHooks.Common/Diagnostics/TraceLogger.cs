// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace Microsoft.AspNet.WebHooks.Diagnostics
{
    /// <summary>
    /// Provides an implementation of the <see cref="ILogger"/> interface which writes to <see cref="System.Diagnostics.Trace"/>.
    /// </summary>
    public class TraceLogger : ILogger
    {
        /// <inheritdoc />
        public void Log(TraceLevel level, string message, Exception ex)
        {
            if (message == null)
            {
                return;
            }

            switch (level)
            {
                case TraceLevel.Error:
                    Trace.TraceError(message);
                    break;

                case TraceLevel.Warning:
                    Trace.TraceWarning(message);
                    break;

                case TraceLevel.Info:
                    Trace.TraceInformation(message);
                    break;

                case TraceLevel.Off:
                    break;
            }
        }
    }
}
