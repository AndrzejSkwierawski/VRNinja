using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Results : MonoBehaviour
{
    public TextMesh LabelText, Level1Text, Level2Text, Level3Text;
    private string scorepath;
    // Start is called before the first frame update
    void Start()
    {
        ReadScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadScore()
    {
        string[] scores = { "0", "0", "0", "0", "0", "0", "0", "0", "0" };
        scorepath ="./settings.txt";
      
        if (File.Exists(scorepath))
        {
            scores = File.ReadAllLines(scorepath);
        }
        LabelText.text = "Type\nTime:\nLives:\nMixed:";
        Level1Text.text = "Level 1\n"+scores[0]+"\n" + scores[3] + "\n" + scores[6];
        Level2Text.text = "Level 2\n" + scores[1] + "\n" + scores[4] + "\n" + scores[7];
        Level3Text.text = "Level 3\n" + scores[2] + "\n" + scores[5] + "\n" + scores[8];
    }
}
