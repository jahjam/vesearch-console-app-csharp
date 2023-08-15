namespace ConsoleApp1.ApiTypes;

using Newtonsoft.Json;

public class Recipes
{
    public static Recipes? FromJson(string json) => JsonConvert.DeserializeObject<Recipes>(json);

    [JsonProperty("numOfResults")] public required long NumOfResults { get; set; }
    [JsonProperty("data")] public required RecipesData Data { get; set; }
}

public class SingleRecipe
{
    public static SingleRecipe? FromJson(string json) => JsonConvert.DeserializeObject<SingleRecipe>(json);
    
    [JsonProperty("data")] public required RecipeData Data { get; set; }
}

public class RecipesData
{
    [JsonProperty("recipes")] public required Recipe[] Recipes { get; set; }
}

public class RecipeData
{
    [JsonProperty("recipe")] public required Recipe Recipe { get; set; }
}

public class Recipe
{
    [JsonProperty("_id")]
    public required string Id { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("author")]
    public required Author Author { get; set; }

    [JsonProperty("prepTime")]
    public required long PrepTime { get; set; }

    [JsonProperty("cookTime")]
    public required long CookTime { get; set; }

    [JsonProperty("difficulty")]
    public required string Difficulty { get; set; }

    [JsonProperty("servings")]
    public required long Servings { get; set; }

    [JsonProperty("ratingsAverage")]
    public required long RatingsAverage { get; set; }

    [JsonProperty("description")]
    public required string Description { get; set; }

    [JsonProperty("dietTags")]
    public required string[] DietTags { get; set; }

    [JsonProperty("ingredients")]
    public required Ingredient[] Ingredients { get; set; }

    [JsonProperty("methodsProvided")]
    public required bool MethodsProvided { get; set; }
    
    [JsonProperty("methodsAlternative")]
    public required string MethodsAlternative { get; set; }

    [JsonProperty("methods")]
    public required Method[] Methods { get; set; }

    [JsonProperty("reviews")]
    public required Review[] Reviews { get; set; }
}

public class Ingredient
{
    [JsonProperty("amount")]
    public required long Amount { get; set; }

    [JsonProperty("measurement")]
    public required string Measurement { get; set; }

    [JsonProperty("name")]
    public required string Name { get; set; }
}

public class Method
{

    [JsonProperty("method")]
    public required string MethodInstruction { get; set; }

}

public class Review
{

    [JsonProperty("rating")]
    public required long Rating { get; set; }

    [JsonProperty("comment")]
    public required string Comment { get; set; }

    [JsonProperty("author")]
    public required Author Author { get; set; }
    
}

public partial class Author
{
    [JsonProperty("username")] public required string Username { get; set; }
}