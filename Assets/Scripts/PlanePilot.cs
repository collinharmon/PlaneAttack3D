using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePilot : MonoBehaviour {
	public float speed = 1.0f;
	//public Transform BombSpawn;
	public GameObject Bomb;
	private double lastShot = 0.0;
	private double fireRate = .75;
	// Use this for initialization
	void Start () {
			Debug.Log("plane pilot script added to: " + gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 hmm = transform.position;
		Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
		float bias = 0.96f;
		Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f-bias);
		Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);
		transform.position += transform.forward * Time.deltaTime * speed;
		//line below causes plane to go slower if its going up (fighting gravity) and faster if its going dwon
		speed -= transform.forward.y * Time.deltaTime + 50.0f;
		if(speed < 35.0f){
			speed = 35.0f;
		}
		transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
		float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);
		if(terrainHeightWhereWeAre > transform.position.y){
			transform.position = new Vector3(transform.position.x,terrainHeightWhereWeAre,transform.position.z);
		}
		if (Input.GetKey("z"))
		{
			Instantiate(Bomb, transform.position, Quaternion.identity);
		   //if(Time.time > fireRate + lastShot)
			//{
				//Vector3 fuck = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
				//GameObject aBomb = Instantiate(Bomb, transform.position , Quaternion.identity) as GameObject;
				//Rigidbody bombRigidbody = aBomb.GetComponent<Rigidbody>();
				//Vector3 velocity1 = transform.forward;
				//bombRigidbody.velocity += velocity1;
				//lastShot = Time.time;
			//}
		}
	}
	
}
