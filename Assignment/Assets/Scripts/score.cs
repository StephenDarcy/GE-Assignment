using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public Transform player;
    public Text scoreValue;
    public Text highscoreText;
    public float distance;
    public float currentHighscore;
    public float previousDistance = 0f;

    // Update is called once per frame
    void Update()
    {
        distance = player.position.x - 57.5f;
        if (distance > previousDistance) {
            scoreValue.text = distance.ToString("0");
            previousDistance = distance;
            currentHighscore = distance;
        }

        float highScore = PlayerPrefs.GetFloat("highScore");
        highscoreText.text = highScore.ToString("0");

        if (currentHighscore > highScore) {
            PlayerPrefs.SetFloat("highScore", currentHighscore);
        }

    }
}
