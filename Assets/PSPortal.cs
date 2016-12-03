using UnityEngine;
using System.Collections;

public class PSPortal : MonoBehaviour {
	[SerializeField]
	private Player playerScript;
	[SerializeField]
	private Soul soulScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Soul") {
			Vector3 tempPosition = playerScript.transform.position;
			playerScript.transform.position = soulScript.transform.position;
			soulScript.transform.position = tempPosition;
		}
	}
}
