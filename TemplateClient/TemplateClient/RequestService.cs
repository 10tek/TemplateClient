using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TemplateClient.Domain;

namespace TemplateClient
{
    public class RequestService<T>
    {
        private const string GET = "GET";
        private const string ADD = "ADD";
        private const string UPDATE = "UPDATE";
        private const string REMOVE = "REMOVE";
        private const string DATA_TYPE = "/user/";

        public async Task<Response<T>> GetAsync(NetworkStream stream, string nickname)
        {
            var request = new Request<string>
            {
                Action = GET,
                Path = DATA_TYPE,
                Data = nickname
            };
            var requestJson = JsonConvert.SerializeObject(request);
            var data = Encoding.UTF8.GetBytes(requestJson);
            await stream.WriteAsync(data, 0, data.Length);

            var buffer = new byte[1024];
            await stream.ReadAsync(buffer, 0, buffer.Length);
            return JsonConvert.DeserializeObject<Response<T>>(Encoding.UTF8.GetString(buffer));
        }

        public async Task<string> AddAsync(NetworkStream stream, T obj)
        {
            var request = new Request<T>
            {
                Action = ADD,
                Path = DATA_TYPE,
                Data = obj
            };
            var requestJson = JsonConvert.SerializeObject(request);
            var data = Encoding.UTF8.GetBytes(requestJson);
            await stream.WriteAsync(data, 0, data.Length);

            var buffer = new byte[1024];
            await stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        public async Task<string> UpdateAsync(NetworkStream stream, T obj)
        {
            var request = new Request<T>
            {
                Action = UPDATE,
                Path = DATA_TYPE,
                Data = obj
            };
            var requestJson = JsonConvert.SerializeObject(request);
            var data = Encoding.UTF8.GetBytes(requestJson);
            await stream.WriteAsync(data, 0, data.Length);

            var buffer = new byte[1024];
            await stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        public async Task<string> RemoveAsync(NetworkStream stream, string nickname)
        {
            var request = new Request<string>
            {
                Action = REMOVE,
                Path = DATA_TYPE,
                Data = nickname
            };
            var requestJson = JsonConvert.SerializeObject(request);
            var data = Encoding.UTF8.GetBytes(requestJson);
            await stream.WriteAsync(data, 0, data.Length);

            var buffer = new byte[1024];
            await stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }
    }
}
