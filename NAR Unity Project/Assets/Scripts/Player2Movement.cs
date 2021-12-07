using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private float moveSpeed;

    public GameObject firstFloor1;
    public GameObject firstFloor2;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Applies gravity
        characterController.Move(-transform.up * 9.81f * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move(transform.forward * moveSpeed * Time.deltaTime); 
        }
        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(-transform.forward * moveSpeed * Time.deltaTime); 
        }
        if (Input.GetKey("A"))
        {
            characterController.Move(-transform.right * moveSpeed * Time.deltaTime); 
        }
        if (Input.GetKey("D"))
        {
            characterController.Move(transform.right * moveSpeed * Time.deltaTime); 
        } 
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
}
