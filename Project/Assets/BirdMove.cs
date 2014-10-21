using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {
	
	Vector3 velocity = Vector3.zero;
	
	float flapSpeed    = 300f;
	float forwardSpeed = 1f;
	
	bool didFlap = false;
	// Use this for initialization
	void Start () {
		
		
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
			didFlap=true;
		}
		else if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began)) {
			didFlap=true;
				}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.AddForce (Vector2.right * forwardSpeed);
		if (didFlap) {
			rigidbody2D.AddForce (Vector2.up * flapSpeed);

			didFlap = false;

		}

		
	}
	
	}


