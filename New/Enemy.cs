using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform playerPos;
    private Player player;
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);

            //player losing health
            player.health--;
            Debug.Log(player.health);
            Destroy(gameObject);
        }

        if(other.CompareTag("Projectile"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
