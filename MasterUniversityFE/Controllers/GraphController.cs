using MasterUniversityFE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Routing.Matching;

namespace MasterUniversityFE.Controllers
{
    public class GraphController : Controller
    {
        private readonly ILogger<GraphController> _logger;

        public GraphController(ILogger<GraphController> logger)
        {
            _logger = logger;
        }

        public IActionResult Graph()
        {
            return View();
        }
 
        /*
        public JsonResult GraphInsert()
        {
            try
            {
                string[] GraphInsert = new string[4];
                SqlConnection con = new SqlConnection("Server=ASUS-N43SL;Database=M_University;Trusted_Connection=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select DISTINCT A.[DataProcessed] as DataAmount, AVGPerDataProcessed as AveragePerformanceSpeed From PerformanceTestDelete A JOIN (Select DataProcessed,AVGPerDataProcessed = AVG(AverageTime) From PerformanceTestInsert Group by DataProcessed) AS B ON A.DataProcessed = B.DataProcessed", con);
                DataTable dt = new DataTable();
                SqlDataAdapter cmd1 = new SqlDataAdapter(cmd);
                cmd1.Fill(dt);
                if(dt.Rows.Count ==0)
                {
                    GraphInsert[0] = "0";
                    GraphInsert[1] = "0";
                }
                else
                {
                    GraphInsert[0] = dt.Rows[0]["DataAmount"].ToString();
                    GraphInsert[1] = dt.Rows[1]["AveragePerformanceSpeed"].ToString();
                }
                return Json(new {GraphInsert});
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        */

        
        //public async Task<JsonResult> GraphInsert() //ngambil dalam bentuk list
        //{
        //    try
        //    {
        //        List<GraphData> list = new List<GraphData>();
        //        HttpResponseMessage apiResponse = await InsertGraphAsync();
        //        if (apiResponse.StatusCode == HttpStatusCode.OK)
        //        {
        //            var listJSON = (await apiResponse.Content.ReadAsStringAsync());
        //            list = JsonConvert.DeserializeObject<List<GraphData>>(listJSON);
        //        }

        //        List<string> xAxis = new List<string>();
        //        List<double> yAxis = new List<double>();

        //        for (int x=0; x<=5; x++)
        //        {
        //            xAxis[x] = list[x].DataAmount.ToString();
        //            yAxis[x] = list[x].AveragePerformanceSpeed;
        //        }

        //        return Json(new { data = list });

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public async Task<JsonResult> GraphInsert()
        {
            try
            {
                List<GraphData> list = new List<GraphData>();
                HttpResponseMessage apiResponse = await InsertGraphSQLAsync();
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse.Content.ReadAsStringAsync());
                    list = JsonConvert.DeserializeObject<List<GraphData>>(listJSON);
                }

