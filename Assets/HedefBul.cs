using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

     
public class HedefBul : MonoBehaviour
{


    public GameObject [] target;              //d��man
    public int mevcut_hedef;

    public int hedef_sayisi;  //  2=   ragele hedef belirlemek i�in sonradan act�k bunu


                   // vector 3 u baglad�k
   private NavMeshAgent agent;                   //bizim adam


    // Start is called before the first frame update
    void Start()
    {
        //S�REKL� HEDEF ATAMAYA GEREK YOK HEDEF� �LK BA�LADIGINDA SRAT YAN� BURADA YAPTIK. b�R SONRAK�N� DE /private void OnTriggerEnter(Collider other)/ TET�KLEY�C�DEK� BU METHOD �LE YAPTIK
        agent = GetComponent<NavMeshAgent>();     //agent � ald�k
        hedef_sayisi = target.Length;    // 2= hedef say�s�n� burada yeni olusturdugumuz inte verdik
        yeniHedefBul(); //allta mevcuthedefe deger atad�k ragsgele hedef olsun diye. Buradayaz�kki bir alttaki sat�rda uygulans�n
       

    }

    // Update is called once per frame
    void Update()
    {
        




       
    }
   

    public void  yeniHedefBul()       
    {
        mevcut_hedef = (int) (Random.Range (0,hedef_sayisi));    //0 ve hedef say�s� aras�ndan ragsgele say� belirliyoruz -AYNI ZAMANDA YEN� HEDEFE DE YOL BEL�RLER ARKA SAYFADA
        agent.SetDestination(target[mevcut_hedef].transform.position);    //Gidece�i konumu kuruyoruz ayarl�yoruz
    }
}
