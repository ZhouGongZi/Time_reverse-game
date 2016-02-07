using UnityEngine;
using System.Collections;

public class Origin : MonoBehaviour {

	// Use this for initialization
	public GameObject			character_prefab;
	//related to time
	public int 					time_count = 0;

	public int 					num_limit = 3;
	public int 					cur_num = 0;

	public float 				offset = 0.5f;

	public static Origin OO; //use singleton tp  
	/*
	List<int> list1 = new List<int>();
	list1.Add(1);
	//list1.Add("Pony"); //<-- Error at compile process
	int total = 0;
	foreach (int num in list1 )
	{
		total += num;
	}*/





	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (num_limit != cur_num) {
			if (time_count % 600 == 0) {
				GameObject go = Instantiate<GameObject> (character_prefab);
				Vector3 origin_pos = transform.position;
				origin_pos.y += 0.25f;
				origin_pos.x += offset;
				offset -= 0.5f;

				go.transform.position = origin_pos;
				cur_num ++;
			}
			time_count ++;
		}

	}
}
