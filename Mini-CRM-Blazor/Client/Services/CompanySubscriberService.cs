using Mini_CRM_Blazor.Shared.Models;
using System.Net.Http.Json;

namespace Mini_CRM_Blazor.Client.Services
{
    public class CompanySubscriberService
    {
        private readonly HttpClient _httpClient;
        public CompanySubscriberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public CompanySubscriberDto CompanySubscriberDto { get; set; }
        public async Task<CompanySubscriberDto> GetCompany(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<CompanySubscriberDto>($"api/CompanySubscribers/GetById/{id}");
            CompanySubscriberDto = result;
            return CompanySubscriberDto;
        }

        //public async Task Login(LoginRequest loginRequest)
        //{
        //    var result = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);
        //    if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
        //    result.EnsureSuccessStatusCode();
        //}
        //public async Task Logout()
        //{
        //    var result = await _httpClient.PostAsync("api/auth/logout", null);
        //    result.EnsureSuccessStatusCode();
        //}
        //public async Task Register(RegisterRequest registerRequest)
        //{
        //    var result = await _httpClient.PostAsJsonAsync("api/auth/register", registerRequest);
        //    if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
        //    result.EnsureSuccessStatusCode();
        //}
    }
}