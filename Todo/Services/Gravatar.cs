using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Todo.Models.Gravatar;

namespace Todo.Services
{
    public static class Gravatar
    {
        public static string GetHash(string emailAddress)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.Default.GetBytes(emailAddress.Trim().ToLowerInvariant());
                var hashBytes = md5.ComputeHash(inputBytes);

                var builder = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    builder.Append(b.ToString("X2"));
                }
                return builder.ToString().ToLowerInvariant();
            }
        }

        public static async Task<string> GetGravatarUseName(string emailAddress)
        {
            string baseAddress = "https://gravatar.com";

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(baseAddress);
            var response = await httpClient.GetAsync($"/{GetHash(emailAddress)}.json");

            if (response.IsSuccessStatusCode)
            {
                var responsecontent = await response.Content.ReadAsStringAsync();
                var userNameOnGravatar = JsonConvert.DeserializeObject<GravatarInfo>(responsecontent).Entry.FirstOrDefault()?.DisplayName;
                return string.IsNullOrWhiteSpace(userNameOnGravatar) ? string.Empty : userNameOnGravatar;

            }
            else
            {
                return string.Empty;
            }

        }
    }

}