using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BridgeFormation : MonoBehaviour {

    //IM ON IT

	public GameObject[] bridge;
	public Transform bridge_start_pos;
	public Rigidbody bridge_start_body;
    bool form_bridge;
    public bool stop;
    int count;
    public int bridge_amount = 10;
    public Vector3 force;

	// Use this for initialization
	void Start () {
        count = 0;
        stop = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
       
		// if there are Orange ppl in the herd
		// 		Add them to the bridge list
		// if they leave the heard
		//		remove from bridge list

		if(Input.GetKeyDown(KeyCode.B))
		{
			form_bridge = true;
		}

        if (form_bridge)
        {

            if (!bridge[0].GetComponent<MoveTest>().arrived)
            {
                bridge[0].GetComponent<NavMeshAgent>().SetDestination(bridge_start_pos.position);

            }
            else
            {
                if (!stop)
                {
                    bridge[0].transform.position = bridge_start_pos.position;
                }
                /*if(!bridge[0].GetComponent<MoveTest>().joint)
				{
                    bridge[0].GetComponent<MoveTest>().CreateJoint(bridge_start_body);//, 0.4963608f, 0.4766202f, 0.36f);
					bridge[0].GetComponent<NavMeshAgent>().enabled = false;
					bridge[0].GetComponent<MoveTest>().joint = true;
                }*/
            }

            for (int i = 1; i < bridge.Length; i++)
            {
                if (!bridge[i].GetComponent<MoveTest>().arrived)
                {
                    bridge[i].GetComponent<NavMeshAgent>().SetDestination(bridge[i - 1].transform.position);

                }
                else
                {
                    if (!stop)
                    {
                        bridge[i].transform.position = new Vector3(bridge_start_pos.position.x, bridge_start_pos.position.y + (i * (2*bridge[0].transform.localScale.x)), bridge_start_pos.position.z);
                    }

                }
            }
            
            count = 0;
            for (int i = 0; i < bridge.Length; i++)
            {
                if (bridge[i].GetComponent<MoveTest>().arrived)
                {
                    count++;

                }
            }
            Debug.Log(count);
            
            if (count == bridge_amount)
            {
                if (!bridge[0].GetComponent<MoveTest>().joint)
                {
                    bridge[0].GetComponent<MoveTest>().CreateJoint(bridge_start_body);//, 0.4963608f, 0.4766202f, 0.36f);
                    bridge[0].GetComponent<NavMeshAgent>().enabled = false;
                    bridge[0].GetComponent<MoveTest>().joint = true;

                   
                    
                }

                for (int i = 1; i < bridge.Length; i++)
                {
                    if (!bridge[i].GetComponent<MoveTest>().joint)
                    {
                        bridge[i].GetComponent<MoveTest>().CreateFixedJoint(bridge[i - 1].GetComponent<Rigidbody>());
                        bridge[i].GetComponent<NavMeshAgent>().enabled = false;
                        bridge[i].GetComponent<MoveTest>().joint = true;
                    }
                }

                stop = true;

                bridge[bridge_amount - 1].tag = "Player"; // YOU CAN CHANGE THIS
                bridge[bridge_amount - 1].GetComponent<Rigidbody>().AddForce(force);
            }

            
            
        }
		
	}
}
