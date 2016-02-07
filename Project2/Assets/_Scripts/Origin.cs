using UnityEngine;
using System.Collections;

public class Origin : MonoBehaviour {

	// Use this for initialization
	public GameObject			character_prefab;
	//related to time
	public int 					time_count = 0;

	public int 					num_limit = 3;
	public int 					cur_num = 1;


	public static Origin OO; //use singleton tp  

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (num_limit != cur_num) {

			time_count ++;
			if (time_count % 650 == 0) {
				GameObject go = Instantiate<GameObject> (character_prefab);
				Vector3 origin_pos = transform.position;
				origin_pos.y += 0.25f;
				go.transform.position = origin_pos;
				cur_num ++;
			}
		}

	}
}
