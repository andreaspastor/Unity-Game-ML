using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraMotor : MonoBehaviour {

	private Transform lookAt;
	private Vector3 startOffSet;
	private Vector3 moveVector;
	private float transition = 0.0f;
	private float animationDuration = 1.0f;
	private Vector3 animationOffset = new Vector3 (0, 5, 5);
	// Use this for initialization
	void Start () {
		lookAt = GameObject.FindGameObjectWithTag ("Player").transform;
		startOffSet = transform.position - lookAt.position;
	}
	
	// Update is called once per frame
	void Update () {
		moveVector = lookAt.position + startOffSet;

		moveVector.x = 0;
		moveVector.y = Mathf.Clamp (moveVector.y, 3, 5);

		if(transition > animationDuration) {
			transform.position = moveVector;
		} else {
			transform.position = Vector3.Lerp (moveVector + animationOffset, moveVector, transition);
			transition += Time.deltaTime / animationDuration;
			transform.LookAt (lookAt.position + Vector3.up);
		}	
	}
}
