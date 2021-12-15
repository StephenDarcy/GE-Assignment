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
        //get number of jumps player has 
        Player playerScript = player.GetComponent<Player>();
        jumpsLeft = playerScript.superJumpsRemaining;
        //display jumps left on screen
        jumpsLeftText.text = jumpsLeft.ToString();
    }
}
