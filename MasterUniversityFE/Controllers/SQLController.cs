using MasterUniversityFE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public IActionResult SQLUpdate()
        {
            return View();
        }
        public IActionResult SQLGet()
        {
            return View();
        }
        public IActionResult SQLDelete()
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
        #region function
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
                        var JSON = (await apiResponse.Content.ReadAsStringAsync());
                        var data = JsonConvert.DeserializeObject<TestResult>(JSON);

                        if (data == null)
                        {
                            ViewData["Message"] = "Could not load data category";
                        }
                        else
                        {
                            return Json(data);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SQLUpdatePerformance(int TestCases)
        {
            try
            {
                {
                    HttpResponseMessage apiResponse;
                    apiResponse = await PerformanceUpdateComparisonAsync(TestCases);
                    if (apiResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var JSON = (await apiResponse.Content.ReadAsStringAsync());
                        var data = JsonConvert.DeserializeObject<TestResult>(JSON);

                        if (data == null)
                        {
                            ViewData["Message"] = "Could not load data category";
                        }
                        else
                        {
                            return Json(data);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SQLGetPerformance(int TestCases)
        {
            try
            {
                {
                    HttpResponseMessage apiResponse;
                    apiResponse = await PerformanceGetComparisonAsync(TestCases);
                    if (apiResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var JSON = (await apiResponse.Content.ReadAsStringAsync());
                        var data = JsonConvert.DeserializeObject<TestResult>(JSON);

                        if (data == null)
                        {
                            ViewData["Message"] = "Could not load data category";
                        }
                        else
                        {
                            return Json(data);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SQLDeletePerformance(int TestCases)
        {
            try
            {
                {
                    HttpResponseMessage apiResponse;
                    apiResponse = await PerformanceDeleteComparisonAsync(TestCases);
                    if (apiResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var JSON = (await apiResponse.Content.ReadAsStringAsync());
                        var data = JsonConvert.DeserializeObject<TestResult>(JSON);

                        if (data == null)
                        {
                            ViewData["Message"] = "Could not load data category";
                        }
                        else
                        {
                            return Json(data);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }

#endregion 
        #region Performance Comparison
        private async Task<HttpResponseMessage> PerformanceComparisonAsync(int TestCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(TestCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.PostAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/testInsert/" + TestCases),content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<HttpResponseMessage> PerformanceUpdateComparisonAsync(int TestCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(TestCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.PutAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/testUpdate/" + TestCases), content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<HttpResponseMessage> PerformanceGetComparisonAsync(int TestCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(TestCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/testGet/" + TestCases));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<HttpResponseMessage> PerformanceDeleteComparisonAsync(int TestCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(TestCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.DeleteAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/testDelete/" + TestCases));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
