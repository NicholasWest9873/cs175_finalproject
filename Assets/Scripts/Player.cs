using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;

    private Vector3 jumpHeight = 7 * Vector3.up;
    private bool jumpKeyWasPressed;
    private float horiztonalInput;
    private float verticalInput;
    private Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horiztonalInput = Input.GetAxis("Horizontal");

    }
    // Fixed update is called once every physics update
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horiztonalInput, rigidbodyComponent.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(jumpHeight, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }


    }

}


