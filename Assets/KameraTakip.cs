using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{

   
    private Vector3 hedefkonumu;
    
    public GameObject KameraKimiTakipEdecekHedef;

    // Start is called before the first frame update
    void Start()
    {
        
     


        hedefkonumu = transform.position - KameraKimiTakipEdecekHedef.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
   
     
        transform.position = KameraKimiTakipEdecekHedef.transform.position  +hedefkonumu ;
       // transform.rotation = KameraKimiTakipEdecekHedef.transform.rotation;
        //transform.forward=KameraKimiTakipEdecekHedef. transform.forward;

        //Vector3 kamerayon = cam.transform.forward;

        // kamerayon.y = 0f;
        //transform.forward = kamerayon;



    }
}
