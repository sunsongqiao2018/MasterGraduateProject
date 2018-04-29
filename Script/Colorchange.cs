using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorchange : MonoBehaviour {
	
	public Gradient Gcolor;
	public GameObject Mtroso;
	public MeshRenderer Mrenderer;
	public float Gradmin;
	public float Gradmax;
	public Mesh Meshtroso;
 	// Use this for initialization
	void Start () {
		Mrenderer = Mtroso.GetComponent<MeshRenderer> ();
		MeshCollider trosoCo = Mtroso.AddComponent<MeshCollider> ();
		trosoCo.sharedMesh = Meshtroso;
		Gradmin = 0.0f;
		Gradmax = 1.0f;
		}
	// Update is called once per frame
	void Update () {
		int i = 0;
		if (i < 500 || Gradmin < Gradmax) {
			Mrenderer.material.color = Gcolor.Evaluate (Gradmin);
			Gradmin = Gradmin + 0.01f;
			i ++;
		} else {
			Gradmin = 0.0f;
			i = 0;
		}
	}
	void CollisionEvent(Collision col){
		if (col.gameObject.name == "Mtroso") {
			Destroy (col.gameObject);
		}

	}
}
