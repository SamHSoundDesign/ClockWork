using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotation : MonoBehaviour
{
   

    [SerializeField] Vector3 clockFaceCenter = new Vector3();
    [SerializeField] GameObject centrePointForRotation;
    [SerializeField] ClockFace clockFace;
    

    // Start is called before the first frame update
    void Start()
    {
        clockFaceCenter = new Vector3(transform.position.x , centrePointForRotation.transform.position.y , centrePointForRotation.transform.position.z);

       
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(clockFaceCenter, new Vector3(0, 0, -1), clockFace.speed * Time.deltaTime);
    }
}
