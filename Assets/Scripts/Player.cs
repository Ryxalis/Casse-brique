using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField] private float maxBarSpeed = 20;
	[SerializeField] private float barSmoothness = 10;
	[SerializeField] private List<Ball> balls;
	[SerializeField] private float ballSpeed = 15;
	private Rigidbody2D rb;
	private float startAngle = 0;
	private float angleLimit = 80;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		if (Input.GetKey (KeyCode.A)) {
			float newVelX = Mathf.MoveTowards (rb.velocity.x, -maxBarSpeed, barSmoothness * maxBarSpeed * Time.deltaTime);
			rb.velocity = new Vector2 (newVelX, 0);
		} else if (Input.GetKey (KeyCode.D)) {
			float newVelX = Mathf.MoveTowards (rb.velocity.x, maxBarSpeed, barSmoothness * maxBarSpeed * Time.deltaTime);
			rb.velocity = new Vector2 (newVelX, 0);
		} else {
			float newVelX = Mathf.MoveTowards (rb.velocity.x, 0, barSmoothness * maxBarSpeed * Time.deltaTime);
			rb.velocity = new Vector2 (newVelX, 0);
		}
	}

	void Update(){
		if (balls.Count > 0 && Input.GetKeyDown (KeyCode.Space)) {
			foreach (Ball ball in balls) {
				ball.LaunchBall (startAngle, ballSpeed);
			}
			balls = new List<Ball>(0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			startAngle = Mathf.Max (-angleLimit, --startAngle);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			startAngle = Mathf.Min (angleLimit, ++startAngle);
		}
		if (balls.Count > 0) {
			foreach (Ball ball in balls) {
				ball.DisplayArrow (startAngle);
			}
		}
	}
}
