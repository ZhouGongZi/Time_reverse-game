using UnityEngine;
using System.Collections;

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






