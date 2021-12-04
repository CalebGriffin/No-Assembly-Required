using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Making it a static class so it can be accessed globally.
public static class CraftingSystem
{
    //The key string will be a combined list of items such as: WoodNailsOil, the second being the name of item it makes such as: ToyTrain
    private static Dictionary<string, GameObject> Recipes = new Dictionary<string, GameObject>();
    public static void addRecipe(List<string> ingredients, GameObject result)
    {
        //Sort the list alphabetically.
        ingredients.Sort();

        //Produce a recipe key.
        string recipe = "";
        for(int i = 0; i < ingredients.Count; i++)
        {
            recipe = recipe + ingredients[i];
        }

        //Uppercase it, so it is not case-sensitive.
        recipe = recipe.ToUpper();

        //Check if recipe does not exist.
        if (!Recipes.ContainsKey(recipe))
        {
            //One does not exist, we can add this recipe.
            Recipes.Add(recipe, result);
        }
    }

    public static GameObject craftWith(List<GameObject> ingredients)
    {
        //Get a list of all the items name.
        List<string> ingredientsName = new List<string>();
        for(int i = 0; i < ingredients.Count; i++)
        {
            ingredientsName.Add(ingredients[i].name);
        }

        //Sort it alphabetically.
        ingredientsName.Sort();

        //Make our recipe key.
        string recipe = "";
        for (int i = 0; i < ingredientsName.Count; i++)
        {
            recipe = recipe + ingredientsName[i];
        }

        //Uppercase it for consistency of not being case-sensitive.
        recipe = recipe.ToUpper();

        if (Recipes.ContainsKey(recipe))
        {
            //SUCCESS!
            return Recipes[recipe];
        }
        //FAILED...
        return null;
    }
}
