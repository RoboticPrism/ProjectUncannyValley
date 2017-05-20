using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour {

    public float speed = 40f;
    

    bool playerControl = true;
    Rigidbody rigidBody;
    Animator animator;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}

    void FixedUpdate ()
    {
        if (playerControl)
        {
            CharacterControlTick();
        }
    }

    void CharacterControlTick()
    {
        // Add player movement
        rigidBody.AddForce(new Vector3(Input.GetAxis("Horizontal") * speed, 0f, Input.GetAxis("Vertical") * speed));
        // Set a max speed
        rigidBody.velocity = new Vector3(
            LimitVelocity(rigidBody.velocity.x),
            rigidBody.velocity.y,
            LimitVelocity(rigidBody.velocity.z));
    }

    private float LimitVelocity(float startValue)
    {
        if (startValue > 0)
        {
            return Mathf.Min(startValue, speed);
        } else
        {
            return Mathf.Max(startValue, -speed);
        }
    }
}
