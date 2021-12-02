using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] private float moveSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Applies gravity
        characterController.Move(-transform.up * 9.81f * Time.deltaTime);

        if (Input.GetKey("up"))
        {
            characterController.Move(transform.forward * moveSpeed * Time.deltaTime); 
        }
        if (Input.GetKey("down"))
        {
            characterController.Move(-transform.forward * moveSpeed * Time.deltaTime); 
        }
        if (Input.GetKey("left"))
        {
            characterController.Move(-transform.right * moveSpeed * Time.deltaTime); 
        }
        if (Input.GetKey("right"))
        {
            characterController.Move(transform.right * moveSpeed * Time.deltaTime); 
        } 
    }
}
