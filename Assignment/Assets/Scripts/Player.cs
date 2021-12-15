using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip collect;
    public AudioClip death;
    public AudioSource audioSource;
    private bool jumpKeyWasPressed;
    public bool jumpIsActivated = false;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] public int superJumpsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if player is below 20 application reloads
        if (rigidbodyComponent.position.y < 20) {
            Application.LoadLevel(Application.loadedLevel);
        }

        // playing death noise as player falls
        if (rigidbodyComponent.position.y < 25) {
            audioSource.PlayOneShot(death,.7f);
        }

        //getting player space press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        // toggling super jump with q
        if (Input.GetKeyDown(KeyCode.Q)) {
            jumpIsActivated = !jumpIsActivated;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    // Fixed update is called once every physics update
    private void FixedUpdate()
    {
        //moving player
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);

        //if player is touching ground
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 1)
        {
            return;
        }

        //if jumping
        if (jumpKeyWasPressed)
        {
            //play jump noise
            audioSource.PlayOneShot(jump, 0.7F);
            float jumpPower = 5;
            //if super jumps available and active
            if (superJumpsRemaining > 0 && jumpIsActivated)
            {
                //jump twice as high
                jumpPower *= 2;
                superJumpsRemaining--;
            }
            //jumping motion
            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            //stop jump
            jumpKeyWasPressed = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        //if player collects gem
        if (other.gameObject.layer == 9)
        {
            //play audio
            audioSource.PlayOneShot(collect, 0.7F);
            //destroy gem
            Destroy(other.gameObject);
            //increment jumps
            superJumpsRemaining++;
        }
    }


}
