using Hanssens.Net;
using HR_Management.MVC.Contracts;

namespace HR_Management.MVC.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        LocalStorage _localStorage;

        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "HR_Management"
            };
            _localStorage = new LocalStorage(config);
        }

        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
            {
                _localStorage.Remove(key);
            }
        }

        public bool IsExists(string key)
        {
            return _localStorage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return _localStorage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, T value)
        {
            _localStorage.Store(key,value);
            _localStorage.Persist();
        }
    }
}
