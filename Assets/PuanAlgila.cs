using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PuanAlgila : MonoBehaviour
{
    public TMPro.TextMeshProUGUI skor_text;

    private int toplananpuan;
    

    // Start is called before the first frame update
    void Start()
    { 
        toplananpuan = 0;
    

        //skor_text = GameObject.Find("Canvas/skor_text").GetComponent<TMPro.TextMeshProUGUI>(); //Find ile bulduk texti


    }

    // Update is called once per frame
    void Update()

    {
       
    }
   

    private void OnCollisionEnter(Collision collision)    //trigger kapal� olanlar carparsa skor veriyor aksi halde vermiyor.
    {

     
       
            Debug.Log("PLAYER CARPTI");
         //   collision.gameObject.transform.position = collision.gameObject.transform.position + transform.position.;
              toplananpuan+=100;
        skor_text.text = "Toplam Puan   " + toplananpuan;
        
        collision.transform.position = new Vector3(62f, 0f, 29f);

    }
    private void OnTriggerEnter(Collider other) //Trigger ac�k olanlara skor veriyor sadece.  
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("carp�sma" + toplananpuan);

            toplananpuan += 1;
            
                 
                 }
       // else if (other.CompareTag("Eksi")) // Else if bu olmad� ama bir de buna bak demek
      //  {
          //  toplananpuan --;
       // }


    }

   // private void OnTriggerStay(Collider other) // Obje �zerinde stay yani kald�g� s�rece demek
   // {
   //     toplananpuan += 1;
   // }
}
