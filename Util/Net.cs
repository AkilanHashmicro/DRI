
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SalesApp.Util
{
    class Net
    {
        private static string URL_PATTERN = "^https?://[-a-zA-Z0-9+&@#/%?=~_|!:,.;]*[-a-zA-Z0-9+&@#/%=~_|]";
        private static string IP_PATTERN = "^https?://([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\.([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\.([01]?\\d\\d?|2[0-4]\\d|25[0-5])\\.([01]?\\d\\d?|2[0-4]\\d|25[0-5])/?";

        public async static Task<bool> CheckInternetConnection()
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.Timeout = new System.TimeSpan(0, 0, 10);
                var data =  httpClient.GetStringAsync("http://www.google.com");
                var tmpList = data.Result;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidateURL(string url)
        {
            try
            {
                Match match = Regex.Match(url, URL_PATTERN, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    return true;
                }
                else
                {
                    match = Regex.Match(url, IP_PATTERN, RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
