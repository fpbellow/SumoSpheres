using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float enemySpeed = 1.0f;
    public AudioClip deathSound;

    private Rigidbody enemyRb;
    private GameObject playerObject;
    private SpawnManager spawnManager;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerObject = GameObject.Find("Player");
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10) {
            gameManager.playAudioClip(deathSound, 0.45f);
            Destroy(gameObject);

        }
        Vector3 lookDirection = (playerObject.transform.position - enemyRb.transform.position).normalized;
        enemyRb.AddForce(lookDirection * enemySpeed); ;
    }
}
