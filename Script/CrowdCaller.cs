using System.Collections;
using System.Collections.Generic;
using UnityEngine;
			// not working yet.
public class CrowdCaller : MonoBehaviour {
	private CrowdWorld Creater;
	// Use this for initialization
	void Start () {
		Creater.Agentnum = 50;
		Creater.GenderRatio = 0.5f;

	}
	
	// Update is called once per frame
	void Update(){
		//for(int i = 1; i < 3; i++){
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("CALLED");
			Creater.CharacterCreate ();
		}
		//}
		//float v = VerticalSpeed * Input.GetAxis ("Vertical");
		//anim.SetFloat ("walk", v);
	}
}
