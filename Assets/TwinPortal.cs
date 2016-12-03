using UnityEngine;
using System.Collections;

public class TwinPortal : MonoBehaviour {
	public bool isActivate;
	[SerializeField]
	private TwinPortal endPoint;
	// Use this for initialization
	void Start () {
		isActivate = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!isActivate && (other.gameObject.tag == "Player" || other.gameObject.tag == "Soul")) {
			other.gameObject.transform.position = endPoint.transform.position;
		}
		endPoint.isActivate = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Soul") {
			isActivate = false;
		}
	}
}
