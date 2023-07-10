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

        #region Function
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
                return response = await httpClient.PostAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/testInsert/" + TestCases), content);
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


        #region getall function
        public async Task<HttpResponseMessage> GetAllDataAsync(int TestCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(TestCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/GetTopInsertData/" + TestCases));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HttpResponseMessage> GetAllUpdateDataAsync(int TestCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(TestCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/GetTopUpdateData/" + TestCases));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HttpResponseMessage> GetAllGetDataAsync(int TestCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(TestCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/GetTopGetData/" + TestCases));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HttpResponseMessage> GetAllDeleteDataAsync(int TestCases)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(TestCases, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/GetTopDeleteData/" + TestCases));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion getall function

        #region AJAX Function
        public async Task<JsonResult> ListSQLInsert(int TestCases)
        {
            try
            {
                List<TestResult> list = new List<TestResult>();
                HttpResponseMessage apiResponse = await GetAllDataAsync(TestCases);
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse.Content.ReadAsStringAsync());
                    list = JsonConvert.DeserializeObject<List<TestResult>>(listJSON);
                }
                return Json(new { data = list });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<JsonResult> ListSQLUpdate(int TestCases)
        {
            try
            {
                List<TestResult> list = new List<TestResult>();
                HttpResponseMessage apiResponse = await GetAllUpdateDataAsync(TestCases);
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse.Content.ReadAsStringAsync());
                    list = JsonConvert.DeserializeObject<List<TestResult>>(listJSON);
                }
                return Json(new { data = list });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<JsonResult> ListSQLGet(int TestCases)
        {
            try
            {
                List<TestResult> list = new List<TestResult>();
                HttpResponseMessage apiResponse = await GetAllGetDataAsync(TestCases);
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse.Content.ReadAsStringAsync());
                    list = JsonConvert.DeserializeObject<List<TestResult>>(listJSON);
                }
                return Json(new { data = list });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<JsonResult> ListSQLDelete(int TestCases)
        {
            try
            {
                List<TestResult> list = new List<TestResult>();
                HttpResponseMessage apiResponse = await GetAllDeleteDataAsync(TestCases);
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse.Content.ReadAsStringAsync());
                    list = JsonConvert.DeserializeObject<List<TestResult>>(listJSON);
                }
                return Json(new { data = list });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion AJAX Function
    }
}
