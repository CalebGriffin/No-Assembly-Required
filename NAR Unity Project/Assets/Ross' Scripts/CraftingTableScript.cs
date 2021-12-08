using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingTableScript : MonoBehaviour
{

    private GameObject craftingEmitter;

    private ParticleSystem particle;

    private GameObject result;
    private int clicks = 0;
    private int requiredClicks = 15;
    // Start is called before the first frame update
    void Start()
    {
        craftingEmitter = gameObject.transform.GetChild(0).gameObject;
        particle = craftingEmitter.GetComponent<ParticleSystem>();

        CraftingSystem.addRecipe(new List<string>() { "Planks", "Metal" }, GameObject.Find("Paint")); //THIS IS A TEST RECIPE!!!
        CraftingSystem.addRecipe(new List<string>() { "Oil", "Fabrics" }, GameObject.Find("Plastic"));
        CraftingSystem.addRecipe(new List<string>() { "Plastic" }, GameObject.Find("Building Blocks"));
    }

    private float simTime = 0.0f;
    private List<float> clicksTime = new List<float>();

    // Update is called once per frame
    void Update()
    {
        //This is to remove all items that may be still in the trigger.
        //But is being held by a player.
        for (int i = ingredients.Count - 1; i > -1; i--)
            if (ingredients[i].transform.parent != null)
                ingredients.RemoveAt(i);

        if (result != null)
        {

            /* This simTime and for loops is being used to measure clicks per second.
             * Thus making the emission go faster with higher clicks per second.
             */
            simTime += Time.deltaTime;
            for (int i = clicksTime.Count - 1; i > -1; i--)
                if (simTime - clicksTime[i] >= 1.0f)
                    clicksTime.RemoveAt(i);

            particle.emissionRate = 10.0f * (1.0f + (float)clicksTime.Count);

            if (clicks >= requiredClicks)
            {
                //Stop the emitter.
                craftingEmitter.SetActive(false);

                //Success! place it on the table.
                GameObject craftedItem = Instantiate(result);
                craftedItem.transform.position = this.gameObject.transform.position + new Vector3(0.0f, 1.25f, 0.0f);
                craftedItem.name = result.name;
                craftedItem.SetActive(true);

                result = null; //Set this back to null.
            }
        }
    }

    //This will be used to send to the crafting system, to be validated if it is a valid recipe.
    private List<GameObject> ingredients = new List<GameObject>();

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Material") && !ingredients.Contains(other.gameObject) && other.gameObject.transform.parent == null)
        {
            ingredients.Add(other.gameObject); //Add the item placed on the table to list of ingredients if they are not being hold by the player.
        }
    }

    public bool useWorkbench()
    {
        //See if we can create something with the given ingredients?
        if (result == null)
        {

            List<GameObject> validIngredients = new List<GameObject>();
            for (int i = ingredients.Count - 1; i > -1; i--)
                if (ingredients[i].transform.parent == null)
                    validIngredients.Add(ingredients[i]);

            result = CraftingSystem.craftWith(ingredients);
            if (result != null)
            {
                craftingEmitter.SetActive(true);
                clicksTime.Clear();
                clicks = 0;
                simTime = 0.0f;

                //Delete all the ingredients to prevent duplicating!
                for (int i = ingredients.Count - 1; i > -1; i--)
                    Destroy(ingredients[i]);
                ingredients.Clear();

                return true;
            }

            return false;
        }
        else
        {
            clicksTime.Add(simTime);
            clicks++;
        }

        return (clicks < requiredClicks);
    }
}
