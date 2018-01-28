using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPIN : MonoBehaviour {

    public float spin_amount = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.Rotate(new Vector3(1, 0, 0), spin_amount);
	}

    void OnCollisionEnter(Collision col)
    {

        
    }
}
