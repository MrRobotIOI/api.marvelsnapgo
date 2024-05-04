using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WarHammer40KAPI.MarvelApi;

public class Marvel
{
    private const string BASE_URL = "http://gateway.marvel.com/v1/public";
    private static readonly string _publicKey = "3663022c1fd5be8227dda1b9417df73e";
    private static readonly string _privateKey = "f8ab184d47e616e15b1800e638387c5b90eecbc1";
    private static HttpClient _client = new HttpClient();

    private Marvel()
    {
        
    }

    public static async Task<CharacterDataWrapper> GetCharacters(
        string Name  = null,
        string NameStartsWith = null,
        DateTime? ModifiedSince = null,
        IEnumerable<int> Comics = null,
        IEnumerable<int> Series = null,
        IEnumerable<int> Events = null,
        IEnumerable<int> Stories = null,
        int? Limit = null,
        int? Offset = null
    )
    {
        string timestamp = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
        string s = String.Format("{0}{1}{2}", timestamp, _privateKey, _publicKey);
        string hash = CreateHash(s);

        string requestURL = String.Format(BASE_URL + "/characters?ts={0}&apikey={1}&hash={2}&name={3}", timestamp, _publicKey, hash, Name);

        var url = new Uri(requestURL);
        var response = await _client.GetAsync(url);
        string json;
        using (var content = response.Content)
        {
            json = await content.ReadAsStringAsync();
        }
        
        CharacterDataWrapper cdw = JsonConvert.DeserializeObject<CharacterDataWrapper>(json);
        return cdw;
    }

    private static string CreateHash(string input)
    {
        var hash = string.Empty;
        using (MD5 md5Hash = MD5.Create())
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            hash = builder.ToString();
        }

        return hash;
    }
}

