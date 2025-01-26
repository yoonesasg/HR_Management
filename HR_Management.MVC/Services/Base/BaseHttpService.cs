using System.Net.Http.Headers;
using HR_Management.MVC.Contracts;

namespace HR_Management.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected readonly ILocalStorageService _localStorageService;
        protected readonly IClient _client;

        public BaseHttpService(ILocalStorageService localStorageService, IClient client)
        {
            _localStorageService = localStorageService;
            _client = client;
        }

        protected Response<Guid> ConvertApiException(ApiException exception)
        {
            switch (exception.StatusCode)
            {
                case 404:
                    return new Response<Guid>() { Message = "404 Not Found!",Success = false};
                case 400:
                    return new Response<Guid>() { Message = "Validation errors!", Success = false,ValidationErrors = exception.Response};
                default:
                    return new Response<Guid>() { Message = "Something went wrong!", Success = false };
            }
        }

        protected void AddBearerToken()
        {
            if (_localStorageService.IsExists("token"))
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _localStorageService.GetStorageValue<string>("token"));
            }
        }
    }
}
