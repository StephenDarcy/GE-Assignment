using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public Transform player;
    public Text scoreValue;
    public Text highscoreText;
    public float distance;
    public float previousDistance = 0f;


    void Start()
    {
        //getting and displaying highscore on game start
        float highScore = PlayerPrefs.GetFloat("highScore");
        highscoreText.text = highScore.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        //score if player distance from start minus offset of terrain
        distance = player.position.x - 57.5f;

        //so score can only go up
        if (distance > previousDistance) {
            scoreValue.text = distance.ToString("0");
            previousDistance = distance;
        }

        //getting highscore
        float highScore = PlayerPrefs.GetFloat("highScore");

        //if current score is greater than highscore
        if (distance > highScore) {
            //save highscore and set text
            PlayerPrefs.SetFloat("highScore", distance);
            PlayerPrefs.Save();
            highscoreText.text = highScore.ToString("0");
        }

    }
}
