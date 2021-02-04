using System;

namespace The_Diary
{
    class Program
    {
        static void Main(string[] args)
        {
            Users users = new Users();
            
            Console.WriteLine(new string ('*', 50));
            Console.WriteLine("Welcome to The Diary!");
            Console.WriteLine(new string ('*', 50));
            
            while (true)
            {
                Console.WriteLine("\nDo you have an account?");
                Console.WriteLine("\"y - yes\", \"n - no, I want to create one\", \"q - quit\"");
                char answer = Console.ReadKey().KeyChar;

                switch (answer)
                {
                    case 'y':
                    {
                        string login = Users.UserAuthorization();
                        bool isAuthorized = users.IsAuthorized;
                        if (isAuthorized && login != null)
                        {
                            Users.CreatingNewNote(login);
                        }
                        continue;
                    }

                    case 'n':
                    {
                        Users.CreatingNewUser();
                        continue;
                    }
                }

                switch (answer)
                {
                    case 'q' :
                        break;
                    
                    default:
                        continue;
                }
                
                break;
            }
        }
    }
}