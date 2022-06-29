﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Agents.Utils
{
    public static class ApiCall
    {
        private static HttpClient GetHttpClient(string url, string apiToken)
        {
            var client = new HttpClient { BaseAddress = new Uri(url) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (apiToken != "") client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            return client;
        }

        public static async Task<T> GetAsync<T>(string url, string urlParameters, string apiToken = "")
        {
            try
            {
                using var client = GetHttpClient(url, apiToken);
                HttpResponseMessage response = await client.GetAsync(urlParameters);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                return default;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public static async Task<T> PostAsync<T>(string url, string urlParameters, T requestObj, string apiToken = "")
        {
            try
            {
                using var client = GetHttpClient(url, apiToken);
                HttpResponseMessage response = await client.PostAsJsonAsync(urlParameters, requestObj);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                return default;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public static async Task<object> PostRetObjectAsync<T>(string url, string urlParameters, T requestObj, string apiToken = "")
        {
            try
            {
                using var client = GetHttpClient(url, apiToken);
                HttpResponseMessage response = await client.PostAsJsonAsync(urlParameters, requestObj);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<object>(json);
                    return result;
                }
                return default;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public static async Task<T> PutAsync<T>(string url, string urlParameters, T requestObj, string apiToken = "")
        {
            try
            {
                using var client = GetHttpClient(url, apiToken);
                HttpResponseMessage response = await client.PutAsJsonAsync(urlParameters, requestObj);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                return default;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public static async Task<T> DeleteAsync<T>(string url, string urlParameters, string apiToken = "")
        {
            try
            {
                using var client = GetHttpClient(url, apiToken);
                HttpResponseMessage response = await client.DeleteAsync(urlParameters);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                }
                return default;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
    }
}
