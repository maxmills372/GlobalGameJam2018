using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidVomit : MonoBehaviour {

    public Transform aVomPrefab;
    public GameObject yellowZom;

	public Transform aVom;

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < 10; i++)
        {
			aVom = Instantiate(aVomPrefab, new Vector3(yellowZom.transform.position.x, yellowZom.transform.position.y, yellowZom.transform.position.z + 1), Quaternion.identity); 
			//newone.transform.Translate(Vector
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
