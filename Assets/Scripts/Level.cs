using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	[SerializeField] private GameObject level;

	void Start () {
		
	}

	void Update () {
		if (level.transform.childCount == 0) {
			print ("ok");
		}
	}
}
