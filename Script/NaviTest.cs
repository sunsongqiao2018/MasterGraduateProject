using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.AI;

public class NaviTest : MonoBehaviour {
	public Transform target;
	NavMeshAgent AniAgent;
	public float velo = 0.0f;
	Vector3 PosTransform;
	Moving passbool;


	//private Regex gxb;
	//private MatchCollection matchesb;

	// Use this for initialization
	void Start () {


		PosTransform = transform.position;
		int targetFinding = Random.Range(0,4);
		switch(targetFinding){
		case 0:
			target = GameObject.Find ("Target1").transform;
			AniAgent = GetComponent<NavMeshAgent> ();
			break;
		case 1:
			target = GameObject.Find ("Target2").transform;
			AniAgent = GetComponent<NavMeshAgent> ();
			break;
		case 2:
			target = GameObject.Find ("Target3").transform;
			AniAgent = GetComponent<NavMeshAgent> ();
			break;
		case 3:
			target = GameObject.Find ("Target4").transform;
			AniAgent = GetComponent<NavMeshAgent> ();
			break;
			default:
			break;
		}
		AniAgent.SetDestination (target.position);

	}
	
	// Update is called once per frame
	void Update () {
		/*if (AniMale.velocity != new Vector3 (0, 0, 0)) {
			//Debug.Log (new Vector2(AniMale.velocity.x , AniMale.velocity.z));
		}*/

		Vector3 CurTransform = transform.position;
		Vector3 MovingDect = CurTransform - PosTransform;
		if (MovingDect != new Vector3 (0, 0, 0)) {
			velo = 0.3f;

		} else {
			velo = 0.0f;
		}
		PosTransform = CurTransform;

		//Debug.DrawLine (CurTransform, target.position,Color.blue,10.0f);

		//********************8falling function***********freeze movement***also in female part.************

		passbool = GetComponentInChildren<Moving> ();
		if (passbool.stop == true) {
			AniAgent.Stop ();


			//gameObject.GetComponent<NavMeshAgent> ().enabled = true;
		}
	}

	/*void OnCollisionEnter (Collision Colis){
		//---this function calls when meeting buildings, needs fix.
		string patternofb = @"[B]\d";
		gxb = new Regex (patternofb);
		matchesb = gxb.Matches (Colis.gameObject.name);
		if (matchesb.Count > 0) {
			AniMale.ResetPath ();
			AniMale.SetDestination (target.position);
		}
	}*/
}
