using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{

    public float mesafe;

    private Transform hedef;

    NavMeshAgent agent; // kosturma yapay zekasý

   Animator anima;



    public Dusman dusman; //DUSMAN SCRÝPTÝNÝ ALIYORUZ BURADA


    // Start is called before the first frame update
    void Start()
    {
        hedef = GameObject.FindWithTag("Player").GetComponent<Transform>();  // Spawnlayarak getirecegiz zombileri. Bu yuzden bu sekýlde bulacak zombiler oyuncu tagý kimdeyse onu. Ve Transformunu alýyoruz. Hedefi asagýda 
        anima =GetComponent<Animator>();              //
        agent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {
        if (dusman.oldumu == false)    //Dusman hala yasýyorsa
        {
            anima.SetFloat("Hiz",agent.velocity.magnitude); //Animasyonun Float Hýz degerini, Agent in hýz degerine yani Velocity sine eþitle diyoruz. Velocity =Hýz demek. Normalde hatýrlarsan buraya biz deger yazýyorduk onun yerine agentin hýzýna esýtledik


            mesafe =Vector3.Distance(transform.position,hedef.position);// Burada mesafeyi belirliyoruz.Hedef posizyonla aramýzdaki mesafeyi blirliyoruz

            if (mesafe<=15)  // mesafe 15 den kucukse... MESAFEYE SAYI ÝLE ULASTIK!!!!
            {
                agent.enabled = true;                   //YAPAY ZEKAYI BAÞLATTIK BURADA!!!!!
                agent.destination = hedef.position;     //Yapay zekayý açýnca hemen hedefi verdik saldýracak.DESTÝNATIÝON !!!!!!!!
            }
            else
            {
                agent.enabled=false;         //YAPAY ZEKAYI KAPATTIK BURADA!!!!!
            }
            if (mesafe <=1.2)   //Eger aradak mesafe 1.2 den kucukse 
            {
                agent.enabled = false;   //Bunu yapmazsak zombi sureklý ýcýmýze girmeye calýþýr ittirir bizi. 
            }
            if (dusman.oldumu== true)
            {
                agent.enabled = false; // Olunca zaten false kosturmayý karapatmamýz lazým

            }
        }



        
    }
}
