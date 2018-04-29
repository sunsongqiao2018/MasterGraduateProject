using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {/*-------- this code is for animation and trigger parameters------------*/
	public Animator anim;
	private float velo;
	NaviTest passfloat;
	NaviTestF passfloatf;
	public bool stop;
	McsTest passcounter;
	void Start(){
		
		anim = GetComponent<Animator> ();
		passcounter = GetComponentInParent<McsTest> ();

	}

	void Update(){
		if (gameObject.GetComponentInParent<NaviTest> ()) {
			passfloat = GetComponentInParent<NaviTest> ();
			anim.SetFloat ("walk", passfloat.velo);
			} 
			else if(gameObject.GetComponentInParent<NaviTestF> ()) {
					passfloatf = GetComponentInParent<NaviTestF> ();
					anim.SetFloat ("walk", passfloatf.velo);
		}

		/*float velocitycounter = Mathf.Cos (passcounter.gameObject.GetComponent<Rigidbody> ().velocity.x);
																//+
			//Mathf.Sin (passcounter.gameObject.GetComponent<Rigidbody> ().velocity.z);
		if (velocitycounter != 0.0f) {
			Debug.Log (velocitycounter);
		}*/

		if (/*--add one more condition ---velocitycounter > 1.0f &&---*/transform.parent.tag == "walker" && passcounter.Counter > 80000) 				// conditions need to more elaborate.
		{	int fallIndicator = Random.Range(0,10);
			int i = 0;
			if(i >= fallIndicator){
			anim.SetBool ("fall", true);
			stop = true;
			}
			else{
				fallIndicator = Random.Range(0,10);
				i++;
				}
		}
		
				/*if (Mathf.Abs(Input.GetAxis ("Vertical")) >= Mathf.Abs(Input.GetAxis ("Horizontal"))){
				//	velo = Input.GetAxis ("Vertical");
				} else {												old moving animation code.
				//	velo = Input.GetAxis ("Horizontal");
				}*/
		  		//anim.SetFloat ("walk", passfloat.velo);
	}
}

