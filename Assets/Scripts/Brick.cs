using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}

	void OnCollisionExit2D(Collision2D coll){
		Destroy(this.gameObject);
	}

}
