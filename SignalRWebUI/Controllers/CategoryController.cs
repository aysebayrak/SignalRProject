using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        string baseUrl = "https://localhost:7085/api/Category";


		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
        {
            var client =  _httpClientFactory.CreateClient(); //istemci oluşturduk.
            var responseMessage = await client.GetAsync(baseUrl);
            if(responseMessage.IsSuccessStatusCode)
            { 
               var jsonData= await responseMessage.Content.ReadAsStringAsync(); //gelen içeriği string biçimde oku
               var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);//jsonda gelen  veriyi çözumleyip values içine atıcam.
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.CategoryStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync(baseUrl, stringContent);
            if(responseMessage.IsSuccessStatusCode )
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public  async Task<IActionResult> DeleteCategory(int  id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync(baseUrl+$"/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public  async Task<IActionResult> UpdateCategory(int id)
        { 
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(baseUrl + $"/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(baseUrl + "/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }


    }
}
