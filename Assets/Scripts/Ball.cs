using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	
	[SerializeField] private Transform playerBar;
	[SerializeField] private GameObject Arrow;
	[SerializeField] private float velocity = 15f;

	private Rigidbody2D rb;
	private bool isAttached = true;

	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		// gets the ball stuck to the player bar
		if(isAttached){
			transform.position = new Vector3 (playerBar.transform.position.x, transform.position.y, 0);
		}
		rb.velocity = rb.velocity.normalized * velocity;
	}

	void OnCollisionStay2D(Collision2D coll){
		
	}

	public void LaunchBall(float StartAngle, float speed = 10){
		isAttached = false;
		Quaternion rotation = Quaternion.AngleAxis(StartAngle, new Vector3(0, 0, 1));
		Vector3 newVel = rotation * Vector3.up * speed;
		rb.velocity = newVel;
		Arrow.SetActive (false);
	}

	public void DisplayArrow(float angle){
		if (!Arrow.activeSelf) {
			Arrow.SetActive (true);
		}
		Quaternion rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
		Arrow.transform.rotation = rotation;
	}
}
