using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WordCloudOnOff : MonoBehaviour
{
    public XRRayInteractor leftRay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider.tag == "WordCloud")
            {
                if (hit.collider.gameObject.GetComponent<MeshRenderer>().enabled == true)
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
                else
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
    }
}
