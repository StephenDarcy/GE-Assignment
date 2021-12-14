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
        Player playerScript = player.GetComponent<Player>();
        status = playerScript.jumpIsActivated;

        if (status) {
            toggle.text = "Active";
            toggle.color = Color.green;
        } else {
            toggle.text = "Disabled";
            toggle.color = Color.red;
        }
        
    }
}
