using ConsoleApp1.Api;

namespace ConsoleApp1;

public class Search
{
    public static async Task HandleSearch(ApiModel api)
    {
        var searching = true;

        while (searching)
        {
            Printer.PrintSearchMenu();

            var recipe = Console.ReadLine();

            if (recipe == "0")
            {
                break;
            }

            if (string.IsNullOrEmpty(recipe))
            {
                continue;
            }

            try
            {
                var results = await api.GetRecipes(recipe);

                Printer.PrintRecipesMenu(results);

                var recipeSelection = Console.ReadLine();

                switch (recipeSelection)
                {
                    case "0":
                        continue;
                    case null:
                        throw new Exception("Oops, something went wrong!");
                    default:
                    {
                        var foundRecipeId = results[int.Parse(recipeSelection) - 1].Id;
                        var foundRecipeName = results[int.Parse(recipeSelection) - 1].Name;

                        Printer.PrintLoadingMessage(foundRecipeName);

                        var recipeResult = await api.GetRecipe(foundRecipeId);
                        var isViewingRecipe = true;

                        while (isViewingRecipe)
                        {
                            Printer.PrintRecipe(recipeResult);

                            var option = Console.ReadLine();

                            if (option != "0")
                            {
                                continue;
                            }

                            isViewingRecipe = false;
                        }

                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            searching = false;
        }
    }
}