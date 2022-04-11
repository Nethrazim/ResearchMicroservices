using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BaseClientNS.Entities.Requests
{
    public class TokenProvider 
    {
        public string Token { get; set; }
        public string GetUriParams()
        {
            string result = string.Empty;

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            var allProperties = this.GetType().GetProperties().Where(p => p.Name != "Token").ToList();
            foreach (var property in allProperties)
            {
                queryParams.Add(property.Name, HttpUtility.UrlEncode(this.GetType().GetProperty(property.Name).GetValue(this).ToString()));
            }

            foreach (var param in queryParams)
            {
                result = result + param.Key.ToString() + "=" + param.Value.ToString() + "&";
            }

            return result;
        }
    }
}
