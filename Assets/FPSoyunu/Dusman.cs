using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dusman : MonoBehaviour
{


    public float can = 100;

    private Animator anim;

    public bool oldumu = false;  //Zombiye buradan gonderd�k veriyi. �L�P �LMED���NE BAKIYORUZ

    private Vector3 oldundurart�k;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HasarVer(float amount)  // Ates scriptinde buna deger verebiliyoruz.Orada yazd�g�m�z public degeri kadar burada candan dusecek biz belirlyeceg�z rakam� // dusman.HasarVer(Hasar); // brada hasar yazan sey amount olarak bize donuyor
    //   { amount = Mathf.Clamp(amount, 0, 100); }  bunu deneyelim rasgele kendi verdi burayla alakas� yok

    {
        can -= amount;
        if (can <= 0)
        {
            Olum();

        }

    }

    public void Olum() //Yukar�da cab 0 dan asag�ya inice bu i�leme gececek. �f in i�inde �stte

    {
        //******************* Bu aray� ben yazd�m. Olunca abuk sabuk hareket etmiyor art�k
        if (gameObject.tag == "Enemy")
        {
            Zombie zombie = GetComponent<Zombie>();
            NavMeshAgent zombie1 = zombie.GetComponent<NavMeshAgent>();
            zombie1.enabled = false;

            anim.SetFloat("Hiz", 0f); // Bunu da ben ekledim
                                      //************************


            anim.SetBool("Oldu", true);   // Animasyon oynat�yoruz burada
            oldumu = true;   // Oldu yani true oldu
            gameObject.tag = "Untagged";  // TAg�n� da untagged olrak atad�kki bizim crosshair �m�z bunu s�rekli olarak k�rm�z� gormesin

            StartCoroutine(sil());
            //altta zaman� ben verdim buraya animasyon ekeyebiliriz
            // Destroy(gameObject);  //2f ben yazd�m 2 saniye sonra ol dedim    Destroy(gameObject,2f);
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

    IEnumerator sil()  //S�re ile silecek objeyi
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);  //2f ben yazd�m 2 saniye sonra ol dedim    Destroy(gameObject,2f);

    }
}
