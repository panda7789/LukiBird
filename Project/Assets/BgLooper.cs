using UnityEngine;
using System.Collections;

public class BgLooper : MonoBehaviour {

	int numBGPandels = 6;

	float pipeMax = 2.359633f;
	float pipeMin = 1.60955f;

	void Start(){
				GameObject[] pipes = GameObject.FindGameObjectsWithTag ("pipe");
				foreach (GameObject pipe in pipes) {
					Vector3 pos =  pipe.transform.position;

					pos.y = Random.Range(pipeMin,pipeMax);
			pipe.transform.position = pos;
				}
		}


	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Triggered : " + collider.name);

		float widthOfBGObject = ((BoxCollider2D)collider).size.x;

		Vector3 pos =  collider.transform.position;
		pos.x += widthOfBGObject * numBGPandels;

		if (collider.tag == "pipe") {
			pos.y = Random.Range(pipeMin,pipeMax);

		}

		collider.transform.position = pos;


	}
}