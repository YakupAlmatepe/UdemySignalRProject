using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7097/api/About");

                // HTTP yanıtını kontrol et
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);

                    // Dönen verinin null olup olmadığını kontrol et
                    if (values != null)
                    {
                        return View(values);
                    }
                    else
                    {
                        // Veri null ise işlemi handle et (örneğin, boş bir liste ile devam et)
                        return View(new List<ResultAboutDto>());
                    }
                }
                else
                {
                    // HTTP yanıtı başarılı değilse işlemi handle et (örneğin, boş bir liste ile devam et)
                    return View(new List<ResultAboutDto>());
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda işlemi handle et (örneğin, boş bir liste ile devam et)
                return View(new List<ResultAboutDto>());
            }
        }

    }
}