using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW3_413.Models
{
    public static class TempStorage
    {
        private static List<MovieResponse> applications = new List<MovieResponse>();

        public static IEnumerable<MovieResponse> MovieResponses => applications;

        public static void AddApplication(MovieResponse application)
        {
            applications.Add(application);
        }
    }
}
