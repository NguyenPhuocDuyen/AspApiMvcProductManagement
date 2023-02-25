using System.Net.Http.Headers;
using System.Net.Http;
using System;

namespace eStoreClient
{
    public static class GobalVariables
    {
        public static HttpClient WebAPIClient = new HttpClient();

        static GobalVariables()
        {
            WebAPIClient.BaseAddress = new Uri("https://localhost:44367/api/");
            WebAPIClient.DefaultRequestHeaders.Clear();
            WebAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
