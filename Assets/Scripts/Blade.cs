using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;

    public GameObject HalfFruitLeft, HalfFruitRight;
    public GameObject HalfFruitLeft2, HalfFruitRight2;
    public GameObject HalfFruitLeft3, HalfFruitRight3;
    int rand;

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
        if (timer > 5)
        {
            Generate();
            timer = 0;
        }
    }

    void Generate()
    {
        Vector3 spawnFruit = new Vector3(Random.Range(-4f, 4f), 2f, 8f);
        rand = Random.Range(1, 4);
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

    void OnCollisionEnter(Collision col)
    {
        if (this.GetComponent<MeshRenderer>().enabled == true && col.gameObject.tag == "Fruit")
        {
            GameObject right, left;
            switch (rand)
            {
                case 1:
                    right = GameObject.Instantiate(HalfFruitRight, col.gameObject.transform.position, Quaternion.identity) as GameObject;
                    left = GameObject.Instantiate(HalfFruitLeft, col.gameObject.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 2:
                    right = GameObject.Instantiate(HalfFruitRight2, col.gameObject.transform.position, Quaternion.identity) as GameObject;
                    left = GameObject.Instantiate(HalfFruitLeft2, col.gameObject.transform.position, Quaternion.identity) as GameObject;
                    break;
                default:
                    right = GameObject.Instantiate(HalfFruitRight3, col.gameObject.transform.position, Quaternion.identity) as GameObject;
                    left = GameObject.Instantiate(HalfFruitLeft3, col.gameObject.transform.position, Quaternion.identity) as GameObject;
                    break;
            }

            right.transform.Rotate(0, 90f, 0);
            right.transform.Translate(0, 0, 0.05f);
            left.transform.Rotate(0, -90f, 0);
            left.transform.Translate(0, 0, 0.05f);
            Destroy(col.gameObject);
        }

    }
}
