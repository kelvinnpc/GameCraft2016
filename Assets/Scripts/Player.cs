using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Text PersonKey;
	public Text PersonSpecialKey;
	public float speed;
	public bool isHitWall = false;
	public int key;
	public int fusionKey;
	public Animator playerAnimator;
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
		playerAnimator = GetComponent<Animator> ();
		PersonKey.text = "Key: " + key.ToString ();
		PersonSpecialKey.text = "Key: " + fusionKey.ToString ();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		
		Vector3 velocity = Vector3.zero;
		playerAnimator.SetBool ("Is Move", false);
		isHitWall = Physics2D.Linecast (transform.position, checkWall.transform.position, 1 << LayerMask.NameToLayer("Wall"));
		Debug.DrawLine (transform.position, checkWall.transform.position, Color.red);
		if (isHitWall) {
			soulScript.speed = 0;
		} else {
			soulScript.speed = 5;
		}
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			velocity += Vector3.left * speed;
			transform.right = Vector3.left;
			playerAnimator.SetBool ("Is Move", true);
		}
		else if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			velocity += Vector3.up * speed;
			transform.right = Vector3.up;
			playerAnimator.SetBool ("Is Move", true);
		}
		else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			velocity += Vector3.right * speed;
			transform.right = Vector3.right;
			playerAnimator.SetBool ("Is Move", true);
		}
		else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			velocity += Vector3.down * speed;
			transform.right = Vector2.down;
			playerAnimator.SetBool ("Is Move", true);
		}
		if (!soulScript.isHitWall)
			rgbody.velocity = velocity;
		else
			rgbody.velocity = Vector3.zero;

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Soul") {
			string level = Application.loadedLevelName;
			char lastChar = level [level.Length - 1];
			int newNum = lastChar - '0' + 1;
			level = "Level" + newNum.ToString ();
			Application.LoadLevel (level);
//			Destroy (other.gameObject);
//			Destroy (this.gameObject);
		}
	}
}
