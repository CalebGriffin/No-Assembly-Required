using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private float moveSpeed;

    public GameObject firstFloor1;
    public GameObject firstFloor2;

    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;

    public Vector2 inputVec;

    private GameObject pickupItem;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Applies gravity
        characterController.Move(-transform.up * 9.81f * Time.deltaTime);

        ActualMove();

        // OLD INPUT SYSTEM
        //if (moveUp)
        //{
            //characterController.Move(transform.forward * moveSpeed * Time.deltaTime); 
        //}
        //if (moveDown)
        //{
            //characterController.Move(-transform.forward * moveSpeed * Time.deltaTime); 
        //}
        //if (moveLeft)
        //{
            //characterController.Move(-transform.right * moveSpeed * Time.deltaTime); 
        //}
        //if (moveRight)
        //{
            //characterController.Move(transform.right * moveSpeed * Time.deltaTime); 
        //} 
    }

    void OnTriggerEnter(Collider other)
    {
        switch(other.GetComponent<Collider>().gameObject.tag)
        {
            case "FirstFloor1":
                firstFloor1.SetActive(true);
                characterController.enabled = false;
                transform.position = new Vector3(14f, 7.5f, -7.2f);
                characterController.enabled = true;
                break;

            case "FirstFloor2":
                firstFloor2.SetActive(true);
                characterController.enabled = false;
                transform.position = new Vector3(-13f, 7.5f, 7.2f);
                characterController.enabled = true;
                break;

            case "GroundFloor1":
                characterController.enabled = false;
                transform.position = new Vector3(9f, 2.2f, -7f);
                characterController.enabled = true;
                firstFloor1.SetActive(false);
                break;
                
            case "GroundFloor2":
                characterController.enabled = false;
                transform.position = new Vector3(-9f, 2.2f, 7f);
                characterController.enabled = true;
                firstFloor2.SetActive(false);
                break;

            default:
                break;
        }
    }

    void OnMove(InputValue input)
    {
        inputVec = input.Get<Vector2>().normalized; 

        //if (inputVec.x > 3)
        //{
            //moveRight = true;
            ////characterController.Move(transform.right * moveSpeed * Time.deltaTime); 
        //}
        //else if (inputVec.x < 0)
        //{
            //moveLeft = true;
            ////characterController.Move(-transform.right * moveSpeed * Time.deltaTime); 
        //}
        //else
        //{
            //moveRight = false;
            //moveLeft = false;
        //}

        //if (inputVec.y > 0)
        //{
            //moveUp = true;
            ////characterController.Move(transform.forward * moveSpeed * Time.deltaTime); 
        //}
        //else if (inputVec.y < 0)
        //{
            //moveDown = true;
            ////characterController.Move(-transform.forward * moveSpeed * Time.deltaTime); 
        //}
        //else
        //{
            //moveUp = false;
            //moveDown = false;
        //}
    }

    void OnPickup(InputValue input)
    {
        if (input.isPressed)
        {
            if (pickupItem != null)
            {
                //Drop current item being held.
                pickupItem.GetComponent<Rigidbody>().useGravity = true;
                pickupItem.transform.parent.SetParent(gameObject.transform.parent);
            }
            else
            {

                float closest = 4.0f; //Only allow minimum pickup range.
                GameObject item = null;

                Vector3 playerPos = new Vector3(transform.position.x, 0.0f, transform.position.z); //Eliminating any sort of height for now.

                //Find an item to pickup, first use a radius search for all materials with material tag.
                GameObject[] materials = GameObject.FindGameObjectsWithTag("Material");
                foreach(GameObject material in materials)
                {
                    Vector3 itemPos = material.transform.position;

                    //Check if it within field of view.
                    if(Vector2.Dot(playerPos,new Vector3(itemPos.x,0.0f,itemPos.y)) >= 45.0f * Mathf.Deg2Rad)
                    {
                        float dist = (itemPos - playerPos).magnitude;
                        if(dist < closest)
                        {
                            closest = dist;
                            item = material;
                        }
                    }
                }

                if(item != null)
                {
                    //ITEM FOUND!!!
                    pickupItem = item;
                    pickupItem.transform.parent.SetParent(gameObject.transform);
                    pickupItem.GetComponent<Rigidbody>().useGravity = false;
                    pickupItem.transform.localPosition = transform.forward * 1.5f;
                }
            }
        }
    }

    void ActualMove()
    {
        if(inputVec != Vector2.zero) //Don't calculate a new rotation if input is zero.
        {
            //This calculates the angle the player need to look in based on input.
            float angle = Mathf.Acos(Vector2.Dot(Vector2.up, inputVec)) * Mathf.Rad2Deg;
            angle *= (inputVec.x < 0.0f ? -1.0f : 1.0f);
            transform.localRotation = Quaternion.Euler(0.0f, angle, 0.0f);

            //Move them.
            characterController.Move(transform.forward * moveSpeed * Time.deltaTime);
        }
    }
}
