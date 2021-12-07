using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTableScript : MonoBehaviour
{

    private GameObject craftingEmitter;

    private ParticleSystem particle;

    private GameObject result = null;
    private int clicks = 0;
    // Start is called before the first frame update
    void Start()
    {
        craftingEmitter = gameObject.transform.GetChild(0).gameObject;
        particle = craftingEmitter.GetComponent<ParticleSystem>();

        CraftingSystem.addRecipe(new List<string>() { "Planks", "Metal" }, GameObject.Find("Paint")); //THIS IS A TEST RECIPE!!!
    }

    private float simTime = 0.0f;
    private List<float> clicksTime = new List<float>();

    // Update is called once per frame
    void Update()
    {
        if(result != null)
        {

            /* This simTime and for loops is being used to measure clicks per second.
             * Thus making the emission go faster with higher clicks per second.
             */
            simTime += Time.deltaTime;
            for (int i = clicksTime.Count - 1; i > -1; i--)
                if (simTime - clicksTime[i] >= 1.0f)
                    clicksTime.RemoveAt(i);

            particle.emissionRate = 10.0f * (1.0f + (float)clicksTime.Count);

            if (clicks >= 15)
            {
                //Stop the emitter.
                craftingEmitter.SetActive(false);

                //Delete all the ingredients!
                for (int i = ingredients.Count - 1; i > -1; i--)
                    Destroy(ingredients[i]);
                ingredients.Clear();

                //Success! place it on the table.
                GameObject craftedItem = Instantiate(result);
                craftedItem.transform.position = this.gameObject.transform.position + new Vector3(0.0f, 1.25f, 0.0f);
                craftedItem.SetActive(true);

                result = null; //Set this back to null.
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (result == null)
            {
                attemptCraft();
            }
            else
            {
                clicksTime.Add(simTime);
                clicks++;
            }
        }
    }

    //This will be used to send to the crafting system, to be validated if it is a valid recipe.
    private List<GameObject> ingredients = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Material"))
        {
            ingredients.Add(other.gameObject); //Add the item placed on the table to list of ingredients.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Material"))
        {
            ingredients.Remove(other.gameObject); //Remove the item that been taken off the table.
        }
    }

    public void attemptCraft()
    {
        //See if we can create something with the given ingredients?
        result = CraftingSystem.craftWith(ingredients);
        if (result != null)
        {
            craftingEmitter.SetActive(true);
            clicksTime.Clear();
            clicks = 0;
            simTime = 0.0f;
        }
    }
}
