﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MasterUniversityFE.Controllers
{
    public class SQLController : Controller
    {
        public string _ApiPerformance;
        public IActionResult SQL()
        {
            return View();
        }

        public void SQLBase(IConfiguration cfg)
        {
            if (cfg != null)
            {
                _ApiPerformance = cfg.GetSection("APIURL:_ApiPerformance").Value;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SQLPerformance(int TestCases)
        {
            try
            {
                {
                    HttpResponseMessage apiResponse;
                    apiResponse = await PerformanceComparisonAsync(TestCases);
                    if (apiResponse.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }
        private async Task<HttpResponseMessage> PerformanceComparisonAsync(int testCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(testCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.PostAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/testInsert/" + testCases),content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}