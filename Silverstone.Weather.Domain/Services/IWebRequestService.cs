using System;
using System.Threading.Tasks;

namespace Silverstone.Weather.Domain.Services
{
    public interface IWebRequestService
    {
        Task<string> GetAsync(Uri uri);
    }
}