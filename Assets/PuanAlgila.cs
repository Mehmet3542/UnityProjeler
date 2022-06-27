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
   

    private void OnCollisionEnter(Collision collision)    //trigger kapalý olanlar carparsa skor veriyor aksi halde vermiyor.
    {

     
       
            Debug.Log("PLAYER CARPTI");
         //   collision.gameObject.transform.position = collision.gameObject.transform.position + transform.position.;
              toplananpuan+=100;
        skor_text.text = "Toplam Puan   " + toplananpuan;
        
        collision.transform.position = new Vector3(62f, 0f, 29f);

    }
    private void OnTriggerEnter(Collider other) //Trigger acýk olanlara skor veriyor sadece.  
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("carpýsma" + toplananpuan);

            toplananpuan += 1;
            
                 
                 }
       // else if (other.CompareTag("Eksi")) // Else if bu olmadý ama bir de buna bak demek
      //  {
          //  toplananpuan --;
       // }


    }

   // private void OnTriggerStay(Collider other) // Obje üzerinde stay yani kaldýgý sürece demek
   // {
   //     toplananpuan += 1;
   // }
}
