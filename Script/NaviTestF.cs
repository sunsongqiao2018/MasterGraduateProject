using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviTestF : MonoBehaviour {
	public Transform target;
	NavMeshAgent Anifmale;
	public float velo = 0.0f;
	Vector3 PosTransform;
	Moving passbool;
	// Use this for initialization
	void Start () {
		
		target = GameObject.Find ("Target1").transform;
		Anifmale = GetComponent<NavMeshAgent>();
		PosTransform = transform.position;
	}


	// Update is called once per frame
	void Update () {
		
		Anifmale.SetDestination (target.position);				//moving with corrsponding animations.
		Vector3 CurTransform = transform.position;
		Vector3 MovingDect = CurTransform - PosTransform;

		if (MovingDect.x != 0.0f || MovingDect.z != 0.0f /* != new Vector3 (0, 0, 0)*/) //indeed working.
		{ 
			//Debug.Log(MovingDect.x + "and" + MovingDect.z);
			velo = 0.3f;
		} else {
			velo = 0.0f;
		}
		PosTransform = CurTransform;

		Debug.DrawLine (CurTransform, target.position,Color.red,-1f);


		//********************8falling function***********freeze movement***also in female part.************
		passbool = GetComponentInChildren<Moving> ();
		if (passbool.stop == true) {
			Anifmale.Stop ();

		}
	}
}
