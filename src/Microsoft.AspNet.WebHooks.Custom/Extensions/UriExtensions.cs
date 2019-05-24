using System;
using System.Collections.Specialized;
using System.Net;

namespace Microsoft.AspNet.WebHooks.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class UriExtensions
    {
         /// <summary>
         /// 
         /// </summary>
         /// <param name="uri"></param>
         /// <returns></returns>
        public static NameValueCollection ParseQueryString(this Uri uri)
        {
            var queryParameters = new NameValueCollection();

            if (string.IsNullOrEmpty(uri.Query)) return queryParameters;

            string[] querySegments = uri.Query.Remove(0,1).Split('&');

            foreach (string segment in querySegments)
            {
                string[] parts = segment.Split('=');

                if (parts.Length > 0)
                {
                    string key = parts[0].Trim(new char[] { '?', ' ' }).ToLower();
                    string val = parts.Length == 2 ? parts[1].Trim().ToLower() : string.Empty;

                    queryParameters.Add(key, WebUtility.UrlDecode(val));
                }
            }

            return queryParameters;
        }
    }
}
