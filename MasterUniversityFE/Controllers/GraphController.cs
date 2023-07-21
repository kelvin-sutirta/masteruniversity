using MasterUniversityFE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;

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
        public async Task<IActionResult> GraphInsert() // yang ini gw coba dari bikin sql command nya sendiri (nyoba dari youtube.
        {
            try
            {
                {
                    HttpResponseMessage apiResponse;
                    apiResponse = await InsertGraphAsync();
                    if (apiResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var JSON = (await apiResponse.Content.ReadAsStringAsync());
                        var data = JsonConvert.DeserializeObject<>(JSON);

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
        }*/
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

        
        public async Task<JsonResult> GraphInsert() //ngambil dalam bentuk list
        {
            try
            {
                List<GraphData> list = new List<GraphData>();
                HttpResponseMessage apiResponse = await InsertGraphAsync();
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    var listJSON = (await apiResponse.Content.ReadAsStringAsync());
                    list = JsonConvert.DeserializeObject<List<GraphData>>(listJSON);
                }
                return Json(new { data = list });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        // Yang bawah biasa buat ngambil ke API
        private async Task<HttpResponseMessage> InsertGraphAsync()
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
    }
}