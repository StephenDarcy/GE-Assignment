using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public Transform player;
    public Text scoreValue;
    public float distance;
    public float previousDistance = 0f;

    // Update is called once per frame
    void Update()
    {
        distance = player.position.x - 57.5f;
        if (distance > previousDistance) {
            scoreValue.text = distance.ToString("0");
            previousDistance = distance;
        }
    }
}
