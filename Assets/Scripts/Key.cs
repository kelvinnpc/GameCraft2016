using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	public enum Type {PLAYER, SOUL};
	public Type type1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (type1.Equals (Type.PLAYER) && other.gameObject.tag == "Player") {
			other.GetComponent<Player> ().key++;
			Destroy (this.gameObject);
		} else if (type1.Equals (Type.SOUL) && other.gameObject.tag == "Soul") {
			other.GetComponent<Soul> ().key++;
			Destroy (this.gameObject);
		}
	}
}
