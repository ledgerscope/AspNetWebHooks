using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.AspNet.WebHooks.WebHooks
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDequeueManager : IDisposable
    {
        /// <summary>
        /// Start
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Start(CancellationToken cancellationToken);
    }
}
