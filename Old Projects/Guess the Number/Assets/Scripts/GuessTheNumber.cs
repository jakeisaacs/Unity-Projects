using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessTheNumber : MonoBehaviour
{
    public InputField input;
    public Text infoText;

    private int randNum, userNum;


    // Start is called before the first frame update
    void Start()
    {
        randNum = Random.Range(0, 100);
    }

    public void CheckGuess()
    {
        userNum = int.Parse(input.text);

        if(userNum == randNum)
        {
            infoText.text = "You got it!";
        }
        else if(userNum > randNum)
        {
            infoText.text = "Too high!";
        }
        else
        {
            infoText.text = "Too low!";
        }

        input.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
