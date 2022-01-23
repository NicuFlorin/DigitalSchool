using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class DateTimeExtensions
    {

        public static long CalculateTimeLeft(this DateTime dateOpened, int timeAvailable)
        {
            long timeLimit = dateOpened.ToUniversalTime().Ticks + timeAvailable;
            long timeLeft = timeLimit - DateTime.Today.ToUniversalTime().Ticks;
            return timeLeft > 0 ? timeLeft : 0;
        }

    }
}