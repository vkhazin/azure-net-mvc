using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace azure_net_mvc.Controllers
{
    public class HomeController : Controller
    {
        //TODO: move constants to config
        private const string appUrl = "http://dev-allstreamexit-tscapp.azurewebsites.net/echo";
        private const string headerKey = "x-app-key";
        private const string xAppKey = "377dab30-da05-491b-9cee-e95ec6ec7cc1";

        private Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(() => new HttpClient());

        public async Task<ActionResult> Index()
        {
            var webMsg = System.Environment.MachineName;
            ViewData["WebMsg"] = webMsg;
            ViewData["AppMsg"] = (await this.GetAppEcho()).machineName;
            ViewData["Message"] = DateTime.UtcNow.ToString("O");
            return View();
        }

        private async Task<dynamic> GetAppEcho()
        {
            _httpClient.Value.DefaultRequestHeaders.Add(headerKey, xAppKey);
            var response = await _httpClient.Value.GetAsync(appUrl);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);
        }
    }
}