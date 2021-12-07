using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Movement : MonoBehaviour
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
        inputVec = input.Get<Vector2>(); 

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

    void ActualMove()
    {
        if (inputVec.x > 0)
        {
            characterController.Move(transform.right * moveSpeed * Time.deltaTime); 
        }
        else if (inputVec.x < 0)
        {
            characterController.Move(-transform.right * moveSpeed * Time.deltaTime); 
        }

        if (inputVec.y > 0)
        {
            characterController.Move(transform.forward * moveSpeed * Time.deltaTime); 
        }
        else if (inputVec.y < 0)
        {
            characterController.Move(-transform.forward * moveSpeed * Time.deltaTime); 
        }

    }
}
