using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftControl : MonoBehaviour {

    bool move;
    public int button_ID;

    public GameObject forklift;
    public Transform forklift_pos;

    // Use this for initialization
    void Start () {
        move = false;
   
    }
	
	// Update is called once per frame
	void Update () {
		
        //Forklift
        if(move && forklift.transform.position.y >= forklift_pos.position.y)
        {
            forklift.transform.Translate(new Vector3(0, 0.1f, 0));
        }
	}
    void OnCollisionEnter(Collision col)
    {

        if(col.collider.tag == "Player")
        {

            move = true;
        }
    }
}
