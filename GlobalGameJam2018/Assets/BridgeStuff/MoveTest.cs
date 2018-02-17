using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTest : MonoBehaviour {


	Vector3 move, connected_anchor; 
	public bool arrived, joint;

   // public Rigidbody end_cube_rigidbody;

	// Use this for initialization
	void Start ()
    {
		arrived = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(!arrived)
		{
			move = gameObject.GetComponent<NavMeshAgent>().desiredVelocity;

			transform.position = transform.position + move * Time.deltaTime;

		}
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Finish")
		{
			arrived = true;
            Debug.Log("jdsb");
        }
                
       
	}

	/*public void CreateJoint(Rigidbody body,float posX, float posY, float posZ)
	{
		HingeJoint hj = gameObject.AddComponent<HingeJoint>();
		hj.axis = new Vector3(0,0,1);

        //gameObject.transform.Rotate(new Vector3(0, 0, 1), 90.0f);

        hj.autoConfigureConnectedAnchor = false;
        connected_anchor = new Vector3(posX, posY, posZ);
        hj.connectedAnchor = connected_anchor;
       
        hj.connectedBody = body;
	}*/
    public void CreateJoint(Rigidbody body)
    {

       // gameObject.transform.position = Twin_Capsule.transform.position;
       // gameObject.transform.rotation = Twin_Capsule.transform.rotation;

        HingeJoint hj = gameObject.AddComponent<HingeJoint>();
        hj.axis = new Vector3(1, 0, 0);
        
        hj.connectedBody = body;


    }

    public void CreateFixedJoint(Rigidbody body)
    {
        FixedJoint fj = gameObject.AddComponent<FixedJoint>();
              
        fj.connectedBody = body;
    }

}
