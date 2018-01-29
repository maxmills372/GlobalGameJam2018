using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Of_Bridge : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {

        if(col.collider.tag == "Player") //YOU CAN CHANGE THIS
        {
            CreateFixedJoint(col.collider.GetComponent<Rigidbody>());

        }
    }

    public void CreateFixedJoint(Rigidbody body)
    {
        FixedJoint fj = gameObject.AddComponent<FixedJoint>();

        fj.connectedBody = body;
    }
}
