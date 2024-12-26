using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TMS_Application.Models;


namespace TMS_Application.Controllers
{
    public class CourseController : Controller
    {
        HttpClient client = new HttpClient();
      
       
       

        public CourseController()
        {
            
            client.BaseAddress = new Uri("http://localhost:5221/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: BatchController
        public async Task<ActionResult> Index()
        {
            List<Course> courses = null;
            HttpResponseMessage response = await client.GetAsync("api/Course");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                courses = JsonConvert.DeserializeObject<List<Course>>(jsonString); 
                return View(courses);
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
            HttpResponseMessage response = await client.GetAsync("api/Course");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content?.ReadAsStringAsync();
                jsonString.Wait();
                var course = JsonConvert.DeserializeObject<Course>(jsonString.Result);
                return View(course);
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
        public async Task<ActionResult> Create(Course course)
        {
            try
            {
                {

                    course.CourseName = "string";
                    course.CourseDescription = "string";
                    course.Duration = 0;
                    course.Availability = true;
                    course.CreatedBy = 0;
                    course.CreatedOn = DateTime.Now;
                    course.IsActive = true;


}
                //course.CreatedBy = 3;
                //course.CreatedOn = DateTime.Now;
                //course.IsActive = true;

                StringContent content = new StringContent
                    (JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                //string jsonPayload = JsonConvert.SerializeObject(course);
                //Console.WriteLine("Serialized JSON: " + jsonPayload);

                //StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");


                //if (!client.DefaultRequestHeaders.Accept.Any(h => h.MediaType == "application/json"))
                //{
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //}

                HttpResponseMessage response = await client.PostAsync("api/course", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var temp = JsonConvert.DeserializeObject<Course>(jsonString);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var errorDetails = await response.Content.ReadAsStringAsync();
                    ViewBag.msg = $"Error: {response.ReasonPhrase}, Details: {errorDetails}";
                    return View(course);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return View(course);
            }
        }


        // GET: BatchController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync("api/Course/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var course = JsonConvert.DeserializeObject<Course>(jsonString.Result);


                return View(course);
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
        public async Task<ActionResult> Edit(int id, Course course)
        {
            try
            {
                StringContent content = new StringContent
                    (JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");
                var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                //HttpResponseMessage response = await client.GetAsync("api/Student/" + id);
                HttpResponseMessage response = await client.PutAsync("api/Course/" + id, content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    jsonString.Wait();
                    var temp = JsonConvert.DeserializeObject<Course>(jsonString.Result);
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
            HttpResponseMessage response = await client.GetAsync("api/Course/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                var course = JsonConvert.DeserializeObject<Course>(jsonString.Result);


                return View(course);
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
        public async Task<ActionResult> Delete(int id, Course course)
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
