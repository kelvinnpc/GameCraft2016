using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour {
	public enum Type {PLAYER, SOUL, FUSION};
	public Text PersonKey;
	public Text SoulKey;
	public Type type;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (type.Equals (Type.PLAYER) && other.gameObject.tag == "Player") {
			Player player = other.GetComponent<Player> ();
			if (player.key > 0) {
				Destroy (this.gameObject);
				player.key--;
				PersonKey.text = "Key: " + player.key.ToString ();
			}
		} else if (type.Equals (Type.SOUL) && other.gameObject.tag == "Soul") {
			Soul soul = other.GetComponent<Soul> ();
			if (soul.key > 0) {
				Destroy (this.gameObject);
				soul.key--;
				SoulKey.text = "Key: " + soul.key.ToString ();
			}
		} else if (type.Equals (Type.FUSION)) {
			if (other.gameObject.tag == "Player") {
				Player player = other.GetComponent<Player> ();
				if (player.fusionKey > 0) {
					Destroy (this.gameObject);
					player.fusionKey--;
				}
			}
			else if (other.gameObject.tag == "Soul") {
				Soul soul = other.GetComponent<Soul> ();
				if (soul.fusionKey > 0) {
					Destroy (this.gameObject);
					soul.fusionKey--;
				}
			}
		}
	}
}
