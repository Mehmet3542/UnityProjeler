using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{


    public GameObject mermi;

    public Transform mermiolusturmanoktasi;
    

    public float mermihizi;      
    public int atesSayaci;    //ates s�kl�g� ne kadar aral�klarla ate� edecek
    public int atesSayaciLimit;     // Private dedi�imiz i�in altta degeri veriyoruz.Public de�il yani degeri vermemiz gerekiyor. Biz buradan vereceg�z

    // Start is called before the first frame update
    void Start()
    {
        atesSayaci = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (atesSayaci == 0 && Input.GetMouseButton(0))
        {
            atesEt();
            atesSayaci = atesSayaciLimit;
        }

        if (atesSayaci >0) // ates sayaca�n� sayd�racag�z �imdi. 0 dan buyukse yani deger varsa
           
        {
            atesSayaci--;
        }


    }
    void atesEt()
    {

       
        GameObject yeniolusanmermi1= Instantiate(mermi,mermiolusturmanoktasi.position,mermiolusturmanoktasi.rotation ); //ne �retilecek nerede �retilecek rotation ve posizyonu yaz�yoruz
        Rigidbody olusanmermininRb= yeniolusanmermi1.GetComponent<Rigidbody>();  //olusan merminin componenti olan Rigidodyi al ve ben kullanacag�m onu ata..... 

        olusanmermininRb.velocity = yeniolusanmermi1.transform.forward * mermihizi ;   //h�z�n� velocy deg�st�receg�z                           
        Destroy(yeniolusanmermi1,5f); // 5 san   ye sonra yoket mermiyi dedik.
        atesSayaci--;










    }
}
