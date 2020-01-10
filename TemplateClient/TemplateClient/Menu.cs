using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TemplateClient.Domain;

namespace TemplateClient
{
    public class Menu
    {
        private const string IP_ADDRESS = "10.1.4.41";
        private const string MENU_RETURN = "Нажмите ENTER что бы вернуться в главное меню...";
        private const int PORT = 3231;
        private RequestService<User> requestService = new RequestService<User>(); 

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

        public async void Get<T>(NetworkStream stream)
        {
            Console.Clear();
            Console.Write("Введите никнейм для поиска: ");
            var nickname = Console.ReadLine();
            var response = await requestService.GetAsync(stream, nickname);
            if(response.Data is null)
            {
                Console.WriteLine("Таких пользователей не существует.");
                Console.WriteLine(MENU_RETURN);
                Console.ReadLine();
                return;
            }
            Console.WriteLine($"Фамилия: {response.Data.LastName}.");
            Console.WriteLine($"    Имя: {response.Data.FirstName}.");
            Console.WriteLine($"Никнейм: {response.Data.Nickname}.");
        }

        private async void Add(NetworkStream stream)
        {
            Console.Clear();
        }

        private void Update(NetworkStream stream)
        {
        }

        private void Remove(NetworkStream stream)
        {
        }

    }
}
