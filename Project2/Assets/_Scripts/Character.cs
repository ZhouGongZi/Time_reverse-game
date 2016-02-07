using UnityEngine;
using System.Collections;

//assumption: every character can only press twice (once ?) of throw state (boost).


public class Character : MonoBehaviour {
	//used for movement
	public float				moveSpeed = 4f;
	public float				jumpSpeed = 4.5f;
	public Rigidbody			rigid;
	//isGrounded
	public bool 				grounded = false;
	public int					groundLayerMask;
	public Vector3 				ray_Offset;
	public float 				cast_radius = 0.28f; //the length of the ray
	
	//related to time
	public int 					time_count = 0;

	// Use this for initialization
	void Start () { 
		rigid = GetComponent<Rigidbody> ();

		ray_Offset = new Vector3 (0.22f, 0, 0);
		groundLayerMask = LayerMask.GetMask ("Ground");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//record the position to the vector in Origin.OO first
		if (Origin.OO.cur_num == 1) {
			Origin.OO.list0[time_count] = transform.position;
		} else if (Origin.OO.cur_num == 2) {
			Origin.OO.list1[time_count] = transform.position;
		} 

		//isGrounded 
		Vector3 center = this.transform.position;
		grounded = Physics.Raycast (center, Vector3.down, cast_radius, groundLayerMask) 
			|| Physics.Raycast (center + ray_Offset, Vector3.down, cast_radius, groundLayerMask)
			|| Physics.Raycast (center - ray_Offset, Vector3.down, cast_radius, groundLayerMask);


		//time runout
		time_count ++;
		if (time_count == 550)
			Destroy (gameObject);


		Vector3 vel = rigid.velocity;
		//left and right
		if (Input.GetKey (KeyCode.RightArrow)) {
			vel.x = moveSpeed;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			vel.x = -moveSpeed;
		} else {
			vel.x = 0;
		}
		//up and down
		if (Input.GetKeyDown (KeyCode.S) && grounded) {
			vel.y = jumpSpeed;
		}
		rigid.velocity = vel;
	}
}






