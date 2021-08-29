using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Properties...
    private GameObject player;
    private Rigidbody enemyRB;
    private Vector3 direction;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        chasePlayer();
    }

    void chasePlayer()
    {
        direction = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(direction * speed * Time.deltaTime);
    }
}
