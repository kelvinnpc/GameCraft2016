using UnityEngine;
using System.Collections;

public class Soul : MonoBehaviour {

	public float speed;
	public int key;
	public int fusionKey;
	public Animator soulAnimator;
	Rigidbody2D rgbody;
	[SerializeField]
	private Player playerScript;
	[SerializeField]
	private Transform checkWall;
	// Use this for initialization
	void Start () {
		rgbody = GetComponent<Rigidbody2D> ();
		key = 0;
		fusionKey = 0;
		soulAnimator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {

		Vector3 velocity = Vector3.zero;
		soulAnimator.SetBool ("Is Move", false);
		bool isHitWall = Physics2D.Linecast (transform.position, checkWall.transform.position, 1 << LayerMask.NameToLayer("Wall"));
		Debug.DrawLine (transform.position, checkWall.transform.position, Color.red);
		if (isHitWall) {
			playerScript.speed = 0;
		} else {
			playerScript.speed = 5;
		}

		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			velocity += Vector3.left * speed;
			transform.right = Vector3.right;
			soulAnimator.SetBool ("Is Move", true);
		}
		else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			velocity += Vector3.up * speed;
			transform.right = Vector3.up;
			soulAnimator.SetBool ("Is Move", true);
		}
		else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			velocity += Vector3.right * speed;
			transform.right = Vector3.left;
			soulAnimator.SetBool ("Is Move", true);
		}
		else if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			velocity += Vector3.down * speed;
			transform.right = Vector3.down;
			soulAnimator.SetBool ("Is Move", true);
		}
		rgbody.velocity = velocity;

	}
}
