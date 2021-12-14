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
        float highScore = PlayerPrefs.GetFloat("highScore");
        highscoreText.text = highScore.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.position.x - 57.5f;
        if (distance > previousDistance) {
            scoreValue.text = distance.ToString("0");
            previousDistance = distance;
        }

        float highScore = PlayerPrefs.GetFloat("highScore");

        if (distance > highScore) {
            PlayerPrefs.SetFloat("highScore", distance);
            PlayerPrefs.Save();
            highscoreText.text = highScore.ToString("0");
        }

    }
}
