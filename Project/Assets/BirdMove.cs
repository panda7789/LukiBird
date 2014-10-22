using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {
	
	Vector3 velocity = Vector3.zero;
	
	float flapSpeed    = 300f;
	float forwardSpeed = 1f;
	
	bool didFlap = false;
	bool dead = false;

	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator> ();
		
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
			animator.SetTrigger("DoFlap");
			didFlap=true;
		}
		else if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began)) {
			didFlap=true;
				}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (dead)
						return;

		rigidbody2D.AddForce (Vector2.right * forwardSpeed);
		if (didFlap) {
			rigidbody2D.AddForce (Vector2.up * flapSpeed);

			didFlap = false;

		}

		
	}
	void OnCollisionEnter2D(Collision2D collision){
		animator.SetTrigger("Death");
		dead = true;
	}
	}


