using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public int key;
	public int fusionKey;
	Rigidbody2D rgbody;
	[SerializeField]
	private Soul soulScript;
	[SerializeField]
	private Transform checkWall;
	// Use this for initialization
	void Start () {
		rgbody = GetComponent<Rigidbody2D> ();
		key = 0;
		fusionKey = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		
		Vector3 velocity = Vector3.zero;
		bool isHitWall = Physics2D.Linecast (transform.position, checkWall.transform.position, 1 << LayerMask.NameToLayer("Wall"));
		Debug.DrawLine (transform.position, checkWall.transform.position, Color.red);
		if (isHitWall) {
			soulScript.speed = 0;
		} else {
			soulScript.speed = 5;
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			velocity += Vector3.left * speed;
			transform.right = Vector3.left;
		}
		else if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			velocity += Vector3.up * speed;
			transform.right = Vector3.up;
		}
		else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			velocity += Vector3.right * speed;
			transform.right = Vector3.right;
		}
		else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			velocity += Vector3.down * speed;
			transform.right = Vector2.down;
		}
		rgbody.velocity = velocity;

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Soul") {
			Destroy (other.gameObject);
			Destroy (this.gameObject);
		}
	}
}
