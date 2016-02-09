// simplify the mechanic: 
// 1. limit the number of characters to be 3

using UnityEngine;
using System.Collections;

public class Origin : MonoBehaviour {

	// Use this for initialization
	public GameObject			character_prefab_0;
	public GameObject			character_prefab_1;
	public GameObject			character_prefab_2;
	//related to time
	public int 					time_count = 0;
	public int					record_count = 0;

	public int 					num_limit = 3;
	public int 					cur_num = 0;

	public float 				offset = 0.5f;

	public static Origin OO; //use singleton tp  
	

	public GameObject			G0; //clone1
	public GameObject 			G1; //clone2
	public Vector3[] 			list0 = new Vector3[551];
	public Vector3[] 			list1 = new Vector3[551];
	//public Vector3[] 			list2 = new Vector3[550];
	

	void Start () {
		OO = this;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (0 == cur_num) {

			if (time_count % 600 == 0) {
				cur_num ++;

				GameObject go = Instantiate<GameObject> (character_prefab_0);
				Vector3 origin_pos = transform.position;
				origin_pos.y += 0.25f;
				origin_pos.x += offset;
				//offset -= 0.5f;
				go.transform.position = origin_pos;
			}

		}
		else if(1 == cur_num){
			if (time_count % 600 == 0) {
				cur_num ++;
				
				GameObject go = Instantiate<GameObject> (character_prefab_1);
				Vector3 origin_pos = transform.position;
				origin_pos.y += 0.25f;
				origin_pos.x += offset;
				//offset -= 0.5f;
				go.transform.position = origin_pos;
			}
		}
		else if(2 == cur_num){
			if (time_count % 600 == 0) {
				cur_num ++;
				
				GameObject go = Instantiate<GameObject> (character_prefab_2);
				Vector3 origin_pos = transform.position;
				origin_pos.y += 0.25f;
				origin_pos.x += offset;
				//offset -= 0.5f;
				go.transform.position = origin_pos;
			}
		}


		else if (num_limit == cur_num) {
			if(record_count == 0){
				G0 = Instantiate<GameObject> (character_prefab_0);
				G1 = Instantiate<GameObject> (character_prefab_1);
				G0.transform.position = list0[record_count];
				G1.transform.position = list1[record_count];
			}else if(record_count <= 549){ //has to be 549 not to over the boundary
				G0.transform.position = list0[record_count];
				G1.transform.position = list1[record_count];
			}
			record_count ++;
		}
		time_count ++;

	}
}
