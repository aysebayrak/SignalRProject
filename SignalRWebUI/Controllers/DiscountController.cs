﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.DiscountDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        string baseUrl = "https://localhost:7085/api/Discount";
        public DiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(baseUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(baseUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync(baseUrl + $"/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(baseUrl + $"/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(baseUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

		public async Task<IActionResult> ChangeStatusToTrue(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"{baseUrl}/ChangeStatusToTrue/{id}");
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> ChangeStatusToFalse(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"{baseUrl}/ChangeStatusToFalse/{id}");
			return RedirectToAction("Index");
		}

	}
}


