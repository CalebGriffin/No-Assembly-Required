using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private float moveSpeed;

    public CraftingTableScript Workbench;
    public StuffingMachineScript StuffingMachine;

    public GameObject firstFloor1;
    public GameObject firstFloor2;

    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;

    public Vector2 inputVec;

    private Transform mountPoint;

    private bool isFrozen = false; //To stop players from moving away from crafting stations and such.

    private bool atWorkbench = false; //Are they in range of crafting table?
    private bool atStuffingMachine = false; //Are they in range of stuffing machine?

    [SerializeField] private GameObject[] allPlayers;
    public Material player1Mat;
    public Material player2Mat;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        mountPoint = gameObject.transform.Find("pickupItem");

        firstFloor1 = GameObject.Find("First Floor (1)");
        firstFloor2 = GameObject.Find("First Floor (2)");

        allPlayers = GameObject.FindGameObjectsWithTag("Player");
        if (allPlayers.Length > 1)
        {
            GetComponent<Renderer>().material = player2Mat;
            characterController.enabled = false;
            transform.position = new Vector3(0f, 2.2f, 5f);
            characterController.enabled = true;
        }
        else
        {
            GetComponent<Renderer>().material = player1Mat;
            characterController.enabled = false;
            transform.position = new Vector3(0f, 2.2f, -5f);
            characterController.enabled = true;
        }
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
        switch(other.gameObject.tag)
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
            case "CraftingTable":
                atWorkbench = true;
                break;
            case "StuffingMachine":
                atStuffingMachine = true;
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "CraftingTable":
                atWorkbench = false;
                break;
            case "StuffingMachine":
                atStuffingMachine = false;
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

            if (mountPoint.transform.childCount > 0)
            {
                GameObject pickupItem = mountPoint.transform.GetChild(0).gameObject;

                //Drop current item being held.
                pickupItem.GetComponent<Rigidbody>().useGravity = true;
                pickupItem.GetComponent<MeshCollider>().enabled = true;
                pickupItem.transform.SetParent(null);

                pickupItem = null;
            }
            else
            {

                float FOV = 45.0f;

                float closest = 6.0f; //Only allow minimum pickup range.
                GameObject item = null;

                Vector3 playerPos = new Vector3(transform.position.x, 0.0f, transform.position.z); //Eliminating any sort of height for now.

                //Find an item to pickup, first use a radius search for all materials with material tag.
                GameObject[] materials = GameObject.FindGameObjectsWithTag("Material");
                foreach(GameObject material in materials)
                {
                    Vector3 itemPos = material.transform.position;

                    itemPos = new Vector3(itemPos.x, 0.0f, itemPos.y);

                    Debug.Log("WITHIN VIEW!");
                    float dist = (itemPos - playerPos).magnitude;
                    if(dist < closest)
                    {
                        closest = dist;
                        item = material;
                    }
                }

                if(item != null)
                {
                    //ITEM FOUND!!!
                    item.transform.SetParent(mountPoint);
                    item.GetComponent<Rigidbody>().useGravity = false;
                    item.GetComponent<MeshCollider>().enabled = false;
                    item.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                }
            }
        }
    }

    void OnUseMachine(InputValue input)
    {
        if (input.isPressed)
        {
            if(atWorkbench)
                isFrozen = Workbench.useWorkbench();
            else if(atStuffingMachine)
                isFrozen = StuffingMachine.useMachine(gameObject);
        }
    }

    void ActualMove()
    {
        if(inputVec != Vector2.zero && !isFrozen) //Don't calculate a new rotation if input is zero.
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
