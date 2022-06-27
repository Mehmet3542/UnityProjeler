using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dusman : MonoBehaviour
{


    public float can = 100;

    private Animator anim;

    public bool oldumu = false;  //Zombiye buradan gonderdýk veriyi. ÖLÜP ÜLMEDÝÐÝNE BAKIYORUZ

    private Vector3 oldundurartýk;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HasarVer(float amount)  // Ates scriptinde buna deger verebiliyoruz.Orada yazdýgýmýz public degeri kadar burada candan dusecek biz belirlyecegýz rakamý // dusman.HasarVer(Hasar); // brada hasar yazan sey amount olarak bize donuyor
    //   { amount = Mathf.Clamp(amount, 0, 100); }  bunu deneyelim rasgele kendi verdi burayla alakasý yok

    {
        can -= amount;
        if (can <= 0)
        {
            Olum();

        }

    }

    public void Olum() //Yukarýda cab 0 dan asagýya inice bu iþleme gececek. Ýf in içinde üstte

    {
        //******************* Bu arayý ben yazdým. Olunca abuk sabuk hareket etmiyor artýk
        if (gameObject.tag == "Enemy")
        {
            Zombie zombie = GetComponent<Zombie>();
            NavMeshAgent zombie1 = zombie.GetComponent<NavMeshAgent>();
            zombie1.enabled = false;

            anim.SetFloat("Hiz", 0f); // Bunu da ben ekledim
                                      //************************


            anim.SetBool("Oldu", true);   // Animasyon oynatýyoruz burada
            oldumu = true;   // Oldu yani true oldu
            gameObject.tag = "Untagged";  // TAgýný da untagged olrak atadýkki bizim crosshair ýmýz bunu sürekli olarak kýrmýzý gormesin

            StartCoroutine(sil());
            //altta zamaný ben verdim buraya animasyon ekeyebiliriz
            // Destroy(gameObject);  //2f ben yazdým 2 saniye sonra ol dedim    Destroy(gameObject,2f);
        }
        //*********************************
        else if (gameObject.tag == "HedefNesneler")
        {
            oldumu = true;
            gameObject.tag = "Untagged";
            Destroy(gameObject);
        }
        //***********************************************
    }

    IEnumerator sil()  //Süre ile silecek objeyi
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);  //2f ben yazdým 2 saniye sonra ol dedim    Destroy(gameObject,2f);

    }
}
