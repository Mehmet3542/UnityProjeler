using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ates : MonoBehaviour
{


    public float Mesafe;   //Mesafe �lcmek i�in bu.Su kadar uzakl�ktaki cisimleri ald�lama i�in

    public float sikma_araligi;  //Bas�l� tutuncane kadar aral�klarla s�ks�n

    float zamanlayici;  // kodla ayarlayacag�z

    public float Hasar; //Silah�n ne kadar hasar vereceg�n� ayarlayacag�z

    public int Mermi_sayisi;
    public int Sarjor;
   public int Sarjor_mermi; // eger farkl� silahlara farkl� sarjor belirleyeceksek buradan i�lem yapab�l�r�z. Altta bunu baglad�k Reload mermi say�s�nda

    public TextMeshProUGUI mermisayisi1, sarjor1; // Yaz�lar� alabilmek i�in ekledik

    bool fire = true; // daha sonra islevi oalcak

    public AudioSource sfx;  //Hoparlor

    public AudioClip ak; //sesdosyas�
    public AudioClip reload;
    public AudioClip Bos;

    public ParticleSystem muzzleflash;

    public Image crosshair;

    public Animation animas;

    // Start is called before the first frame update
    void Start()         //Sadece oyun tam baslarken 1 kez cal���r baska cal�smaz
    {
        mermisayisi1.text = Mermi_sayisi.ToString();   //yaz�lar� e�itledik
        sarjor1.text = Sarjor.ToString();           //yaz�lar� e�itledik


    }

    // Update is called once per frame
    void FixedUpdate() //Burada biz belirliyoruz ne kadar yenileyeceg�n� o yuzden herkese farkl� cal��m�yor
    {

        if (fire == true && Time.time > zamanlayici && (Input.GetMouseButton(0))) //Ates edilebilir true mu, Time.time eger zamanlay�c�dan buyukse ve  Mastusu bas�lm�ssa. BAs�l� tutarsan cal���r
        {
            if (Mermi_sayisi > 0) // Mermisay�s�  0 dan buyukse
            {

                AtesEt();
                zamanlayici = Time.time + sikma_araligi;  //zamanlay�c�y� zamana esitleyip s�kma aral�g� ile toplad�k. Bas�l� tuutugumuzda saniyede 1000 defa ates etmeyecek bizim belirledi�imiz kadar ates edecek
            }
            else if (Sarjor > 0 && Mermi_sayisi < 30) // S�f�rdan buyuk ve 30 dan kucukse
            {
                Reload();
            }

        }

        if (Input.GetMouseButtonDown(0))  // Down yaz�nca Ne kadar basal� tutarsan tut  1 kez cal�s�r. Ses efekti vermek i�in acm�s bu IF i
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
        RaycastHit hit;    //KArakterimizzden gorunmez I��n yollad�k

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mesafe)) //bulundugumuz noktadan ileri dogru belirtti�imiz mesafe ���n yollad�k
        {
            if (hit.distance <= Mesafe && hit.collider.gameObject.tag == "Enemy" || hit.collider.gameObject.tag == "HedefNesneler") // E�er vurulan mesafe benim belirtti�im mesafeye e�it ve kucukse, vurulan yani carp���lan objenin tag� enemy ise.D��man vurus alan�m�za girdi�i zaman,,,

                crosshair.color = Color.red;

        }



        /*
        Vector3 forward = transform.TransformDirection(Vector3.forward); // Vector 3 bir yon bicimi belirliyoruz. Karakterimizin transform konumundan Tranform direction forward diyerek karakterimizin ileri yonunu belittik

        RaycastHit hit;    //KArakterimizzden gorunmez I��n yollad�k
        crosshair.color = Color.yellow;
        if (Physics.Raycast(transform.position,forward,out hit, mesafe)) //bulundugumuz noktadan ileri dogru belirtti�imiz mesafe ���n yollad�k
        {
            if (hit.distance <= mesafe && hit.collider.gameObject.tag == "Enemy" ) // E�er vurulan mesafe benim belirtti�im mesafeye e�it ve kucukse ve vurulan yani carp���lan objenin tag� enemy ise.D��man vurus alan�m�za girdi�i zaman,,,
            {
                crosshair.color = Color.red;       //D��man vurus alan�m�za girdi�i zaman,,, Vurdugmuz zaman k�rm�z� olacak rengi
                if (fire == true && (Input.GetMouseButton (0))) //fire true ise yani ate� edebilir true ise sol fareye t�kland�ysa
                {
                 GameObject vurulanemeny =  enemy.GetComponent<GameObject>();
                    enemy.can = -10;
                    Debug.Log("vurdun");



                    fire = false; //�ste �ste 500-600 kez vurmas�n diye
                    enemy.can = enemy.can - 10;
                    StartCoroutine((firetime())); //Fire true yapmak �c�n kullanacag�z bunu
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
        mermisayisi1.text = Mermi_sayisi.ToString();   // Mermi say�s�n�n g�ncel halini text olarak yazd�r�yoruz


        animas.Play("Tepme");

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mesafe)) //bulundugumuz noktadan ileri dogru belirtti�imiz mesafe kadar ���n yollad�k
        {

            Dusman dusman = hit.transform.GetComponent<Dusman>(); // eger ���n d��man kodu olan bir obje varsa, altta kodu var yan null deg�lse Dusman kodu olan bir obje bulduysa

            if (dusman != null)
            {
                dusman.HasarVer(Hasar); 
            }

        }



    }
    public void Reload()
    {
        Sarjor--;                            //sarjorden 1 elsilttik
        Mermi_sayisi= Sarjor_mermi;                     //Mermiyi 30 yaz�yor  . Mermi say�s�n� buradan ayarlayabilirz silaha gore. Farkl� silahlar i�in ayarlad�k bu sistemi. Ne deger verirsek o kadar mermi ekleyecek reload bas�nca
        mermisayisi1.text = Mermi_sayisi.ToString();    //yaz� oalrak da mermi say�s�n� duzelttik
        sarjor1.text = Sarjor.ToString();     //sarjor say�s�n� da yaz� olarak duzelttik
       // animas.Play("Sarjor");     //sarjor animasyonunu oynat�yor
        sfx.clip = reload;    //reload ses efektini de oynatt�
        sfx.Play();          //oynatt� �sttekini
        fire = false;    //Reload yaparken ates etmemizi engelliyor
        StartCoroutine(SDegis()); //

    }
    IEnumerator SDegis()
    {
        yield return new WaitForSeconds(1f) ; // 1 saniye bekle dedik
        //Bekledikten sonra
        sfx.clip = reload;    //oynatt�k
        sfx.Play();
        yield return new WaitForSeconds(0.47f) ;  //47 sanise daha bekle diyoruz. 0,47 Sanise daha bekle ve ates edilebiliri true yap diyoruz
        fire = true;   // tekrar ates edebilir

    }


    /*   IEnumerator firetime() //Fire yukar�da false oldu.Onu true tyapmak i�in alttaki bunu kullanacag�z
   {
       yield return new WaitForSeconds(s�kma_araligi);  //    Zaman aral�g� veriyor bu s�kmaaral�g� kadar
       fire = true;

   }
    */


}

