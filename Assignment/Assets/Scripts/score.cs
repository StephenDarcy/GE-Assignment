using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public Transform player;
    public Text scoreValue;

    // Update is called once per frame
    void Update()
    {
        scoreValue.text = (player.position.x -57.5).ToString("0");
    }
}
