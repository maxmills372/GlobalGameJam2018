using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableContainer : MonoBehaviour {

    public Vector3 force;
	// Use this for initialization
	void Start () {
        //force = new Vector3(0, 0, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionStay(Collision col)
    {

        if(col.collider.tag == "Player")
        {
            gameObject.GetComponent<Rigidbody>().AddForce(force);
            Debug.Log("bdjfhs");
        }
    }
}
