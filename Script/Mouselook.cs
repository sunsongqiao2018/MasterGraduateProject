using System;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
	public float mouseSensitivity = 100.0f;
	public float clampAngle = 80.0f;

	public float fovmin = 10.0f;
	public float fovmax = 90.0f;

	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis

	public string info;

	void Start ()
	{
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
	}
	void Update ()
	{
		if(Input.GetMouseButton (1)){                     //hold mouse rightclick to move and zoom
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		transform.rotation = localRotation;
		//mouse wheel zoom
		float fov = Camera.main.fieldOfView;
		fov += Input.GetAxis ("Mouse ScrollWheel") * mouseSensitivity;
		fov = Mathf.Clamp (fov, fovmin, fovmax);
		Camera.main.fieldOfView = fov;

			/*----------------ray caster-------------*/

			
			if (Input.GetMouseButtonDown (1)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 100)) {
					
					info = hit.transform.gameObject.name + "@" + hit.transform.gameObject.transform.position;
					info = info.Replace ("@", Environment.NewLine);
					
					//Debug.Log (info);
					//Debug.Log (hit.transform.gameObject.transform.position);
					
				}
			}
		}
	}
	void OnGUI(){
		
		GUI.Box (new Rect (80, 35, 120, 50), info);
		//Debug.Log (Event.current);

	}
}