using FootApiWebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FootApiWebUI.ViewComponents.DefaultMenuViewComponent
{
    public class _DefaultMenuCategoryComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultMenuCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7102/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync(); //API den geliyor
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData); // Dto ile yakala ve cshtml ye gonder seklinde calısırlar
                return View(values);
            }
            return View();




        }
    }
}
