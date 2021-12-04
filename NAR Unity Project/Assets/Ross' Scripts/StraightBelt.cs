using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBelt : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isReverse = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("Conveyor"))
        {
            //Start moving the items.
            Rigidbody rigid = other.gameObject.GetComponent<Rigidbody>();
            if(rigid != null)
            {
                other.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * (isReverse ? -2.0f : 2.0f);
            }
        }
    }

}
