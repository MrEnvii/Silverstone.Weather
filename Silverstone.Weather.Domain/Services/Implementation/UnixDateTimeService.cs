using System;

namespace Silverstone.Weather.Domain.Services.Implementation
{
    public class UnixDateTimeService : IUnixDateTimeService
    {
        /// <summary>
        /// Converts a unix time stamp to a DateTimeOffset object
        /// </summary>
        /// <param name="unixTimeStamp">Unix value to be converted to DateTimeOffset</param>
        /// <returns>A DateTimeOffset directly converted from a unix timestamp</returns>
        public DateTimeOffset UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp);
            return dateTime;
        }
    }
}