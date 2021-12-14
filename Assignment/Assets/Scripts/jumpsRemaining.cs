using UnityEngine;
using UnityEngine.UI;

public class jumpsRemaining : MonoBehaviour
{
    public Transform player;
    public Text jumpsLeftText;

    public int jumpsLeft;
    // Update is called once per frame
    void Update()
    {
        Player playerScript = player.GetComponent<Player>();
        jumpsLeft = playerScript.superJumpsRemaining;
        jumpsLeftText.text = jumpsLeft.ToString();
    }
}
