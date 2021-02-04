using System;
using System.Collections.Specialized;
using System.IO;

namespace The_Diary
{
    public class Users
    {
        private static NameValueCollection _list = new NameValueCollection();
        private static bool _isAuthorized;

        public bool IsAuthorized
        {
            get
            {
                return _isAuthorized;
            }
        }

        public Users()
        {
            _list.Add("admin", "admin");
        }
        
        public static void CreatingNewUser()
        {
            while (true)
            {
                Console.WriteLine("\nPlease, enter your login:");
                string login = Console.ReadLine();

                if (String.IsNullOrEmpty(login))
                {
                    Console.WriteLine("Skipping...");
                    break;
                }

                if (!CheckingLogin(login))
                {
                    Console.WriteLine("Please, enter your password:");
                    string pass = Console.ReadLine();
                    _list.Add(login, pass);
                }

                else
                {
                    Console.WriteLine("Such login is already exist! Please, enter unique login.");
                    continue;
                }
                
                break;
            }
        }

        public static string UserAuthorization()
        {
            string authorizedLogin = null;
            
            while (true)
            {
                Console.WriteLine("\nPlease, enter your login:");
                string login = Console.ReadLine();

                if (String.IsNullOrEmpty(login))
                {
                    Console.WriteLine("Skipping...");
                    break;
                }
            
                if (CheckingLogin(login))
                {
                    Console.WriteLine("Please, enter your password:");
                    string pass = Console.ReadLine();

                    if (_list[login].Contains(pass))
                    {
                        Console.WriteLine($"Welcome {login}!");
                        _isAuthorized = true;
                        authorizedLogin = login;
                    }

                    else
                    {
                        Console.WriteLine($"Password is incorrect.");
                        continue;
                    }
                }

                else
                {
                    Console.WriteLine($"User with login \"{login}\" doesn't exist.");
                    continue;
                }
                
                break;
            }
            
            return authorizedLogin;
        }

        static bool CheckingLogin(string login)
        {
            bool isExist = true;
            
            for (int i = 0; i < _list.Count; i++)
            {
                if (login != _list[i])
                {
                    isExist = false;
                }

                else
                {
                    isExist = true;
                    break;
                }
            }

            return isExist;
        }

        public static void CreatingNewNote(string login)
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt);

            Console.WriteLine("Enter your note:");

            StreamWriter sw = new StreamWriter("NotesOf" + login + ".txt", true);
            dt = DateTime.Now;
            sw.WriteLine(dt);

            while (true)
            {
                string newLine = Console.ReadLine();

                if (newLine == "data")
                {
                    Stream s = new FileStream("NotesOf" + login + ".txt", FileMode.Open, FileAccess.Read,
                        FileShare.ReadWrite);
                    
                    StreamReader sr = new StreamReader(s);

                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
            
                if (newLine != "quit")
                {
                    sw.WriteLine(newLine);
                }

                else
                {
                    sw.WriteLine("");
                    sw.Close();
                    break;
                }
            }
        }
    }
}