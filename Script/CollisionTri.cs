using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


//---------------for building colisions--------------

public class CollisionTri : MonoBehaviour {
	private Regex gx;
	private MatchCollection matches;
	private Regex gxw;
	private MatchCollection matchesw;
	private Regex gxb;
	private MatchCollection matchesb;
	private GameObject agents;
	private CrowdWorld caller;

	//public float pushforce = 5.0f;

	void Start (){
		agents = GameObject.Find("Agents");
		caller = agents.GetComponent<CrowdWorld> ();
	}

	void OnTriggerStay(Collider col)
	{
		
		string patternofb = @"[B]\d";
		gxb = new Regex (patternofb);
		matchesb = gxb.Matches (col.gameObject.name);


		if (matchesb.Count > 0 /*col.gameObject.name == "Building(Clone)"*/) {
			
			Destroy (col.gameObject);
		}
			
	}
	void OnCollisionStay (Collision Colis){
		//Do some on collision with. 
		string patternofman = @"[M]\w+\d";
		gx = new Regex (patternofman);
		matches = gx.Matches (Colis.gameObject.name);

		string patternofw = @"[W]\w+\d";
		gxw = new Regex (patternofw);
		matchesw = gxw.Matches (Colis.gameObject.name);

		if (matches.Count > 0) {
			
			if (Colis.gameObject.tag == "Untagged") {
				foreach (Match m in matches) {
					//DO something on men.

					//	Debug.Log ("1");
					int Space = caller.Space;
					float Density = caller.Density;
					float b = (Random.Range (1f, Space / Density));				//random parameters
					float c = (Random.Range (1f, Space / Density));
					float e = (Random.Range (1f, Space / Density)); 
					Colis.gameObject.transform.position = new Vector3 (c - b, 0.8f, e - c); 
					//Debug.Log (col.gameObject.transform.position);
					//	CharacterCreate ();
					//		Callfun ();
					//col.gameObject.transform.Translate (0, 0, Time.deltaTime);
				}
			}
			} else if (matchesw.Count > 0) {

			if (Colis.gameObject.tag == "Untagged") {
				
				foreach (Match m in matchesw) {
					int Space = caller.Space;
					float Density = caller.Density;
					float b = (Random.Range (1f, Space / Density));				//random parameters
					float c = (Random.Range (1f, Space / Density));
					float e = (Random.Range (1f, Space / Density)); 
					Colis.gameObject.transform.position = new Vector3 (c - b, 0.8f, e - c); 

					//  Debug.Log (col.gameObject.transform.position);

					//col.gameObject.transform.Translate (0, 0, Time.deltaTime);
					//col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * pushforce,ForceMode.Acceleration);
					//Do something on women. not only destroy them.
					//Debug.Log (m.Value);
					  
				}
			}
		//if (Colis.gameObject.name != "Terrain") {
		//	Destroy (Colis.gameObject);
		//}
		//Debug.Log (Colis.gameObject.name);
		}
	}
}
