using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{

    public float mesafe;

    private Transform hedef;

    NavMeshAgent agent; // kosturma yapay zekas�

   Animator anima;



    public Dusman dusman; //DUSMAN SCR�PT�N� ALIYORUZ BURADA


    // Start is called before the first frame update
    void Start()
    {
        hedef = GameObject.FindWithTag("Player").GetComponent<Transform>();  // Spawnlayarak getirecegiz zombileri. Bu yuzden bu sek�lde bulacak zombiler oyuncu tag� kimdeyse onu. Ve Transformunu al�yoruz. Hedefi asag�da 
        anima =GetComponent<Animator>();              //
        agent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {
        if (dusman.oldumu == false)    //Dusman hala yas�yorsa
        {
            anima.SetFloat("Hiz",agent.velocity.magnitude); //Animasyonun Float H�z degerini, Agent in h�z degerine yani Velocity sine e�itle diyoruz. Velocity =H�z demek. Normalde hat�rlarsan buraya biz deger yaz�yorduk onun yerine agentin h�z�na es�tledik


            mesafe =Vector3.Distance(transform.position,hedef.position);// Burada mesafeyi belirliyoruz.Hedef posizyonla aram�zdaki mesafeyi blirliyoruz

            if (mesafe<=15)  // mesafe 15 den kucukse... MESAFEYE SAYI �LE ULASTIK!!!!
            {
                agent.enabled = true;                   //YAPAY ZEKAYI BA�LATTIK BURADA!!!!!
                agent.destination = hedef.position;     //Yapay zekay� a��nca hemen hedefi verdik sald�racak.DEST�NATI�ON !!!!!!!!
            }
            else
            {
                agent.enabled=false;         //YAPAY ZEKAYI KAPATTIK BURADA!!!!!
            }
            if (mesafe <=1.2)   //Eger aradak mesafe 1.2 den kucukse 
            {
                agent.enabled = false;   //Bunu yapmazsak zombi surekl� �c�m�ze girmeye cal���r ittirir bizi. 
            }
            if (dusman.oldumu== true)
            {
                agent.enabled = false; // Olunca zaten false kosturmay� karapatmam�z laz�m

            }
        }



        
    }
}
