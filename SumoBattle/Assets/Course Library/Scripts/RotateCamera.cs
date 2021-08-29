using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    //Properties...
    public float horizontalInput;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Mouse X") *-1;
        //transform.Rotate(Vector3.right, verticalInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);
    }
}
