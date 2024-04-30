using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    Vector3 cameraDir;
    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PhotoBill();
        WordBill();
    }

    private void PhotoBill()
    {
        cameraDir = Camera.main.transform.forward;
        cameraDir.y = 0;

        transform.rotation = Quaternion.LookRotation(cameraDir);
    }

    private void WordBill()
    {
        //cameraDir = Camera.main.transform.forward;
        mainCam = Camera.main;

        transform.LookAt(mainCam.transform);
        transform.Rotate(0, 180, 0);
    }
}
