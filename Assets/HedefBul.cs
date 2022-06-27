using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

     
public class HedefBul : MonoBehaviour
{


    public GameObject [] target;              //düþman
    public int mevcut_hedef;

    public int hedef_sayisi;  //  2=   ragele hedef belirlemek için sonradan actýk bunu


                   // vector 3 u bagladýk
   private NavMeshAgent agent;                   //bizim adam


    // Start is called before the first frame update
    void Start()
    {
        //SÜREKLÝ HEDEF ATAMAYA GEREK YOK HEDEFÝ ÝLK BAÞLADIGINDA SRAT YANÝ BURADA YAPTIK. bÝR SONRAKÝNÝ DE /private void OnTriggerEnter(Collider other)/ TETÝKLEYÝCÝDEKÝ BU METHOD ÝLE YAPTIK
        agent = GetComponent<NavMeshAgent>();     //agent ý aldýk
        hedef_sayisi = target.Length;    // 2= hedef sayýsýný burada yeni olusturdugumuz inte verdik
        yeniHedefBul(); //allta mevcuthedefe deger atadýk ragsgele hedef olsun diye. Buradayazýkki bir alttaki satýrda uygulansýn
       

    }

    // Update is called once per frame
    void Update()
    {
        




       
    }
   

    public void  yeniHedefBul()       
    {
        mevcut_hedef = (int) (Random.Range (0,hedef_sayisi));    //0 ve hedef sayýsý arasýndan ragsgele sayý belirliyoruz -AYNI ZAMANDA YENÝ HEDEFE DE YOL BELÝRLER ARKA SAYFADA
        agent.SetDestination(target[mevcut_hedef].transform.position);    //Gideceði konumu kuruyoruz ayarlýyoruz
    }
}
