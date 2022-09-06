using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication.Helper
{
    public class DepHelper
    {
        public HttpClient Initial()
        {
            var cilent = new HttpClient();
            cilent.BaseAddress = new Uri("https://localhost:44365/");
            return cilent;
        }
    }
}
