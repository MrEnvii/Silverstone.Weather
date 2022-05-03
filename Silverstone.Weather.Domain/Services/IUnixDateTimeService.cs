using System;

namespace Silverstone.Weather.Domain.Services
{
    public interface IUnixDateTimeService
    {
        DateTimeOffset UnixTimeStampToDateTime(double unixTimeStamp);
    }
}