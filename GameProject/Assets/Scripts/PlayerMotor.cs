using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private float speed = 5.0f;
	private Vector3 moveVector;
	private float verticalVelocity = 0.0f;
	private float gravity = 10.0f;

	private float animationDuration = 3.0f;
	private float startTime;

	private bool isDead = false;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
			return;
		
		if (Time.time - startTime < animationDuration) {
			controller.Move (Vector3.forward * speed * Time.deltaTime);
		return;
		}
		moveVector = Vector3.zero;

		if (controller.isGrounded) {
			verticalVelocity = -0.5f;
		} else {
			verticalVelocity -= gravity * Time.deltaTime;
		}

		moveVector.x = Input.GetAxisRaw ("Horizontal") * speed/2;
		moveVector.y = verticalVelocity;
		moveVector.z = speed;
		controller.Move (moveVector * Time.deltaTime);
	}

	public void SetSpeed(int newSpeed){
		speed = 5.0f + newSpeed;
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log (other.gameObject);
		if(other.tag == "Enemy") {
			Death ();
		}
	}
	private void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == "Enemy") {
			Death ();
		}
	}

	private void Death() {
		isDead = true;
		GetComponent<Score> ().OnDeath ();
	}
}
