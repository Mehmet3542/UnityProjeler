using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ates : MonoBehaviour
{


    public float Mesafe;   //Mesafe ölcmek için bu.Su kadar uzaklýktaki cisimleri aldýlama için

    public float sikma_araligi;  //Basýlý tutuncane kadar aralýklarla sýksýn

    float zamanlayici;  // kodla ayarlayacagýz

    public float Hasar; //Silahýn ne kadar hasar verecegýný ayarlayacagýz

    public int Mermi_sayisi;
    public int Sarjor;
   public int Sarjor_mermi; // eger farklý silahlara farklý sarjor belirleyeceksek buradan iþlem yapabýlýrýz. Altta bunu bagladýk Reload mermi sayýsýnda

    public TextMeshProUGUI mermisayisi1, sarjor1; // Yazýlarý alabilmek için ekledik

    bool fire = true; // daha sonra islevi oalcak

    public AudioSource sfx;  //Hoparlor

    public AudioClip ak; //sesdosyasý
    public AudioClip reload;
    public AudioClip Bos;

    public ParticleSystem muzzleflash;

    public Image crosshair;

    public Animation animas;

    // Start is called before the first frame update
    void Start()         //Sadece oyun tam baslarken 1 kez calýþýr baska calýsmaz
    {
        mermisayisi1.text = Mermi_sayisi.ToString();   //yazýlarý eþitledik
        sarjor1.text = Sarjor.ToString();           //yazýlarý eþitledik


    }

    // Update is called once per frame
    void FixedUpdate() //Burada biz belirliyoruz ne kadar yenileyecegýný o yuzden herkese farklý calýþmýyor
    {

        if (fire == true && Time.time > zamanlayici && (Input.GetMouseButton(0))) //Ates edilebilir true mu, Time.time eger zamanlayýcýdan buyukse ve  Mastusu basýlmýssa. BAsýlý tutarsan calýþýr
        {
            if (Mermi_sayisi > 0) // Mermisayýsý  0 dan buyukse
            {

                AtesEt();
                zamanlayici = Time.time + sikma_araligi;  //zamanlayýcýyý zamana esitleyip sýkma aralýgý ile topladýk. Basýlý tuutugumuzda saniyede 1000 defa ates etmeyecek bizim belirlediðimiz kadar ates edecek
            }
            else if (Sarjor > 0 && Mermi_sayisi < 30) // Sýfýrdan buyuk ve 30 dan kucukse
            {
                Reload();
            }

        }

        if (Input.GetMouseButtonDown(0))  // Down yazýnca Ne kadar basalý tutarsan tut  1 kez calýsýr. Ses efekti vermek için acmýs bu IF i
        {
            if (Mermi_sayisi <= 0 && Sarjor <= 0) // Mermi ve sajjor bittiyse
            {
                sfx.clip = Bos;
                sfx.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))

        {
            if (Sarjor > 0 && Mermi_sayisi < 30)
            {
                Reload();
            }
        }

        crosshair.color = Color.yellow;
        RaycastHit hit;    //KArakterimizzden gorunmez Iþýn yolladýk

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mesafe)) //bulundugumuz noktadan ileri dogru belirttiðimiz mesafe ýþýn yolladýk
        {
            if (hit.distance <= Mesafe && hit.collider.gameObject.tag == "Enemy" || hit.collider.gameObject.tag == "HedefNesneler") // Eðer vurulan mesafe benim belirttiðim mesafeye eþit ve kucukse, vurulan yani carpýþýlan objenin tagý enemy ise.Düþman vurus alanýmýza girdiði zaman,,,

                crosshair.color = Color.red;

        }



        /*
        Vector3 forward = transform.TransformDirection(Vector3.forward); // Vector 3 bir yon bicimi belirliyoruz. Karakterimizin transform konumundan Tranform direction forward diyerek karakterimizin ileri yonunu belittik

        RaycastHit hit;    //KArakterimizzden gorunmez Iþýn yolladýk
        crosshair.color = Color.yellow;
        if (Physics.Raycast(transform.position,forward,out hit, mesafe)) //bulundugumuz noktadan ileri dogru belirttiðimiz mesafe ýþýn yolladýk
        {
            if (hit.distance <= mesafe && hit.collider.gameObject.tag == "Enemy" ) // Eðer vurulan mesafe benim belirttiðim mesafeye eþit ve kucukse ve vurulan yani carpýþýlan objenin tagý enemy ise.Düþman vurus alanýmýza girdiði zaman,,,
            {
                crosshair.color = Color.red;       //Düþman vurus alanýmýza girdiði zaman,,, Vurdugmuz zaman kýrmýzý olacak rengi
                if (fire == true && (Input.GetMouseButton (0))) //fire true ise yani ateþ edebilir true ise sol fareye týklandýysa
                {
                 GameObject vurulanemeny =  enemy.GetComponent<GameObject>();
                    enemy.can = -10;
                    Debug.Log("vurdun");



                    fire = false; //üste üste 500-600 kez vurmasýn diye
                    enemy.can = enemy.can - 10;
                    StartCoroutine((firetime())); //Fire true yapmak ýcýn kullanacagýz bunu
                }

            }

        }
        */


    }



    public void AtesEt()

    {
        muzzleflash.Play();

        sfx.clip = ak;
        sfx.Play();

        Mermi_sayisi--;
        mermisayisi1.text = Mermi_sayisi.ToString();   // Mermi sayýsýnýn güncel halini text olarak yazdýrýyoruz


        animas.Play("Tepme");

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mesafe)) //bulundugumuz noktadan ileri dogru belirttiðimiz mesafe kadar ýþýn yolladýk
        {

            Dusman dusman = hit.transform.GetComponent<Dusman>(); // eger ýþýn düþman kodu olan bir obje varsa, altta kodu var yan null degýlse Dusman kodu olan bir obje bulduysa

            if (dusman != null)
            {
                dusman.HasarVer(Hasar); 
            }

        }



    }
    public void Reload()
    {
        Sarjor--;                            //sarjorden 1 elsilttik
        Mermi_sayisi= Sarjor_mermi;                     //Mermiyi 30 yazýyor  . Mermi sayýsýný buradan ayarlayabilirz silaha gore. Farklý silahlar için ayarladýk bu sistemi. Ne deger verirsek o kadar mermi ekleyecek reload basýnca
        mermisayisi1.text = Mermi_sayisi.ToString();    //yazý oalrak da mermi sayýsýný duzelttik
        sarjor1.text = Sarjor.ToString();     //sarjor sayýsýný da yazý olarak duzelttik
       // animas.Play("Sarjor");     //sarjor animasyonunu oynatýyor
        sfx.clip = reload;    //reload ses efektini de oynattý
        sfx.Play();          //oynattý üsttekini
        fire = false;    //Reload yaparken ates etmemizi engelliyor
        StartCoroutine(SDegis()); //

    }
    IEnumerator SDegis()
    {
        yield return new WaitForSeconds(1f) ; // 1 saniye bekle dedik
        //Bekledikten sonra
        sfx.clip = reload;    //oynattýk
        sfx.Play();
        yield return new WaitForSeconds(0.47f) ;  //47 sanise daha bekle diyoruz. 0,47 Sanise daha bekle ve ates edilebiliri true yap diyoruz
        fire = true;   // tekrar ates edebilir

    }


    /*   IEnumerator firetime() //Fire yukarýda false oldu.Onu true tyapmak için alttaki bunu kullanacagýz
   {
       yield return new WaitForSeconds(sýkma_araligi);  //    Zaman aralýgý veriyor bu sýkmaaralýgý kadar
       fire = true;

   }
    */


}

