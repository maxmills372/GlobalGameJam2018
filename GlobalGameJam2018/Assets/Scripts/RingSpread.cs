using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpread : MonoBehaviour
{

    public float scale_factor = 1.002f;
	public float fade_speed = 5.0f;
    public float max_scale = 0.6f;
    Vector3 default_scale;
   
	Light light;

    Color default_colour;

	Vector3 small, big;

    // Use this for initialization
    void Start()
    {
        default_scale = gameObject.transform.localScale;
        default_colour = gameObject.GetComponent<Renderer>().material.color;
		light = GetComponent<Light> ();
		light.intensity = gameObject.transform.localScale.x;

		small = Vector3.zero;
		big = new Vector3 (max_scale, max_scale, max_scale);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButton("Pulse"))
        {
            gameObject.transform.localScale = default_scale;

            default_colour.a = 1.0f;
            gameObject.GetComponent<Renderer>().material.color = default_colour;

            StopCoroutine("Grow");
            StartCoroutine("Grow");
        }
    }

    IEnumerator Grow()
    {
		float t = 0.0f;

		while (t <= 1.0f) 
		{
			gameObject.transform.localScale = Vector3.Slerp (small, big, t);
			t += scale_factor * Time.deltaTime;
			light.intensity = t;

			yield return null;
		}
        
        StopCoroutine("FadeOut");
        StartCoroutine("FadeOut");
        
    }

    IEnumerator FadeOut()
    {
        float alpha = gameObject.GetComponent<Renderer>().material.color.a;
		float t = 0.0f;
		while(t <= 1.0f)
        {
            Color new_colour = gameObject.GetComponent<Renderer>().material.color;

            new_colour.a = Mathf.Lerp(alpha, 0, t);

            gameObject.GetComponent<Renderer>().material.color = new_colour;

			light.intensity = new_colour.a;

			t += Time.deltaTime * fade_speed;

            yield return null;
        }

		gameObject.transform.localScale = default_scale;
    }

//	void OnTriggerEnter (Collider col)
//	{
//		// Zomb collection
//		if(col.tag == "Zombz")
//		{
//			//Trigger on player;
//			SendMessageUpwards("RingOnTriggerEnter", col);
//		}
//	}
}
