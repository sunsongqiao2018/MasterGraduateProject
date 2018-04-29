using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McsTest : MonoBehaviour {
	Moving passbool;
	public int Counter = 0;

	void Update() {// fixed, works fine. gives the falled tag on agents who are falled.
		
		passbool = GetComponentInChildren<Moving> ();

		if (passbool.stop == true) {
			gameObject.tag = "falled";
		}
	}

	void OnTriggerEnter(Collider col){ 
		if (gameObject.GetComponent<BoxCollider> ().GetType () == typeof(BoxCollider) && col.tag != "falled") {
			Counter++;
		}
		if (gameObject.GetComponent<SphereCollider> ().GetType () == typeof(SphereCollider) && col.tag != "falled") {
			Counter += 10;
		}
	}

	void OnTriggerExit(Collider col){ 
		if (gameObject.GetComponent<BoxCollider> ().GetType () == typeof(BoxCollider) && col.tag != "falled") {
			Counter--;
		}
		if (gameObject.GetComponent<SphereCollider> ().GetType () == typeof(SphereCollider) && col.tag != "falled") {
			Counter -= 10;
		}
		//Debug.Log (gameObject.name + "MCSvalue: " + Counter);
	}
}
