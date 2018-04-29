 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCrowd : Attachbody {
	public GameObject Agents;
	public int Agentnum = 10;
	public Gradient pcolor;
	public int CombineTypes;
	public Attachbody CubeCaller;
	public GameObject Maleb;

	// Use this for initialization
	void Start () {
		
		//CubeCaller.Health ();
		GameObject body = null;//new GameObject();			//pre-create a troso gameobject and assign it with different one.
		GameObject head = null;
		GameObject larm = null;
		GameObject rarm = null;
		GameObject lleg = null;
		GameObject rleg = null;


		//TODO give Gradient Color to all different agents.

		for(int i = 1; i<=Agentnum; i++){


			GameObject agent = new GameObject();
			int Modeltype = Random.Range(1,CombineTypes + 1);

			switch(Modeltype){							//for bodys
			case 1:
				body = Instantiate (Resources.Load ("Fmale/FBody", typeof(GameObject)))as GameObject;
				body.transform.Find ("FTorso_Fmale").GetComponent<MeshRenderer> ().material.color = pcolor.Evaluate (Random.Range (0f, 1f));

				CapsuleCollider capco = body.AddComponent<CapsuleCollider> ();
				capco.radius = 1f;
					break;
			case 2:
				body = Instantiate (Resources.Load ("Male/Mbody", typeof(GameObject)))as GameObject;
				break;
			case 3:
				body = Instantiate (Resources.Load ("MaleS/MbodyS", typeof(GameObject)))as GameObject;
				break;
			case 4:
				body = Instantiate (Resources.Load ("FmaleO/FBodyO", typeof(GameObject)))as GameObject;
				break;

			default:
				print ("your choosing selecetion is out of range.");
				break;
							}
			Modeltype = Random.Range (1, CombineTypes + 1);
			switch(Modeltype){						//for heads
			case 1:
				head = Instantiate (Resources.Load ("Fmale/FHead", typeof(GameObject)))as GameObject;
		
				break;
			case 2:
				head = Instantiate (Resources.Load ("Male/MHead", typeof(GameObject)))as GameObject;
		
				break;
			case 3:
				head = Instantiate (Resources.Load ("MaleS/MHeadS", typeof(GameObject)))as GameObject;

				break;
			case 4:
				head = Instantiate (Resources.Load ("FmaleO/FHeadO", typeof(GameObject)))as GameObject;

				break;
			default:
				break;
			}
			Modeltype = Random.Range (1, CombineTypes + 1);
			switch(Modeltype){				//for arms
			case 1:
				larm = Instantiate (Resources.Load ("Fmale/FLarm", typeof(GameObject)))as GameObject;
				rarm = Instantiate (Resources.Load ("Fmale/FRarm", typeof(GameObject)))as GameObject;
				break;
			case 2:
				larm = Instantiate (Resources.Load ("Male/MLarm", typeof(GameObject)))as GameObject;
				rarm = Instantiate (Resources.Load ("Male/MRarm", typeof(GameObject)))as GameObject;
				break;
			case 3:
				larm = Instantiate (Resources.Load ("MaleS/MLarmS", typeof(GameObject)))as GameObject;
				rarm = Instantiate (Resources.Load ("MaleS/MRarmS", typeof(GameObject)))as GameObject;
				break;
			case 4:
				larm = Instantiate (Resources.Load ("FmaleO/FLarmO", typeof(GameObject)))as GameObject;
				rarm = Instantiate (Resources.Load ("FmaleO/FRarmO", typeof(GameObject)))as GameObject;
				break;
			default:
				break;
			}
			Modeltype = Random.Range (1, CombineTypes + 1);
			switch(Modeltype){				//for legs
			case 1:
				lleg = Instantiate (Resources.Load ("Fmale/FLleg", typeof(GameObject)))as GameObject;
				rleg = Instantiate (Resources.Load ("Fmale/FRleg", typeof(GameObject)))as GameObject;
				break;
			case 2:
				lleg = Instantiate (Resources.Load ("Male/MLleg", typeof(GameObject)))as GameObject;
				rleg = Instantiate (Resources.Load ("Male/MRleg", typeof(GameObject)))as GameObject;
 				break;
			case 3:
				lleg = Instantiate (Resources.Load ("MaleS/MLlegS", typeof(GameObject)))as GameObject;
				rleg = Instantiate (Resources.Load ("MaleS/MRlegS", typeof(GameObject)))as GameObject;
				break;
			case 4:
				lleg = Instantiate (Resources.Load ("FmaleO/FLlegO", typeof(GameObject)))as GameObject;
				rleg = Instantiate (Resources.Load ("FmaleO/FRlegO", typeof(GameObject)))as GameObject;
				break;
			default:
				break;
			}

			float b = (Random.Range (1f, 30f));				//random parameters
			float c = (Random.Range (1f, 30f));
			float e = (Random.Range (1f, 30f));
				
			agent.transform.position = new Vector3 (c-b,0.8f,e-b);
			body.transform.position = agent.transform.position;
			head.transform.position = body.transform.position /*+ (Vector3.up) * 2*/;
			larm.transform.position =  body.transform.position;
			rarm.transform.position = body.transform.position;
			lleg.transform.position = body.transform.position;
			rleg.transform.position =   body.transform.position;

		/*head.transform.localScale = new Vector3(Random.Range(0.1f,0.3f),0.2f,Random.Range(0.1f,0.3f));
		troso.transform.localScale = new Vector3(Random.Range(0.3f,0.4f),Random.Range(0.3f,0.4f),Random.Range(0.1f,0.3f));
		larm.transform.localScale = new Vector3(Random.Range(0.1f,0.15f),Random.Range(0.3f,0.4f),Random.Range(0.1f,0.2f));
		rarm.transform.localScale = new Vector3(Random.Range(0.1f,0.15f),Random.Range(0.3f,0.4f),Random.Range(0.1f,0.2f));	 	
		lleg.transform.localScale = new Vector3(Random.Range(0.15f,0.2f),Random.Range(0.3f,0.4f),0.3f);
		rleg.transform.localScale = new Vector3(Random.Range(0.15f,0.2f),Random.Range(0.3f,0.4f),0.3f);*/
		
			head.transform.parent = agent.transform;				//transfer bodyparts to one agent.
			body.transform.parent = agent.transform;
			larm.transform.parent = agent.transform;
			rarm.transform.parent = agent.transform;
			lleg.transform.parent = agent.transform;
			rleg.transform.parent = agent.transform;

			agent.transform.localScale = new Vector3 (1f, 1f, 1f);
			agent.name = "agent" + i;
			agent.AddComponent<Rigidbody> ();
			agent.AddComponent<CapsuleCollider> ();
			agent.AddComponent<MeshRenderer> ();

			Maleb = Instantiate (Resources.Load ("Mb", typeof(GameObject)))as GameObject;
			Maleb.GetComponent<MeshRenderer> ().material.color = Color.red;
		}

		
	}
}
