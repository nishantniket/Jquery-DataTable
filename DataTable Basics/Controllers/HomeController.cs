using DataTable_Basics.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace DataTable_Basics.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string GetCampaigns()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DeltaXContextBp1631"].ConnectionString;
            var campaigns = new List<Campaign>();
            using (var conn = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("campaignTestData", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var campaign = new Campaign();
                    campaign.Id = Convert.ToInt32(rdr["Id"]);
                    campaign.Name = rdr["Name"].ToString();
                    campaign.CreatedAt = Convert.ToDateTime(rdr["CreatedAt"]);
                    campaigns.Add(campaign);
                }
            }
             
            return JsonConvert.SerializeObject(campaigns);
        }
    }
}
