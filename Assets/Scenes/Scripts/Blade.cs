using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public bool GameTypeLives;
    public bool GameTypeTime;

    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;

    public GameObject HalfFruitLeft, HalfFruitRight;
    public GameObject HalfFruitLeft2, HalfFruitRight2;
    public GameObject HalfFruitLeft3, HalfFruitRight3;

    public TextMesh TimeText;
    public TextMesh ScoreText;
    public TextMesh LivesText;

    public int level;

    public int Lives = 3;
    public int Score = 0;
    private float levelTime = 60;

    private float timer = 0;

    private int rand;
    private bool game;
    // Start is called before the first frame update
    void Start()
    {
        game = false;
        //Generate();
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = Lives.ToString();
        ScoreText.text = Score.ToString();

        if (levelTime <= 0 && GameTypeTime)
        {
            game = false;
            TimeText.text = "Times's up";

        }

        if (Lives == 0 && GameTypeLives)
        {
            game = false;
            TimeText.text = "You died";

        }
        if (game)
        {
            timer += Time.deltaTime;
            levelTime -= Time.deltaTime;
            TimeText.text = levelTime.ToString();

            if (timer > 5)
            {
                Generate();
                timer = 0;
            }
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
                fruit.tag = "Apple";
                break;
            case 2:
                fruit = GameObject.Instantiate(enemy2, spawnFruit, Quaternion.identity);
                fruit.tag = "Strawberry";
                break;
            default:
                fruit = GameObject.Instantiate(enemy3, spawnFruit, Quaternion.identity);
                fruit.tag = "Kiwi";
                break;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (this.GetComponent<MeshRenderer>().enabled == true && (col.gameObject.tag == "Kiwi" || col.gameObject.tag == "Strawberry" || col.gameObject.tag == "Apple"))
        {
            GameObject right, left;
            switch (col.gameObject.tag)
            {
                case "Apple":
                    right = GameObject.Instantiate(HalfFruitRight, col.gameObject.transform.position, Quaternion.identity) as GameObject;
                    left = GameObject.Instantiate(HalfFruitLeft, col.gameObject.transform.position, Quaternion.identity) as GameObject;
                    Score = 2;
                    break;
                case "Strawberry":
                    right = GameObject.Instantiate(HalfFruitRight2, col.gameObject.transform.position, Quaternion.identity) as GameObject;
                    left = GameObject.Instantiate(HalfFruitLeft2, col.gameObject.transform.position, Quaternion.identity) as GameObject;
                    Score = 6;
                    break;
                default:
                    right = GameObject.Instantiate(HalfFruitRight3, col.gameObject.transform.position, Quaternion.identity) as GameObject;
                    left = GameObject.Instantiate(HalfFruitLeft3, col.gameObject.transform.position, Quaternion.identity) as GameObject;
                    Score = 4;
                    break;
            }

            right.transform.Rotate(0, 90f, 0);
            right.transform.Translate(0, 0, 0.05f);
            left.transform.Rotate(0, -90f, 0);
            left.transform.Translate(0, 0, 0.05f);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Choice")
        {
            Move[] fruits = (Move[])GameObject.FindObjectsOfType(typeof(Move));
            switch (col.gameObject.name)
            {
                case "EasySphere":
                    level = 1;
                    break;
                case "HardSphere":
                    level = 3;
                    break;
                default:
                    level = 2;
                    break;
            }

            game = true;

            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Choice");
            for (var i = 0; i < gameObjects.Length; i++)
            {
                Destroy(gameObjects[i]);
            }
        }
    }
}
