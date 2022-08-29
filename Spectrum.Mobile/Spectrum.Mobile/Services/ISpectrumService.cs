using System;
using System.Threading.Tasks;

namespace Spectrum.Mobile.Services
{
    public interface ISpectrumService
    {
        Task<T> GetAsync<T>(string method);
        Task<T> PostAsync<T>(object body, string method);
    }
}

