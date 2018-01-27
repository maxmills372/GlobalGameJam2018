using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpread : MonoBehaviour
{

    public float scale_factor = 1.002f;
    public float max_scale = 0.6f;
    Vector3 default_scale;
   
    Color default_colour;

    // Use this for initialization
    void Start()
    {
        default_scale = gameObject.transform.localScale;
        default_colour = gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
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

        while (gameObject.transform.localScale.x <= max_scale)
        {
            gameObject.transform.localScale *= scale_factor;

            yield return null;
        }

        Debug.Log("OH HELO THER");



        StopCoroutine("FadeOut");
        StartCoroutine("FadeOut");
        
    }

    IEnumerator FadeOut()
    {
        float alpha = gameObject.GetComponent<Renderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime/0.2f)
        {
            Color new_colour = gameObject.GetComponent<Renderer>().material.color;

            new_colour.a = Mathf.Lerp(alpha, 0, t);

            gameObject.GetComponent<Renderer>().material.color = new_colour;

            yield return null;
        }
        Debug.Log("ndkjgn");
    }
}
