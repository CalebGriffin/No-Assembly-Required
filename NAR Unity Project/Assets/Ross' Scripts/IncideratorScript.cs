using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncideratorScript : MonoBehaviour
{

    public OrderSystemScript orderSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Material"))
        {
            if (orderSystem != null)
            {
                if (orderSystem.completeOrder(other.gameObject.name))
                    Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