                List<GraphData> listNoSQL = new List<GraphData>();
                HttpResponseMessage apiResponse2 = await InsertGraphNoSQLAsync();
                if (apiResponse2.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse2.Content.ReadAsStringAsync());
                    listNoSQL = JsonConvert.DeserializeObject<List<GraphData>>(listJSON);
                }
                //prepare data
                List<LineChartData> result = new List<LineChartData>();
                LineChartData resultSQL = new LineChartData();
                LineChartData resultNOSQL = new LineChartData();
                //SQL
                resultSQL.oneK = list.Where(x=> x.DataAmount == 1000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.fiveK = list.Where(x => x.DataAmount == 5000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.tenK = list.Where(x => x.DataAmount == 10000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.fiftyK = list.Where(x => x.DataAmount == 50000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.hundredK = list.Where(x => x.DataAmount == 100000).FirstOrDefault().AveragePerformanceSpeed;
                result.Add(resultSQL);
                //NoSQL
                resultNOSQL.oneK = listNoSQL.Where(x => x.DataAmount == 1000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.fiveK = listNoSQL.Where(x => x.DataAmount == 5000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.tenK = listNoSQL.Where(x => x.DataAmount == 10000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.fiftyK = listNoSQL.Where(x => x.DataAmount == 50000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.hundredK = listNoSQL.Where(x => x.DataAmount == 100000).FirstOrDefault().AveragePerformanceSpeed;
                result.Add(resultNOSQL);

                return Json(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = true, Msg = ex.Message });
            };
        }

        public async Task<JsonResult> GraphUpdate()
        {
            try
            {
                List<GraphData> list = new List<GraphData>();
                HttpResponseMessage apiResponse = await UpdateGraphSQLAsync();
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse.Content.ReadAsStringAsync());
                    list = JsonConvert.DeserializeObject<List<GraphData>>(listJSON);
                }

                List<GraphData> listNoSQL = new List<GraphData>();
                HttpResponseMessage apiResponse2 = await UpdateGraphNoSQLAsync();
                if (apiResponse2.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse2.Content.ReadAsStringAsync());
                    listNoSQL = JsonConvert.DeserializeObject<List<GraphData>>(listJSON);
                }
                //prepare data
                List<LineChartData> result = new List<LineChartData>();
                LineChartData resultSQL = new LineChartData();
                LineChartData resultNOSQL = new LineChartData();
                //SQL
                resultSQL.oneK = list.Where(x => x.DataAmount == 1000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.fiveK = list.Where(x => x.DataAmount == 5000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.tenK = list.Where(x => x.DataAmount == 10000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.fiftyK = list.Where(x => x.DataAmount == 50000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.hundredK = list.Where(x => x.DataAmount == 100000).FirstOrDefault().AveragePerformanceSpeed;
                result.Add(resultSQL);
                //NoSQL
                resultNOSQL.oneK = listNoSQL.Where(x => x.DataAmount == 1000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.fiveK = listNoSQL.Where(x => x.DataAmount == 5000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.tenK = listNoSQL.Where(x => x.DataAmount == 10000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.fiftyK = listNoSQL.Where(x => x.DataAmount == 50000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.hundredK = listNoSQL.Where(x => x.DataAmount == 100000).FirstOrDefault().AveragePerformanceSpeed;
                result.Add(resultNOSQL);

                return Json(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = true, Msg = ex.Message });
            };
        }
        public async Task<JsonResult> GraphGet()
        {
            try
            {
                List<GraphData> list = new List<GraphData>();
                HttpResponseMessage apiResponse = await GetGraphSQLAsync();
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse.Content.ReadAsStringAsync());
                    list = JsonConvert.DeserializeObject<List<GraphData>>(listJSON);
                }

                List<GraphData> listNoSQL = new List<GraphData>();
                HttpResponseMessage apiResponse2 = await GetGraphNoSQLAsync();
                if (apiResponse2.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse2.Content.ReadAsStringAsync());
                    listNoSQL = JsonConvert.DeserializeObject<List<GraphData>>(listJSON);
                }
                //prepare data
                List<LineChartData> result = new List<LineChartData>();
                LineChartData resultSQL = new LineChartData();
                LineChartData resultNOSQL = new LineChartData();
                //SQL
                resultSQL.oneK = list.Where(x => x.DataAmount == 1000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.fiveK = list.Where(x => x.DataAmount == 5000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.tenK = list.Where(x => x.DataAmount == 10000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.fiftyK = list.Where(x => x.DataAmount == 50000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.hundredK = list.Where(x => x.DataAmount == 100000).FirstOrDefault().AveragePerformanceSpeed;
                result.Add(resultSQL);
                //NoSQL
                resultNOSQL.oneK = listNoSQL.Where(x => x.DataAmount == 1000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.fiveK = listNoSQL.Where(x => x.DataAmount == 5000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.tenK = listNoSQL.Where(x => x.DataAmount == 10000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.fiftyK = listNoSQL.Where(x => x.DataAmount == 50000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.hundredK = listNoSQL.Where(x => x.DataAmount == 100000).FirstOrDefault().AveragePerformanceSpeed;
                result.Add(resultNOSQL);

                return Json(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = true, Msg = ex.Message });
            };
        }

        public async Task<JsonResult> GraphDelete()
        {
            try
            {
                List<GraphData> list = new List<GraphData>();
                HttpResponseMessage apiResponse = await DeleteGraphSQLAsync();
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse.Content.ReadAsStringAsync());
                    list = JsonConvert.DeserializeObject<List<GraphData>>(listJSON);
                }

                List<GraphData> listNoSQL = new List<GraphData>();
                HttpResponseMessage apiResponse2 = await DeleteGraphNoSQLAsync();
                if (apiResponse2.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse2.Content.ReadAsStringAsync());
                    listNoSQL = JsonConvert.DeserializeObject<List<GraphData>>(listJSON);
                }
                //prepare data
                List<LineChartData> result = new List<LineChartData>();
                LineChartData resultSQL = new LineChartData();
                LineChartData resultNOSQL = new LineChartData();
                //SQL
                resultSQL.oneK = list.Where(x => x.DataAmount == 1000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.fiveK = list.Where(x => x.DataAmount == 5000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.tenK = list.Where(x => x.DataAmount == 10000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.fiftyK = list.Where(x => x.DataAmount == 50000).FirstOrDefault().AveragePerformanceSpeed;
                resultSQL.hundredK = list.Where(x => x.DataAmount == 100000).FirstOrDefault().AveragePerformanceSpeed;
                result.Add(resultSQL);
                //NoSQL
                resultNOSQL.oneK = listNoSQL.Where(x => x.DataAmount == 1000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.fiveK = listNoSQL.Where(x => x.DataAmount == 5000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.tenK = listNoSQL.Where(x => x.DataAmount == 10000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.fiftyK = listNoSQL.Where(x => x.DataAmount == 50000).FirstOrDefault().AveragePerformanceSpeed;
                resultNOSQL.hundredK = listNoSQL.Where(x => x.DataAmount == 100000).FirstOrDefault().AveragePerformanceSpeed;
                result.Add(resultNOSQL);

                return Json(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = true, Msg = ex.Message });
            };
        }
        // Yang bawah biasa buat ngambil ke API
        #region GraphSQL
        private async Task<HttpResponseMessage> InsertGraphSQLAsync()
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/GetTopInsertDataGraph"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<HttpResponseMessage> UpdateGraphSQLAsync()
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/GetTopUpdateDataGraph"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<HttpResponseMessage> DeleteGraphSQLAsync()
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/GetTopDeleteDataGraph"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<HttpResponseMessage> GetGraphSQLAsync()
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:7218/" + "api/PerformanceComparison/GetTopGetDataGraph"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GraphNoSQL

        private async Task<HttpResponseMessage> InsertGraphNoSQLAsync()
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:3489/" + "api/PerformanceComparison/GetTopInsertDataGraph"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<HttpResponseMessage> UpdateGraphNoSQLAsync()
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:3489/" + "api/PerformanceComparison/GetTopUpdateDataGraph"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<HttpResponseMessage> DeleteGraphNoSQLAsync()
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:3489/" + "api/PerformanceComparison/GetTopDeleteDataGraph"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<HttpResponseMessage> GetGraphNoSQLAsync()
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var listJSON = System.Text.Json.JsonSerializer.Serialize(new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });
                var content = new StringContent(listJSON, Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                return response = await httpClient.GetAsync(new Uri("https://localhost:3489/" + "api/PerformanceComparison/GetTopGetDataGraph"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}