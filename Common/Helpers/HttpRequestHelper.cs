namespace Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Runtime.Serialization.Formatters;
    using System.Web.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper class allowing clients to provides functionality to make HTTP calls (GET, POST, PUT, DELETE)
    /// </summary>
    public static class HttpRequestHelper
    {
        #region Public Methods

        public static T Get<T>(string baseUri, string relativeUri)
        {
            // Get the absolute endpoint, adding any required oData parameters to query string
            Uri absoluteUri = GetAbsoluteEndpoint(baseUri, relativeUri);

            return Get<T>(absoluteUri, null);
        }

        public static T Get<T>(Uri absoluteUri, NetworkCredential credentials)
        {
            T result = default(T);

            // Make the call and get the response
            HttpResponseMessage response = Get(absoluteUri, credentials);

            // Read the result. This will deserialise the incoming response content
            if (response.IsSuccessStatusCode && response.Content != null && response.Content.Headers.ContentType != null)
            {
                // Get the type of media and use the formatter to get the content out of response
               // MediaTypeFormatter formatter = GetMediaTypeFormatter(response.Content.Headers.ContentType.MediaType, false);

                result = response.Content.ReadAsAsync<T>().Result;
            }

            // Return the response containing the de-serialised result
            return result;
        }


        #endregion

        #region Private Methods

        private static Uri GetAbsoluteEndpoint(
            string baseUri,
            string relativeUri)
        {
            // Construct the absolute end point
            if (!string.IsNullOrEmpty(relativeUri) && relativeUri.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                // Remove the preceding backslash
                relativeUri = relativeUri.Substring(1);
            }

            if (!string.IsNullOrEmpty(baseUri) && baseUri.Trim().EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                // Remove the trailing backslash
                baseUri = baseUri.Substring(0, baseUri.Trim().Length - 1);
            }

            return new Uri(string.Format("{0}/{1}", baseUri, relativeUri));
        }

        private static HttpResponseMessage Get(Uri absoluteUri, NetworkCredential credentials)
        {
            // Removed the using statment for httpclient to pass integration test - need to keep an eye on it though
            HttpClient httpClient = GetHttpClient(absoluteUri, credentials);

            // Create the request
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, absoluteUri);
            request.Headers.Add("Accept", "application/json");


            // Make the request  - HttpCompletionOption.ResponseHeadersRead is used to avoid memory leak
            return httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
        }

        private static HttpClient GetHttpClient(Uri absoluteUri, NetworkCredential credentials)
        {
            CredentialCache credentialCache = null;
            HttpClient httpClient = null;

            if (credentials != null)
            {
                credentialCache = new CredentialCache();
                credentialCache.Add(absoluteUri, "Basic", credentials);
                httpClient = new HttpClient(new HttpClientHandler { Credentials = credentialCache, AllowAutoRedirect = false });
            }
            else
            {
                httpClient = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
            }

            return httpClient;
        }


        #endregion
    }
}
