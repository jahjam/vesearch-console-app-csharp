using System.Net.Http.Headers;
using ConsoleApp1.ApiTypes;

namespace ConsoleApp1.Api;

public class ApiModel
{
    public ApiModel(ref HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://vesearch-api-backend-production.up.railway.app/api/v1/");
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    private async Task<string> Fetch(string path)
    {
        var response = await _client.GetAsync(path);
        var resString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            var apiError = ApiError.FromJson(resString);

            throw new Exception(apiError?.Message);
        }

        return resString;
    }

    public async Task<Recipe> GetRecipe(string id)
    {
        try
        {
            var resString = await this.Fetch($"recipes/{id}");

            var recipe = SingleRecipe.FromJson(resString);

            if (recipe == null)
            {
                throw new Exception("Oops, something went wrong!");
            }

            return recipe.Data.Recipe;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<int> GetRecipeRating(int id)
    {
        try
        {
            var resString = await this.Fetch($"reviews/ratingsAverage/{id}");

            var avRating = RatingAverage.FromJson(resString);

            if (avRating == null)
            {
                throw new Exception("Oops, something went wrong!");
            }

            return avRating.Data.Ratings[0].AvgRatings;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Recipe[]> GetRecipes(string? recipe)
    {
        try
        {
            Console.WriteLine("Searching for {0}...", recipe);

            var resString = await this.Fetch($"recipes?name={recipe}");

            var recipes = Recipes.FromJson(resString);

            if (recipes == null)
            {
                throw new Exception("Oops, something went wrong!");
            }

            return recipes.Data.Recipes;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private readonly HttpClient _client;
}