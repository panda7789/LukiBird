using UnityEngine;
using System.Collections;

public class BgLooper : MonoBehaviour {

	int numBGPandels = 6;


	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Triggered : " + collider.name);

		float widthOfBGObject = ((BoxCollider2D)collider).size.x;

		Vector3 pos =  collider.transform.position;
		pos.x += widthOfBGObject * numBGPandels - widthOfBGObject / 2;
		collider.transform.position = pos;

	}
}