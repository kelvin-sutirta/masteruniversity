using MasterUniversityFE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MasterUniversityFE.Controllers
{
    public class NoSQLController : Controller
    {
        public IActionResult NoSQL()
        {
            return View();
        }
        public IActionResult NoSQLUpdate()
        {
            return View();
        }
        public IActionResult NoSQLGet()
        {
            return View();
        }
        public IActionResult NoSQLDelete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NoSQLPerformance(int TestCases)
        {
            try
            {
                {
                    HttpResponseMessage apiResponse;
                    apiResponse = await NoSQLPerformanceComparisonAsync(TestCases);
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
        public async Task<IActionResult> NoSQLUpdatePerformance(int TestCases)
        {
            try
            {
                {
                    HttpResponseMessage apiResponse;
                    apiResponse = await NoSQLPerformanceUpdateComparisonAsync(TestCases);
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
        public async Task<IActionResult> NoSQLGetPerformance(int TestCases)
        {
            try
            {
                {
                    HttpResponseMessage apiResponse;
                    apiResponse = await NoSQLPerformanceGetComparisonAsync(TestCases);
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
        public async Task<IActionResult> NoSQLDeletePerformance(int TestCases)
        {
            try
            {
                {
                    HttpResponseMessage apiResponse;
                    apiResponse = await NoSQLPerformanceDeleteComparisonAsync(TestCases);
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

        #region Performance Comparison
        private async Task<HttpResponseMessage> NoSQLPerformanceComparisonAsync(int testCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(testCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.PostAsync(new Uri("https://localhost:3489/" + "api/PerformanceComparison/testInsert/" + testCases), content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<HttpResponseMessage> NoSQLPerformanceUpdateComparisonAsync(int testCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(testCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.PutAsync(new Uri("https://localhost:3489/" + "api/PerformanceComparison/testUpdate/" + testCases), content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<HttpResponseMessage> NoSQLPerformanceGetComparisonAsync(int testCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(testCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:3489/" + "api/PerformanceComparison/testGet/" + testCases));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<HttpResponseMessage> NoSQLPerformanceDeleteComparisonAsync(int testCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(testCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.DeleteAsync(new Uri("https://localhost:3489/" + "api/PerformanceComparison/testDelete/" + testCases));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
