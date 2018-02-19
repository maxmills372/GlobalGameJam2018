using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BridgeFormation : MonoBehaviour {

    //IM ON IT

	//public GameObject[] bridge;
	public List<GameObject> bridge = new List<GameObject>();

	public Transform bridge_start_pos;
	public Rigidbody bridge_start_body;
    bool form_bridge;
	public bool stop;
	public bool done;
    int count;
    public int bridge_amount = 10;
    public Vector3 force;

	GameObject hive;

	// Use this for initialization
	void Start () {
        count = 0;
        stop = false;
		done = false;
		hive = GameObject.Find("ZombHive");
    }

	public void Form_Bridge()
	{
		form_bridge = true;
	}

	IEnumerator StopPhysics()
	{
		yield return new WaitForSeconds (1.0f);
		foreach (GameObject obj in bridge) 
		{
			obj.GetComponent<Rigidbody> ().isKinematic = true;
		}
		yield return null;
	}

	void Finished()
	{
		StartCoroutine (StopPhysics());
	}

	// Update is called once per frame
	void Update () 
	{
       
		// if there are Orange ppl in the herd
		// 		Add them to the bridge list
		// if they leave the heard
		//		remove from bridge list


		/*if (hive.GetComponent<HiveMind>().the_hive.Count > 0 && bridge.Count < bridge_amount)
		{
			foreach (GameObject obj in hive.GetComponent<HiveMind>().the_hive) 
			{
				if (obj.GetComponent<BasicZombz> ().zom_colour == BasicZombz.Zom_Colour.YELLOW) 
				{
					if (bridge.Contains (obj) != true) {
						bridge.Add (obj);
					}
				}
			}
		}*/

		if(Input.GetKeyDown(KeyCode.B))
		{
			form_bridge = true;
		}

        if (form_bridge)
        {
			//to set up the beggining of the bridge
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
            }

			//to set up the rest of the bridge
			for (int i = 1; i < bridge.Count; i++)
            {
                if (!bridge[i].GetComponent<MoveTest>().arrived)
                {
                    bridge[i].GetComponent<NavMeshAgent>().SetDestination(bridge[i - 1].transform.position);

                }
                else
                {
                    if (!stop)
                    {
                        bridge[i].transform.position = new Vector3(bridge_start_pos.position.x, bridge_start_pos.position.y + (i * (0.63f*bridge[0].transform.localScale.x)), bridge_start_pos.position.z);
                    }

                }
            }

            
			//for counting if all the minions have arrived
            count = 0;
			for (int i = 0; i < bridge.Count; i++)
            {
                if (bridge[i].GetComponent<MoveTest>().arrived)
                {
                    count++;

                }
            }
            Debug.Log(count);
            
			// creates joints once all are there
            if (count == bridge_amount)
            {
                if (!bridge[0].GetComponent<MoveTest>().joint)
                {
                    bridge[0].GetComponent<MoveTest>().CreateJoint(bridge_start_body);//, 0.4963608f, 0.4766202f, 0.36f);
                    bridge[0].GetComponent<NavMeshAgent>().enabled = false;
                    bridge[0].GetComponent<MoveTest>().joint = true;       
                }

				for (int i = 1; i < bridge.Count; i++)
                {
                    if (!bridge[i].GetComponent<MoveTest>().joint)
                    {
                        bridge[i].GetComponent<MoveTest>().CreateFixedJoint(bridge[i - 1].GetComponent<Rigidbody>());
                        bridge[i].GetComponent<NavMeshAgent>().enabled = false;
                        bridge[i].GetComponent<MoveTest>().joint = true;
						bridge [i].GetComponent<Rigidbody> ().mass = 1.0f;
                    }
                }

                stop = true;
				if (!done) 
				{
					bridge [bridge_amount - 1].tag = "End_Bridge"; // YOU CAN CHANGE THIS
					bridge [bridge_amount - 1].transform.forward = Vector3.forward;
					bridge [bridge_amount - 1].GetComponent<Rigidbody> ().AddForce (force);
					done = true;
				}

            }

            
            
        }
		
	}
}
