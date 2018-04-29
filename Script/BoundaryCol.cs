using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class BoundaryCol : MonoBehaviour {

	private Regex gx;
	private MatchCollection matches;
	private Regex gxw;
	private MatchCollection matchesw;
	//public float pushforce = 5.0f;
	public GameObject agents;
	public CrowdWorld caller;
	private Vector3 targetAngles;

	void Start(){
		agents = GameObject.Find("Agents");
		caller = agents.GetComponent<CrowdWorld> ();
	}

	/*-----------------defunctioning the boundary setting-----09 06--------*/
	/*void OntriggerEnter(Collider col){
		targetAngles = col.gameObject.transform.eulerAngles + 180f * Vector3.up;

		col.gameObject.transform.Rotate (targetAngles);
		Debug.Log (col.gameObject.name);
	}*/

 	void OnTriggerStay(Collider col)
	{	

		string patternofman = @"[M]\w+\d";
		gx = new Regex (patternofman);
		matches = gx.Matches (col.gameObject.name);

		string patternofw = @"[W]\w+\d";
		gxw = new Regex (patternofw);
		matchesw = gxw.Matches (col.gameObject.name);


			if (matches.Count > 0) {
		
				if (col.gameObject.tag == "Untagged") {
					foreach (Match m in matches) {
					//DO something on men.

					//	Debug.Log ("1");
						int Space = caller.Space;
						float Density = caller.Density;
						float b = (Random.Range (1f, Space / Density));				//random parameters
						float c = (Random.Range (1f, Space / Density));
						float e = (Random.Range (1f, Space / Density)); 

						col.gameObject.transform.position = new Vector3 (c - b, 0.8f, e - c); 

					//Debug.Log (col.gameObject.name);
					//col.gameObject.transform.Translate (0, 0, Time.deltaTime);
				}
			}
		} 
			else if (matchesw.Count > 0) {
		
				if (col.gameObject.tag == "Untagged"){
			
					foreach (Match m in matchesw) {
						int Space = caller.Space;
						float Density = caller.Density;
						float b = (Random.Range (1f, Space/Density));				//random parameters
						float c = (Random.Range (1f, Space/Density));
						float e = (Random.Range (1f, Space/Density)); 
						col.gameObject.transform.position = new Vector3 (c-b,0.8f,e-c); 

				//Debug.Log (col.gameObject.name);

				//col.gameObject.transform.Translate (0, 0, Time.deltaTime);
				//col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * pushforce,ForceMode.Acceleration);
				//Do something on women. not only destroy them.
				//Debug.Log (m.Value);
				}
			}
		}
	}
}
