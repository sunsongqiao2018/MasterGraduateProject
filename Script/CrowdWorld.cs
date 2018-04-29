using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrowdWorld : MonoBehaviour{
	
	public int Agentnum;
	public float GenderRatio;
	public float Density = 1f;
	public int Space;
	public Gradient RanColor;
	public Gradient RanClothC;
	public Gradient RanHairC;
	public RuntimeAnimatorController RunTimeCon;

	//public GameObject Magent;
	//private Animator anim;
	private Vector3[] Positions;
	public GameObject[] Males;
	public GameObject[] Fmales;
	public string NumParse = "0";
	public string NumParseT ="0";

	//movement variables

	//private float smooth = 0.2F;
	//private float tiltAngle = 3f;

	//private int checker = 0;
	//Building variables

	public int BuildNum;

	public void Callfun(){ 					//just a test for call func from other class;
		int b = 2;
		Debug.Log (b);
	}

	public void CharacterCreate () { 
 
		GameObject body = null;		//pre-create a troso gameobject and assign it with different one.
		GameObject head = null;
		GameObject larm = null;
		GameObject rarm = null;
		GameObject lleg = null;
		GameObject rleg = null;
		GameObject cloth = null;
		GameObject dress = null;
		GameObject hair = null;

		Color skincolor = new Color();
		Positions = new Vector3[Agentnum + 1];
		int a = Mathf.FloorToInt(Agentnum * GenderRatio);

		for (int i = 1; i <= a; i++) {
			int hairstyle = Random.Range (0, 2);
			//Debug.Log (hairstyle);
			GameObject Fagent = new GameObject();				//load female character
			body = Instantiate (Resources.Load ("Female/Ftroso", typeof(GameObject)))as GameObject;
			body.transform.localScale = new Vector3 (Random.Range(1f,1.5f), 1f,Random.Range(1f,1.5f));

			head = Instantiate (Resources.Load ("Female/Fhead", typeof(GameObject)))as GameObject;
			head.transform.localScale = new Vector3 (Random.Range(1f,1.5f), 1f,Random.Range(1f,1.5f));

			larm = Instantiate (Resources.Load ("Female/Flarm", typeof(GameObject)))as GameObject;
			larm.transform.localScale = new Vector3 (Random.Range(1f,1.5f), 1f,Random.Range(1f,1.5f));
			rarm = Instantiate (Resources.Load ("Female/Frarm", typeof(GameObject)))as GameObject;
			rarm.transform.localScale = larm.transform.localScale;

			lleg = Instantiate (Resources.Load ("Female/Flleg", typeof(GameObject)))as GameObject;
			lleg.transform.localScale = new Vector3 (Random.Range(1f,1.5f), 1f,Random.Range(1f,1.5f));
			rleg = Instantiate (Resources.Load ("Female/Frleg", typeof(GameObject)))as GameObject;
			rleg.transform.localScale = lleg.transform.localScale;

			cloth = Instantiate (Resources.Load ("Female/Fcloth", typeof(GameObject)))as GameObject;
			cloth.transform.localScale = body.transform.localScale;
			dress = Instantiate (Resources.Load ("Female/Fskirt", typeof(GameObject)))as GameObject;
			dress.transform.localScale = lleg.transform.localScale;
			switch(hairstyle)
			{
			case 0:
				hair = Instantiate (Resources.Load ("Female/Fhair1", typeof(GameObject)))as GameObject;
				hair.transform.localScale = head.transform.localScale;
				break;
			case 1:
				hair = Instantiate (Resources.Load ("Female/Fhair2", typeof(GameObject)))as GameObject;
				hair.transform.localScale = head.transform.localScale;
				break;
			default:
				break;
			}
			
			skincolor = RanColor.Evaluate (Random.Range (0f, 1f)); 				//save color sets.

			head.transform.Find ("Female").GetComponentInChildren<SkinnedMeshRenderer> ().material.color = skincolor;	//chara-colors.
			larm.transform.Find ("Female").GetComponentInChildren<SkinnedMeshRenderer> ().material.color = skincolor;
			rarm.transform.Find ("Female").GetComponentInChildren<SkinnedMeshRenderer> ().material.color = skincolor;
			body.transform.Find("Female").GetComponentInChildren<SkinnedMeshRenderer>().material.color = skincolor;
			lleg.transform.Find ("Female").GetComponentInChildren<SkinnedMeshRenderer> ().material.color = skincolor;
			rleg.transform.Find ("Female").GetComponentInChildren<SkinnedMeshRenderer> ().material.color = skincolor;

			cloth.transform.Find("Female").GetComponentInChildren<SkinnedMeshRenderer>().material.color = RanClothC.Evaluate (Random.Range (0f, 1f));
			dress.transform.Find("Female").GetComponentInChildren<SkinnedMeshRenderer>().material.color = RanClothC.Evaluate (Random.Range (0f, 1f));

			hair.transform.Find("Female").GetComponentInChildren<SkinnedMeshRenderer>().material.color = RanHairC.Evaluate (Random.Range (0f, 1f));

			float b = (Random.Range (1f, Space/Density));				//random parameters
			float c = (Random.Range (1f, Space/Density));
			float e = (Random.Range (1f, Space/Density));

			Fagent.transform.position = new Vector3 (c-b,0.3f,e-c);

			body.transform.position = Fagent.transform.position;
			head.transform.position = body.transform.position;
			hair.transform.position = body.transform.position;
			larm.transform.position =  body.transform.position;
			rarm.transform.position = body.transform.position;
			lleg.transform.position = body.transform.position;
			rleg.transform.position =   body.transform.position;
			cloth.transform.position =   body.transform.position;
			dress.transform.position =   body.transform.position;

			Positions [i] = Fagent.transform.position;
												//position detection on one Array,and delete overlapping position.
			/*for (int j = 1; j < i; j++) {					not necessary.
					// not working yet.
				if(i != j){
				if (Positions [i] == Positions [j]) {	
					//Debug.Log (Positions[j]);
						Fagent.transform.position = new Vector3 (c-e, 0.8f, b-c);
						i--;
					}
				}
			}*/

			head.transform.parent = Fagent.transform;				//transfer bodyparts to one agent.
			body.transform.parent = Fagent.transform;
			larm.transform.parent = Fagent.transform;
			rarm.transform.parent = Fagent.transform;
			lleg.transform.parent = Fagent.transform;
			rleg.transform.parent = Fagent.transform;
			cloth.transform.parent = Fagent.transform;
			dress.transform.parent = Fagent.transform;
			hair.transform.parent = Fagent.transform;

			larm.AddComponent<Moving> ();				//call animator;
			larm.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			rarm.AddComponent<Moving> ();				//call animator;
			rarm.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			head.AddComponent<Moving> ();				//call animator;
			head.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			body.AddComponent<Moving> ();				//call animator;
			body.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			lleg.AddComponent<Moving> ();				//call animator;
			lleg.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			rleg.AddComponent<Moving> ();				//call animator;
			rleg.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			cloth.AddComponent<Moving> ();				//call animator;
			cloth.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			dress.AddComponent<Moving> ();				//call animator;
			dress.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			hair.AddComponent<Moving> ();				//call animator;
			hair.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;

			Fagent.transform.localScale = new Vector3 (40f, 40f, 40f);
			Fagent.name = "Woman" + i;
			Fagent.AddComponent<Rigidbody> ();
			Fagent.AddComponent<CapsuleCollider> ();
			Fagent.GetComponent<CapsuleCollider> ().center = new Vector3 (0f, 0.023f, 0f);
			Fagent.GetComponent<CapsuleCollider> ().radius = 0.008f;
			Fagent.GetComponent<CapsuleCollider> ().height = 0.05f;
			//————————————————————————Multi-layer Collision System————————————————————————————————————————————
			///*
			Fagent.AddComponent<SphereCollider> ();
			Fagent.GetComponent<SphereCollider> ().isTrigger = true;
			Fagent.GetComponent<SphereCollider> ().center = new Vector3 (0f, 0.023f, 0f);
			Fagent.GetComponent<SphereCollider> ().radius = 0.1f;
			
			Fagent.AddComponent<BoxCollider> ();	
			Fagent.GetComponent<BoxCollider> ().isTrigger = true;
			Fagent.GetComponent<BoxCollider> ().center = new Vector3 (0f, 0.023f, 0f);
			Fagent.GetComponent<BoxCollider> ().size = new Vector3 (0.5f,0.3f, 0.5f );
			//*/
			Fagent.AddComponent<McsTest> ();

			Fmales [i-1] = Fagent;

			Fagent.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		}

		for (int i = 1; i <= Agentnum - a; i++) {		//male Agent generator;
			/*****************************new-Code************************/
			int hairstyle = Random.Range (0, 2);
			GameObject Magent = new GameObject();				//load female character
			body = Instantiate (Resources.Load ("Male/Mtroso", typeof(GameObject)))as GameObject;
			body.transform.localScale = new Vector3 (Random.Range(1f,1.5f), 1f,Random.Range(1f,1.5f));

			head = Instantiate (Resources.Load ("Male/Mhead", typeof(GameObject)))as GameObject;
			head.transform.localScale = new Vector3 (Random.Range(1f,1.5f), 1f,Random.Range(1f,1.5f));

			larm = Instantiate (Resources.Load ("Male/Mlarm", typeof(GameObject)))as GameObject;
			larm.transform.localScale = new Vector3 (Random.Range(1f,1.5f), 1f,Random.Range(1f,1.5f));
			rarm = Instantiate (Resources.Load ("Male/Mrarm", typeof(GameObject)))as GameObject;
			rarm.transform.localScale = larm.transform.localScale;

			lleg = Instantiate (Resources.Load ("Male/Mlleg", typeof(GameObject)))as GameObject;
			lleg.transform.localScale = new Vector3 (Random.Range(1f,1.5f), 1f,Random.Range(1f,1.5f));
			rleg = Instantiate (Resources.Load ("Male/Mrleg", typeof(GameObject)))as GameObject;
			rleg.transform.localScale = lleg.transform.localScale;

			cloth = Instantiate (Resources.Load ("Male/Mshirt", typeof(GameObject)))as GameObject;
			cloth.transform.localScale = body.transform.localScale;
			dress = Instantiate (Resources.Load ("Male/Mpant", typeof(GameObject)))as GameObject;
			dress.transform.localScale = lleg.transform.localScale;
			switch(hairstyle)
			{
			case 0:
				hair = Instantiate (Resources.Load ("Male/Mhair1", typeof(GameObject)))as GameObject;
				hair.transform.localScale = head.transform.localScale;
				break;
			case 1:
				hair = Instantiate (Resources.Load ("Male/Mhair2", typeof(GameObject)))as GameObject;
				hair.transform.localScale = head.transform.localScale;
				break;
			default:
				break;
			}

			skincolor = RanColor.Evaluate (Random.Range (0f, 1f)); 				//save color sets.

			head.transform.Find ("MaleNTpye").GetComponentInChildren<SkinnedMeshRenderer> ().material.color = skincolor;	//chara-colors.
			larm.transform.Find ("MaleNTpye").GetComponentInChildren<SkinnedMeshRenderer> ().material.color = skincolor;
			rarm.transform.Find ("MaleNTpye").GetComponentInChildren<SkinnedMeshRenderer> ().material.color = skincolor;
			body.transform.Find ("MaleNTpye").GetComponentInChildren<SkinnedMeshRenderer>().material.color = skincolor;
			lleg.transform.Find ("MaleNTpye").GetComponentInChildren<SkinnedMeshRenderer> ().material.color = skincolor;
			rleg.transform.Find ("MaleNTpye").GetComponentInChildren<SkinnedMeshRenderer> ().material.color = skincolor;

			cloth.transform.Find("MaleNTpye").GetComponentInChildren<SkinnedMeshRenderer>().material.color = RanClothC.Evaluate (Random.Range (0f, 1f));
			dress.transform.Find("MaleNTpye").GetComponentInChildren<SkinnedMeshRenderer>().material.color = RanClothC.Evaluate (Random.Range (0f, 1f));

			hair.transform.Find("MaleNTpye").GetComponentInChildren<SkinnedMeshRenderer>().material.color = RanHairC.Evaluate (Random.Range (0f, 1f));

			/*****************************old-Code************************/

			/*GameObject Magent = Instantiate (Resources.Load ("AniMale", typeof(GameObject)))as GameObject;

			Magent.transform.Find ("MheadS1").GetComponent<SkinnedMeshRenderer> ().material.color = RanColor.Evaluate (Random.Range (0f, 1f));
			*/

			float b = (Random.Range (1f, Space/Density));				//random parameters
			float c = (Random.Range (1f, Space/Density));
			float e = (Random.Range (1f, Space/Density));

			Magent.transform.position = new Vector3 (c - b, 0.3f, e - b);

			body.transform.position = Magent.transform.position;
			head.transform.position = body.transform.position;
			hair.transform.position = body.transform.position;
			larm.transform.position =  body.transform.position;
			rarm.transform.position = body.transform.position;
			lleg.transform.position = body.transform.position;
			rleg.transform.position =   body.transform.position;
			cloth.transform.position =   body.transform.position;
			dress.transform.position =   body.transform.position;

			head.transform.parent = Magent.transform;				//transfer bodyparts to one agent.
			body.transform.parent = Magent.transform;
			larm.transform.parent = Magent.transform;
			rarm.transform.parent = Magent.transform;
			lleg.transform.parent = Magent.transform;
			rleg.transform.parent = Magent.transform;
			cloth.transform.parent = Magent.transform;
			dress.transform.parent = Magent.transform;
			hair.transform.parent = Magent.transform;

			Magent.transform.localScale = new Vector3 (40f, 40f, 40f);  //gives agent necessary attris.

			int m = a + i;
			Magent.name = "Man" + m;
			Magent.AddComponent<Rigidbody> ();
			Magent.AddComponent<CapsuleCollider> ();
			Magent.GetComponent<CapsuleCollider> ().center = new Vector3 (0f, 0.023f, 0.006f);
			Magent.GetComponent<CapsuleCollider> ().radius = 0.008f;
			Magent.GetComponent<CapsuleCollider> ().height = 0.05f;


			Magent.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;

			//Magent.AddComponent<Animator> ();

			larm.AddComponent<Moving> ();				//call animator;
			larm.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			rarm.AddComponent<Moving> ();				//call animator;
			rarm.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			head.AddComponent<Moving> ();				//call animator;
			head.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			body.AddComponent<Moving> ();				//call animator;
			body.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			lleg.AddComponent<Moving> ();				//call animator;
			lleg.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			rleg.AddComponent<Moving> ();				//call animator;
			rleg.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			cloth.AddComponent<Moving> ();				//call animator;
			cloth.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			dress.AddComponent<Moving> ();				//call animator;
			dress.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;
			hair.AddComponent<Moving> ();				//call animator;
			hair.GetComponent<Animator> ().runtimeAnimatorController = RunTimeCon;

			/*---------------male Mcs-----------09 06---------------*/

			Magent.AddComponent<SphereCollider> ();
			Magent.GetComponent<SphereCollider> ().isTrigger = true;
			Magent.GetComponent<SphereCollider> ().center = new Vector3 (0f, 0.023f, 0f);
			Magent.GetComponent<SphereCollider> ().radius = 0.1f;

			Magent.AddComponent<BoxCollider> ();	
			Magent.GetComponent<BoxCollider> ().isTrigger = true;
			Magent.GetComponent<BoxCollider> ().center = new Vector3 (0f, 0.023f, 0f);
			Magent.GetComponent<BoxCollider> ().size = new Vector3 (0.5f,0.3f, 0.5f );

			Magent.AddComponent<McsTest> ();
			//Positions [i-1] = Magent.transform.position;

			Males [i-1] = Magent;

		}

		//foreach (Vector3 position in Positions) {				//check position.
			//print (position);
		//}

	}
	void CreateAnchors(){
		
		Vector3 anchorsize = new Vector3 (Space/2, Space/2, Space/2);
		GameObject anchor = new GameObject ();
		GameObject anchor1 = new GameObject ();
		GameObject anchor2 = new GameObject ();
		GameObject anchor3 = new GameObject ();
		anchor.name = "Anchor1";
		anchor1.name = "Anchor2";
		anchor2.name = "Anchor3";
		anchor3.name = "Anchor4";
		anchor.transform.position = new Vector3 (3f/4f * Space,Space/4f,3/4f* Space);
		anchor1.transform.position = new Vector3 (3f/4f * Space,Space/4f, -(3/4f * Space));
		anchor2.transform.position = new Vector3 (-(3f/4f * Space),Space/4f, (3f/4f * Space));
		anchor3.transform.position = new Vector3 (-(3f/4f * Space),Space/4f, -(3f/4f * Space));
		anchor.AddComponent<BoxCollider>();
		anchor1.AddComponent<BoxCollider>();
		anchor2.AddComponent<BoxCollider>();
		anchor3.AddComponent<BoxCollider>();

		anchor.GetComponent<BoxCollider> ().size = anchorsize;
		anchor1.GetComponent<BoxCollider> ().size = anchorsize;
		anchor2.GetComponent<BoxCollider> ().size = anchorsize;
		anchor3.GetComponent<BoxCollider> ().size = anchorsize;

	  anchor.GetComponent<BoxCollider> ().isTrigger = true;
		anchor2.GetComponent<BoxCollider> ().isTrigger = true;
		anchor3.GetComponent<BoxCollider> ().isTrigger = true;
		anchor1.GetComponent<BoxCollider> ().isTrigger = true;  

		anchor.AddComponent<BoundaryCol> ();
		anchor1.AddComponent<BoundaryCol> ();
		anchor2.AddComponent<BoundaryCol> ();
		anchor3.AddComponent<BoundaryCol> ();

	}

	void CreateBuildings(){
		for(int i = 0;i < BuildNum;i++){
			int Bpositionvalue = Random.Range (1, 5);
			int Bheight = Random.Range (20, 30);
			int Bwidth = Random.Range (8, 12);
			float Bpiovt = (float) Bheight / 2f;
			GameObject Building = Instantiate(Resources.Load("Building",typeof (GameObject)))as GameObject;
			Building.name = "B" + i;
			Building.transform.localScale = new Vector3 (Bwidth, Bheight, Bwidth);

			switch (Bpositionvalue){
			case 1:
				Building.transform.position = new Vector3 (Random.Range (Space/2, Space), Bpiovt, Random.Range (Space/2, Space));
				break;
			case 2:
				Building.transform.position = new Vector3 (Random.Range (Space/2, Space), Bpiovt, Random.Range (-Space, - Space/2));
				break;
			case 3:
				Building.transform.position = new Vector3 (Random.Range (-Space, - Space/2), Bpiovt, Random.Range (Space/2, Space));
				break;
			case 4:
				Building.transform.position = new Vector3 (Random.Range (-Space, - Space/2), Bpiovt, Random.Range (-Space, - Space/2));
				break;
			default:
				Debug.Log ("No building here!");
				break;
			}

			Building.AddComponent<Rigidbody>();
			Building.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			Building.AddComponent<NavMeshObstacle> ();

			//Building.GetComponent<NavMeshObstacle> ().size = new Vector3(0.9f,1.0f,0.9f);

			Building.GetComponent<NavMeshObstacle> ().carving = true;

		}
	}

	void OnGUI(){
		GUI.BeginGroup (new Rect (Screen.width / 2.2f - 400, Screen.height / 3.5f,100,230));
		GUI.Box (new Rect (0, 0, 100, 230), "Crowd");
		GUI.Box(new Rect(0,28,100,35),"AgentNumber");
		NumParse = GUI.TextField (new Rect (5,45,90,18), NumParse, 25);
		if (int.TryParse (NumParse, out Agentnum)) {
			
		} else {
			//Debug.Log ("please enter a number for agents!");

		}
		GUI.Box(new Rect(0,70,100,35),"GenderRatio");
		GenderRatio = GUI.HorizontalSlider (new Rect (5,90,90,10), GenderRatio, 0.1f, 1.0f);
		GUI.Box(new Rect(0,110,100,35),"Density");
		Density = GUI.HorizontalSlider (new Rect (5,130,90,10), Density, 1.0f, 5.0f);

		if(GUI.Button (new Rect (0, 190, 100, 30), "Create")){
			//Debug.Log ("Clicked");
			Fmales = new GameObject[Mathf.FloorToInt(Agentnum * GenderRatio)]; 
			Males =  new GameObject[Agentnum - Mathf.FloorToInt(Agentnum * GenderRatio)];
			CharacterCreate ();
			//if (Agentnum != 0) {
				//checker++;
			//}
		}
		GUI.EndGroup();

		GUI.BeginGroup (new Rect (Screen.width / 2.2f + 400, Screen.height / 3.5f,100,100));
		GUI.Box (new Rect (0, 0, 100, 100), "Map");
		GUI.Box(new Rect(0,25,100,40),"SpaceSize");
		NumParseT = GUI.TextField (new Rect (5,45,90,17), NumParseT, 25);
		if (int.TryParse (NumParseT, out Space)) {
		} else {
			//Debug.Log ("please enter a number for Spacesize!");
		}
		if(GUI.Button (new Rect (0, 70, 100, 30), "CreateMap")){
			CreateAnchors ();
		}
		GUI.EndGroup();

		GUI.Box (new Rect (720, 300, 210, 20), "Press SPACE to create Buildings.");
		//TODO count the total number of agents. idealy count males and females seperately.
	}

	 void Update(){


		if (Input.GetKeyDown (KeyCode.Space)) {
			
			CreateBuildings();
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			
			foreach (GameObject Magent in Males) {
				Magent.AddComponent<NavMeshAgent> ();
				Magent.GetComponent<NavMeshAgent> ().radius = 0.007f;
				Magent.GetComponent<NavMeshAgent> ().height = 0.04f;
				Magent.GetComponent<NavMeshAgent> ().speed = 1.0f;
				Magent.AddComponent<NaviTest> ();

				Magent.GetComponent<NavMeshAgent> ().stoppingDistance = Mathf.RoundToInt(Agentnum/3f);

				Magent.tag = "walker";


				Magent.GetComponent<NavMeshAgent> ().avoidancePriority = Random.Range (1, 100);



			}
		}
		if (Input.GetKeyDown (KeyCode.L)) {

			foreach (GameObject Fagent in Fmales) {
				
				Fagent.AddComponent<NavMeshAgent> ();
				Fagent.GetComponent<NavMeshAgent> ().radius = 0.007f;
				Fagent.GetComponent<NavMeshAgent> ().height = 0.04f;
				Fagent.GetComponent<NavMeshAgent> ().speed = 1.0f;
				Fagent.AddComponent<NaviTest> ();

				Fagent.GetComponent<NavMeshAgent> ().stoppingDistance = Mathf.RoundToInt(Agentnum/3f);

				Fagent.GetComponent<NavMeshAgent> ().avoidancePriority = Random.Range (1, 100);

				Fagent.tag = "walker";
				}
			}
		}

		/*if(checker >= 1){ --------------key board controlling for moving method--------------
			int AgentCaller = Random.Range (1,Mathf.FloorToInt(Agentnum * GenderRatio));
			int AgentCallerm = Random.Range (1,Agentnum - Mathf.FloorToInt(Agentnum * GenderRatio));

			float tiltAroundX = Input.GetAxis ("Horizontal") * tiltAngle *Time.deltaTime;
			float tiltAroundZ = Input.GetAxis ("Vertical") * tiltAngle;

			Quaternion target = Quaternion.Euler (tiltAroundZ * 0.1f, 0, tiltAroundZ * 0.1f);

			if(Males[AgentCallerm] != null) {
				Males [AgentCallerm].transform.Translate (tiltAroundX, 0f, tiltAroundZ);
				
					Males [AgentCaller].transform.position = 
			new Vector3 (Males [AgentCaller].transform.position.x,
						0.8f,
						Males [AgentCaller].transform.position.z + Random.Range (0f, tiltAroundZ));
			

				Males [AgentCallerm].GetComponent<Rigidbody> ().constraints &= ~RigidbodyConstraints.FreezeRotationY;
				Males [AgentCallerm].transform.rotation = 
				Quaternion.Slerp (Males [AgentCallerm].transform.rotation, target, Time.deltaTime * smooth);
			}
			if (Fmales [AgentCaller] != null) {
				Fmales [AgentCaller].transform.Translate (tiltAroundX, 0f, tiltAroundZ);
				Fmales [AgentCaller].GetComponent<Rigidbody> ().constraints &= ~RigidbodyConstraints.FreezeRotationY;
				Fmales [AgentCaller].transform.rotation = 
					Quaternion.Slerp (Fmales [AgentCaller].transform.rotation, target, Time.deltaTime * smooth);
			}
			
		}*/

	}

