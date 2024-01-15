using Mini_CRM_Blazor.Shared.Models;
using System.Net.Http.Json;

namespace Mini_CRM_Blazor.Client.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private CustomerDto _customer;
        public CustomerDto Customer {
            get => _customer;
            set
            {
                _customer = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public async Task<CustomerDto> GetCustomerById(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<CustomerDto>($"api/Customers/GetById/{id}");
            Customer = result;
            return Customer;
        }

        public async Task<CustomerDto> GetCustomers(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<CustomerDto>($"api/Customers/GetAllByCompanySubscriberId/{id}");
            Customer = result;
            return Customer;
        }
    }
}