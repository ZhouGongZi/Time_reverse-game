using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
	public GameObject		doorObj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter(Collider other){
		if (other.tag == "Player") {
			Destroy(doorObj);
		}
	}
}
