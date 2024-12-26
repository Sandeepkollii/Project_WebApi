using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Training_Management_System.Models;

namespace Training_Management_System.Controllers
{
    public class CourseController : Controller
    {
        // GET: CourseController
        HttpClient client = new HttpClient();
        static List<Course> courses = null;

        public CourseController()
        {
            client.BaseAddress = new Uri("http://localhost:5221/");
            client.DefaultRequestHeaders.Accept.Clear();    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync("api/Course");
            if (response.IsSuccessStatusCode) { 
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                courses = JsonConvert.DeserializeObject<List<Course>>(jsonString.Result);
                return View(courses);
            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }

        }

        // GET: CourseController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Course" +id);
            if (response.IsSuccessStatusCode) {

                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                courses = JsonConvert.DeserializeObject<List<Course>>(jsonString.Result);
                return View(courses);

            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Course course)
        {
            course.CreatedBy = 3;
            course.CreatedOn = DateTime.Now;
            course.IsActive= true;

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(course),Encoding.UTF8,"application/json");
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                
                HttpResponseMessage response = await client.PostAsync("api/Course", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Course>(jsonString.Result);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ViewBag.msg = response.ReasonPhrase;
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Course" + id);
            if (response.IsSuccessStatusCode) {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var temp = JsonConvert.DeserializeObject<Course>(jsonString.Result);
                return View(temp);

            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }
            
           
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Course course)
        {
            try
            {
                course.Updated = DateTime.Now;
                course.UpdatedBy = 3;
                StringContent content = new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = await client.PutAsync("api/Course/"+id,content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Course>(jsonString.Result);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ViewBag.msg = response.ReasonPhrase;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Course/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var temp = JsonConvert.DeserializeObject<Course>(jsonString.Result);
                return View(temp);

            }
            else
            {
                ViewBag.msg = response.ReasonPhrase;
                return View();
            }

        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Deleted(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/Course/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Course>(jsonString.Result);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ViewBag.msg = response.ReasonPhrase;
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
