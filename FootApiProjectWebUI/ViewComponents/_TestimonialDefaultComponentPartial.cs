using FootApiWebUI.Dtos.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;

namespace FootApiWebUI.ViewComponents
{
    public class _TestimonialDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _TestimonialDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7102/api/Testimonials");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync(); //API den geliyor
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData); // Dto ile yakala ve cshtml ye gonder seklinde calısırlar
                return View(values);
            }
            return View();
        }
    }
}
