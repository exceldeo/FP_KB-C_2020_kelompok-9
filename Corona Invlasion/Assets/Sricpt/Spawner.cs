using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnSport;
    private float timeBtwSpanwns;
    public float startTimeBtwSpawns;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpanwns = startTimeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwSpanwns <= 0 ){
            int randPos = Random.Range(0,spawnSport.Length -1);
            Instantiate(enemy, spawnSport[randPos].position, Quaternion.identity);
            timeBtwSpanwns = startTimeBtwSpawns;
        }
        else{
            timeBtwSpanwns -= Time.deltaTime;
        }
    }
}
