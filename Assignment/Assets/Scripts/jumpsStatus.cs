using UnityEngine;
using UnityEngine.UI;

public class jumpsStatus : MonoBehaviour
{

    public Transform player;
    public Text toggle;

    public bool status;
    // Update is called once per frame
    void Update()
    {
        //getting the players jump status
        Player playerScript = player.GetComponent<Player>();
        status = playerScript.jumpIsActivated;

        //if player has jump set to true
        if (status) {
            //set text to active and set colour
            toggle.text = "Active";
            toggle.color = Color.green;
        } else {
            //else set text to disabled and change colour to red
            toggle.text = "Disabled";
            toggle.color = Color.red;
        }
        
    }
}
