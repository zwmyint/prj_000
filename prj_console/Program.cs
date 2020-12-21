using System;

namespace prj_console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var booksBLL = new BookBusinessLogic();


            // inft loop
            while (true)
            {
                Console.WriteLine("... ................ ...");
                Console.WriteLine("... Book Application ...");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("     - Type L to see a list of all the books.");
                Console.WriteLine("     - Type D:{book title} to see the description of book.");
                Console.WriteLine("     - Type E to exist.");
                Console.WriteLine("... ................ ...");

                string command = Console.ReadLine();
                switch (command)
                {
                    case "L":
                        // Console.WriteLine("Listing all the books.");
                        var books = booksBLL.GetBooks();
                        Console.WriteLine("All Books >>> ");
                        foreach (var b in books)
                        {
                            Console.WriteLine($"- {b.Title}");
                        }
                        break;
                    case string str when command.StartsWith("D"):
                        // Console.WriteLine("Get detailed info: of a book.");
                        var parts = command.Split(':'); //parts is arr
                        
                        try{
                            var b = booksBLL.GetBookByTitle(parts[1]);
                            Console.WriteLine("*** ................ ................ ***");
                            Console.WriteLine($"Title : {b.Title}");
                            Console.WriteLine($"Description : {b.Description}");
                            Console.WriteLine("*** ................ ................ ***");
                        }
                        catch{
                            Console.WriteLine("Please provide the command in correct format: D:{book title} without the curly braces.");
                        }

                        break;
                    case "E":
                        return;
                    default:
                        break;
                }


            }

            //
        }
    }
}
