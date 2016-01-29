using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody rbody;

    private float speed = 13.0f;

	void Start () {

        rbody = GetComponent<Rigidbody>();

	}
	
	void FixedUpdate () {

        HandleMovement();

	}

    private void HandleMovement() {

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(horizontalMovement, transform.position.y, verticalMovement);

        rbody.AddForce(movementVector * speed);

    }
}
