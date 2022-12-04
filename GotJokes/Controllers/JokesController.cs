using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using GotJokes.Models;

namespace GotJokes.Controllers
{
    public class JokesController : Controller
    {
        public IActionResult Index(JokesModel.Rootobject model)
        {

            return View(model);
        }

        public IActionResult GetJokes(string setup, string delivery, int id)
        {
            var client = new RestClient("https://v2.jokeapi.dev/joke/Dark");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var data = JsonConvert.DeserializeObject<JokesModel.Rootobject>(response.Content);
            Console.WriteLine(response.Content);
            var model = new JokesModel.Rootobject()
            {
                id = data.id,
                setup = data.setup,
                delivery = data.delivery,
            };

            return RedirectToAction("Index", model);
        }


    }
}
