using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject enemy;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>5)
        {
            Generate();
            timer = 0;
        }
    }

    void Generate()
    {
        Vector3 spawnFruit = new Vector3(Random.Range(-3f, 3f), 1f, 8f);
        Instantiate(enemy, spawnFruit, Quaternion.identity);
    }



}
