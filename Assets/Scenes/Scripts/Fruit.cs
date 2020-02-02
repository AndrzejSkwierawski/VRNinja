using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;

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
        Vector3 spawnFruit = new Vector3(Random.Range(-4f, 4f), 2f, 8f);
        int rand = Random.Range(1, 3);
        GameObject fruit;
        switch (rand)
        {
            case 1:
                fruit = GameObject.Instantiate(enemy, spawnFruit, Quaternion.identity);
                break;
            case 2:
                fruit = GameObject.Instantiate(enemy2, spawnFruit, Quaternion.identity);
                break;
            default:
                fruit = GameObject.Instantiate(enemy3, spawnFruit, Quaternion.identity);
                break;
        }

        fruit.tag = "Fruit";
    }



}
