using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Extentions
{
    public static class HandleErrors
    {
        public  static void AddExceptionApplication(this HttpResponse httpResponse, string message)
        {
            httpResponse.Headers.Add("Application-Error", message);
            httpResponse.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            httpResponse.Headers.Add("Access-Control-Allow-Origin", "*");

        }
    }
    public static class DateExtentions
    {
        public static int CalcuateAge(this DateTime time)
        {
            int ThisYear = DateTime.Now.Year;
            return ThisYear - time.Year;

        }

    }
}
