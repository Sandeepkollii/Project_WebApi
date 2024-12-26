using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TMS_Application.Models;

namespace TMS_Application.Controllers
{
    public class BatchController : Controller
    {
        HttpClient client = new HttpClient();
        static List<Batch> batches = null;

        public BatchController()
        {
            client.BaseAddress = new Uri(" https://localhost:7191/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: BatchController
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync("api/Batch");
            if (response.IsSuccessStatusCode) {

                var jsonString = response.Content.ReadAsStringAsync();
                batches = JsonConvert.DeserializeObject<List<Batch>>(jsonString.Result);

                return View(batches); 
            
            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
        }

        // GET: BatchController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Batch");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content?.ReadAsStringAsync();
                jsonString.Wait();
                var batch = JsonConvert.DeserializeObject<Batch>(jsonString.Result);
                return View(batch);
            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }


            
        }

        // GET: BatchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BatchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Batch batch)
        {
            try
            {
                StringContent content = new StringContent
                    (JsonConvert.SerializeObject(batch), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = await client.PostAsync("api/Batch", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Batch>(jsonString.Result);



                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: BatchController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Batch/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var batch = JsonConvert.DeserializeObject<Batch>(jsonString.Result);


                return View(batch);
            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
        }
        // POST: BatchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Batch batch)
        {
            try
            {
                StringContent content = new StringContent
                    (JsonConvert.SerializeObject(batch), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                //HttpResponseMessage response = await client.GetAsync("api/Student/" + id);
                HttpResponseMessage response = await client.PutAsync("api/Batch/" + id, content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Batch>(jsonString.Result);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        

        // GET: BatchController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Batch/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var batch = JsonConvert.DeserializeObject<Batch>(jsonString.Result);


                return View(batch);
            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
        }

        // POST: BatchController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Batch batch)
        {
            try
            {

                HttpResponseMessage response = await client.DeleteAsync("api/Batch/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Batch>(jsonString.Result);



                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }


    }
}
