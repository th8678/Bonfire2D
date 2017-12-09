using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {

	SpawnGround sg;
	public bool proportion;

	void Start () {
		sg = GameObject.Find ("0").GetComponent<SpawnGround> ();
	}
	
	void Update () {
		if (proportion && sg.selected && GetComponent<Collider2D> ()!= null) {
			GetComponent<Collider2D> ().enabled = true;
		} else if (!proportion && !sg.selected && GetComponent<Collider2D> ()!= null) {
			GetComponent<Collider2D> ().enabled = true;
		} else if(GetComponent<Collider2D> ()!= null) {
			GetComponent<Collider2D> ().enabled = false;
		}
	
	}
}
