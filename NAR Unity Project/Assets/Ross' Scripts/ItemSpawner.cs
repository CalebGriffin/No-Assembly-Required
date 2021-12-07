using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    private float lifeTime = 0.0f; //This will reset to zero once it reaches spawnTime, and spawn spawnItem

    public GameObject spawnItem; //Spawn item to use

    public int spawnTime = 1000; //period of time in ms should an item spawn per by?
    public int maxItems = 3; //How many items can it spawn at any given time?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnItem != null) //Check if there is an item being assigned to this spawner.
        {
            if (lifeTime >= ((float)spawnTime * 0.001f) && gameObject.transform.childCount < maxItems)
            {
                GameObject newItem = Instantiate(spawnItem, gameObject.transform);
                newItem.name = spawnItem.name; //Have it exactly the same name, to not cause confusion with the crafting system.
                newItem.transform.position = gameObject.transform.position;
                newItem.SetActive(true);
                lifeTime = 0.0f;
            }
            else
            {
                lifeTime += Time.deltaTime;
            }
        }
    }
}
