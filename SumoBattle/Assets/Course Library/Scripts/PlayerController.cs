using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject focalPoint;
    private Rigidbody playerRB;
    public float force = 20.0f;
    private float verticalInput;
    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        playerRB.AddForce(focalPoint.transform.forward * force * verticalInput *Time.deltaTime);
        playerRB.AddForce(focalPoint.transform.right * force * horizontalInput * Time.deltaTime);
    }
}
