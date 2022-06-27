using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{


    public GameObject mermi;

    public Transform mermiolusturmanoktasi;
    

    public float mermihizi;      
    public int atesSayaci;    //ates sýklýgý ne kadar aralýklarla ateþ edecek
    public int atesSayaciLimit;     // Private dediðimiz için altta degeri veriyoruz.Public deðil yani degeri vermemiz gerekiyor. Biz buradan verecegýz

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

        if (atesSayaci >0) // ates sayacaýný saydýracagýz þimdi. 0 dan buyukse yani deger varsa
           
        {
            atesSayaci--;
        }


    }
    void atesEt()
    {

       
        GameObject yeniolusanmermi1= Instantiate(mermi,mermiolusturmanoktasi.position,mermiolusturmanoktasi.rotation ); //ne üretilecek nerede üretilecek rotation ve posizyonu yazýyoruz
        Rigidbody olusanmermininRb= yeniolusanmermi1.GetComponent<Rigidbody>();  //olusan merminin componenti olan Rigidodyi al ve ben kullanacagým onu ata..... 

        olusanmermininRb.velocity = yeniolusanmermi1.transform.forward * mermihizi ;   //hýzýný velocy degýstýrecegýz                           
        Destroy(yeniolusanmermi1,5f); // 5 san   ye sonra yoket mermiyi dedik.
        atesSayaci--;










    }
}
