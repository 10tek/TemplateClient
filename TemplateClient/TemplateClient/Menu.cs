using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TemplateClient
{
    public class Menu
    {
        private const string GET = "GET";
        private const string ADD = "ADD";
        private const string UPDATE = "UPDATE";
        private const string REMOVE = "REMOVE";
        private const string IP_ADDRESS = "10.1.4.41";
        private const int PORT = 3231;

        public void ShowMenu()
        {
            Console.WriteLine("1 - Get");
            Console.WriteLine("2 - Add");
            Console.WriteLine("3 - Update");
            Console.WriteLine("4 - Remove");
            Console.WriteLine("0 - Exit");
            Console.Write("Выберите пункт: ");
        }

        public void Action()
        {
            ShowMenu();
            int menuNumber;
            while (!int.TryParse(Console.ReadLine(), out menuNumber))
            {
                Console.Write("Некорректный ввод! Попробуйте еще раз: ");
            }
            using (var client = new TcpClient())
            {
                client.Connect(new IPEndPoint(IPAddress.Parse(IP_ADDRESS), PORT));
                using (var stream = client.GetStream())
                {
                    switch (menuNumber)
                    {
                        case 0: return;
                        case 1: Get(stream); break;
                        case 2: Add(stream); break;
                        case 3: Update(stream); break;
                        case 4: Remove(stream); break;
                    }

                }

            }
        }
        public Request<T> Get<T>(NetworkStream stream, string nickname)
        {
            return = new Request<T>
            {
                Action = GET,
                Path = "/user/",
                Data = nickname
            };
        }

        private void Add(NetworkStream stream)
        {

        }

        private void Update(NetworkStream stream)
        {
        }

        private void Remove(NetworkStream stream)
        {
        }

    }
}
