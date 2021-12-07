using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBelt : MonoBehaviour
{

    private Vector3 Anchor;

    public bool isReverse = false;
    // Start is called before the first frame update
    void Start()
    {
        Anchor = this.gameObject.transform.GetChild(0).gameObject.transform.position;
        Anchor.y = 0.0f;
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
            if (rigid != null)
            {
                Vector3 objectPos = other.gameObject.transform.position;
                objectPos.y = 0.0f;

                Vector3 toAnchor = (objectPos - Anchor).normalized;

                if(Vector3.Dot(toAnchor,(isReverse ? this.gameObject.transform.right : this.gameObject.transform.forward)) >= 0.0f)
                {
                    other.gameObject.transform.position += Vector3.Cross(toAnchor, this.gameObject.transform.up) * Time.deltaTime * (isReverse ? -2.0f : 2.0f);
                }

            }
        }
    }
}
