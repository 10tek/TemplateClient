using System;
using TemplateClient.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TemplateClient
{
    class Program
    {

        static void Main(string[] args)
        {
            var r = new Request<User>
            {
                Action = GET,
                Path = "/user/",
                Data = new User
                {
                    FirstName = "Galym",
                    LastName = "Oralbayev",
                    Nickname = "10tek"
                }
            };
            var json = JsonConvert.SerializeObject(r);
            var o = JObject.Parse(json);
            var s = o["Path"].ToString();
            var data = JsonConvert.DeserializeObject(o["Path"].ToString());


        }
    }
}
