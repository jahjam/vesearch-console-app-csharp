namespace ConsoleApp1;

class Program
{
    private static HttpClient _client = new();

    private static async Task Main()
    {
        var api = new Api.ApiModel(ref _client);
        var running = true;

        while (running)
        {
            Printer.PrintMainMenu();
            var selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    await Search.HandleSearch(api);
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "0":
                    Console.WriteLine("Exiting...");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    break;
            }
        }
    }
}