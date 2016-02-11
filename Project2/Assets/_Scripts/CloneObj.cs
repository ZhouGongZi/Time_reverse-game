using UnityEngine;
using System.Collections;

public class CloneObj : MonoBehaviour {

	public int				time_count = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		time_count ++;
		if (time_count == 550)
			Destroy (gameObject);
	}
}
