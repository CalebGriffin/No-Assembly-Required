using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTableScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This will be used to send to the crafting system, to be validated if it is a valid recipe.
    private List<GameObject> ingredients = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Material"))
        {
            ingredients.Add(other.gameObject); //Add the item placed on the table to list of ingreidents.
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
        GameObject result = CraftingSystem.craftWith(ingredients);
        if(result != null)
        {
            //Success! place it on the table.
            GameObject craftedItem = Instantiate(result);
            craftedItem.transform.position = this.gameObject.transform.position + new Vector3(0.0f, 1.0f, 0.0f);
            craftedItem.SetActive(true);
        }
    }

}
