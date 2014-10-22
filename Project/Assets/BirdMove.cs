using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {
	
	Vector3 velocity = Vector3.zero;
	
	float flapSpeed    = 110f;
	float forwardSpeed = 1f;
	
	bool didFlap = false;
	public bool dead = false;
	float deathCooldown;

	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator> ();
		
	}
	void Update(){
		if (dead) {
						deathCooldown -= Time.deltaTime; 
						if (deathCooldown <= 0) {
								if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
										Application.LoadLevel (Application.loadedLevel);

								} else if ((Input.touchCount == 1) && (Input.GetTouch (0).phase == TouchPhase.Began)) {
										Application.LoadLevel (Application.loadedLevel);
								}
						}
				}

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
			animator.SetTrigger("DoFlap");
			didFlap=true;
		}
		else if ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began)) {
						animator.SetTrigger("DoFlap");
						didFlap=true;
				}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (dead)
						return;

		rigidbody2D.AddForce (Vector2.right * forwardSpeed);
		if (didFlap) {
			Vector2 v = rigidbody2D.velocity;
			v.y = 0;
			rigidbody2D.velocity = v;
			rigidbody2D.AddForce (Vector2.up * flapSpeed);

			didFlap = false;

		}

		
	}
	void OnCollisionEnter2D(Collision2D collision){
		animator.SetTrigger("Death");
		dead = true;
		deathCooldown = 0.5f;
	}
	}


