using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Properties...
    public GameObject focalPoint;
    public float impactForce = 10.0f;
    public float force = 20.0f;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    private Rigidbody playerRB;
    private float verticalInput;
    private float horizontalInput;
   
    private Rigidbody enemyRB;
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
        powerupIndicator.transform.position = transform.position + new Vector3(0.0f, -0.5f,0.0f);

        if(transform.position.y <= -30.0f)
        {
            Destroy(gameObject);
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp") && !hasPowerup)
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRB.AddForce(awayFromPlayer * impactForce, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + " with power up set to " + hasPowerup);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}
