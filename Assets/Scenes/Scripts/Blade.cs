using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private string scorepath;

    void Start()
    {
        game = false;
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
            WriteScore();
        }

        if (Lives == 0 && GameTypeLives)
        {
            game = false;
            TimeText.text = "You died";
            WriteScore();
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
            switch (col.gameObject.name)
            {
                case "EasySphere":
                    this.level = 1;
                    this.Lives = 5;
                    if (GameTypeLives) //only in time game type more time means easier gameplay
                    {
                        this.levelTime = 60;
                    }
                    else
                    {
                        this.levelTime = 180; //pnly time type
                    }
                    break;
                case "HardSphere":
                    this.level = 3;
                    this.Lives = 2;
                    if (GameTypeLives)
                    {
                        this.levelTime = 120;
                    }
                    else
                    {
                        this.levelTime = 100; //pnly time type
                    }
                    break;
                default:
                    this.level = 2;
                    this.Lives = 3;
                    if (GameTypeLives)
                    {
                        this.levelTime = 90;
                    }
                    else
                    {
                        this.levelTime = 120; //pnly time type
                    }
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

    private void WriteScore()
    {
        

        string[] scores = { "0", "0", "0" , "0", "0", "0", "0", "0", "0" };
        scorepath = Application.persistentDataPath + "/settings.txt";
        if (!File.Exists(scorepath))
        {
                File.WriteAllLines(scorepath, scores);
        }
        scores = File.ReadAllLines(scorepath);
        int row;

        if(this.GameTypeLives && this.GameTypeTime)
        {
            row = 2;
        }
        else if(this.GameTypeLives)
        {
            row = 1;
        }
        else
        {
            row = 0;
        }

        switch (level)
        {
            case 1:
                if (Score > System.Int32.Parse(scores[0 + 3 * row]))
                    scores[0 + 3 * row] = Score.ToString();
                break;
            case 3:
                if (Score > System.Int32.Parse(scores[2 + 3 * row]))
                    scores[2 + 3 * row] = Score.ToString();
                break;
            default:
                if (Score > System.Int32.Parse(scores[1 + 3 * row]))
                    scores[1 + 3 * row] = Score.ToString();
                break;
        }
        File.WriteAllLines(scorepath, scores);
    }

    
}
