using ConsoleApp1.ApiTypes;

namespace ConsoleApp1;

public abstract class Printer
{
    public static void PrintMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to VESearch!");
        Console.WriteLine("Please select from one of the options:");
        Console.WriteLine("1: Search");
        Console.WriteLine("2: Log in -- feature not implemented yet, sorry!");
        Console.WriteLine("3: Sign up -- feature not implemented yet, sorry!");
        Console.WriteLine("Or enter 0 to exit the program");
    }

    public static void PrintSearchMenu()
    {
        Console.Clear();
        Console.WriteLine("Please enter a recipe name:");
        Console.WriteLine("Or enter 0 to return to previous page");
    }

    public static void PrintRecipesMenu(Recipe[] results)
    {
        Console.Clear();
        Console.WriteLine("Please select a recipe from the list:");

        for (var i = 0; i < results.Length; i++)
        {
            Console.WriteLine($"{i + 1}: {results[i].Name}");
            Console.WriteLine($"    Author: {results[i].Author.Username}");
            Console.WriteLine($"    Cook Time: {results[i].CookTime} minutes");
            Console.WriteLine($"    Difficulty: {results[i].Difficulty}");
            Console.WriteLine($"    Rating: {results[i].RatingsAverage}/5");
        }

        Console.WriteLine("Or enter 0 to restart search");
    }

    public static void PrintRecipe(Recipe recipe)
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J");
        Console.WriteLine($"------------------------------------------");

        Console.WriteLine($"Recipe Name: {recipe.Name}");
        Console.WriteLine($"By {recipe.Author.Username}");
        Console.WriteLine($"Preparation Time: {recipe.PrepTime}");
        Console.WriteLine($"Cook Time: {recipe.CookTime}");
        Console.WriteLine($"Difficulty: {recipe.Difficulty}");
        Console.WriteLine($"Total servings: {recipe.Servings}");
        Console.WriteLine($"Description: {recipe.Description}");

        Console.WriteLine($"------------------------------------------");

        Console.WriteLine($"Ingredients:");
        for (var i = 0; i < recipe.Ingredients.Length; i++)
        {
            Console.WriteLine($"    {i + 1}: {recipe.Ingredients[i].Name}");
            Console.WriteLine($"        {recipe.Ingredients[i].Amount} {recipe.Ingredients[i].Measurement}");
        }

        Console.WriteLine($"------------------------------------------");

        Console.WriteLine($"Methods:");
        if (recipe.MethodsProvided)
        {
            for (var i = 0; i < recipe.Methods.Length; i++)
            {
                Console.WriteLine($"    {i + 1}: {recipe.Methods[i].MethodInstruction}");
            }
        }
        else
        {
            Console.WriteLine($"Recipe here {recipe.MethodsAlternative}");
        }

        Console.WriteLine($"------------------------------------------");

        Console.WriteLine($"Reviews:");

        for (var i = 0; i < recipe.Reviews.Length; i++)
        {
            Console.WriteLine($"------------------------------------------");
            Console.WriteLine($"Thoughts: {recipe.Reviews[i].Comment}");
            Console.WriteLine($"Rating: {recipe.Reviews[i].Rating}");
            Console.WriteLine($"By: {recipe.Reviews[i].Author.Username}");
            Console.WriteLine($"------------------------------------------");
        }

        Console.WriteLine($"Please enter 0 to return to restart search");
    }

    public static void PrintLoadingMessage(string name)
    {
        Console.WriteLine($"Loading {name}...");
    }
}