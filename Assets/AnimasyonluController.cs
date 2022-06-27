using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimasyonluController : MonoBehaviour
{
    Animator AnimasyonKedi;
    float AnimasyonKediHizBlend; //Kodlarý kýsalttýk
    float axisZ = 0.25f;

    bool silahli = false;

   // float rootspeed = 80;
   // float rot = 0;
  //  float gravity = 8;

   // CharacterController control;
   // Vector3 moveDir = Vector3.zero;
  //  Camera cam;
    // Start is called before the first frame update
    void Start()
    {
     //   control = GetComponent<CharacterController>();
        AnimasyonKedi = GetComponent<Animator>(); //Animasyona ulaþtýk controlun oldugu karakterin animatorune

     //   cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {

        // if (control)  //Karakter yerdeyse
        // {
        if (Input.GetKey(KeyCode.W))
        {
            //  moveDir = new Vector3(0, 0, 1);
            // AnimasyonKedi.SetFloat("hizblend", 0.4f);
            AnimasyonKediHizBlend = 3f;
            axisZ = AnimasyonKediHizBlend * Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                AnimasyonKediHizBlend = 5f;
                // AnimasyonKedi.SetFloat("hizblend", 1f);
                axisZ = AnimasyonKediHizBlend * Input.GetAxis("Vertical");
            }

                        /*
                            if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.W))
                            {
                                AnimasyonKediHizBlend = 12f;
                                // AnimasyonKedi.SetFloat("hizblend", 1f);
                                axisZ = AnimasyonKediHizBlend * Input.GetAxis("Vertical");
                                AnimasyonKedi.SetBool("sagileri", true);
                                Debug.Log("burada");
                            }
            */


        }

        else  //Birden durmasý yerine yavaþca durmasýný saglayacagýz
        {

            //AnimasyonKedi.SetFloat("hizblend", 0f);
            AnimasyonKediHizBlend = 0f;
            axisZ = AnimasyonKediHizBlend * Input.GetAxis("Vertical");
        }




        if (Input.GetKey(KeyCode.A))
        {/*
                rot += Input.GetAxis("Horizontal") * rootspeed * Time.deltaTime;   //BAskasýndan baktým boyle yaptý
                transform.eulerAngles = new Vector3(0,rot,0);
                moveDir.y -= gravity * Time.deltaTime;
                control.Move(moveDir*Time.deltaTime);
            */
            AnimasyonKedi.SetBool("solayuru", true);
            AnimasyonKedi.SetBool("silahlisol", true);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            AnimasyonKedi.SetBool("solayuru", false);
            AnimasyonKedi.SetBool("silahlisol", false);
        }




        if (Input.GetKeyDown(KeyCode.D))
        {
            AnimasyonKedi.SetBool("silahlisag", true);
            AnimasyonKedi.SetBool("sagileri", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            AnimasyonKedi.SetBool("silahlisag", false);
            AnimasyonKedi.SetBool("sagileri", false);
        }


        Vector3 vector = new Vector3(0, 0, axisZ);

     // AnimasyonKedi.SetBool("tekrar", false);

        if (silahli==false)
        {
          
            AnimasyonKedi.SetFloat("hizblend", Vector3.ClampMagnitude(vector, 5f).magnitude, 1f, Time.deltaTime * 3f);  //Animasyonlar arasý tatlý bir geçiþ saðlýyor.eN SON BURADAN YOLLUYOR ANÝMASYONA HIZIN NE OLACAGINI
           //AnimasyonKedi.SetFloat("hizblend", AnimasyonKediHizBlend); //Burada arka taraftsaki Hizblende ulaþtýk ///Birden durmasý yerine yavaþca durmasýný saglayacagýz
            if (Input.GetKey(KeyCode.T))
            {
                AnimasyonKedi.SetFloat("hizblend", 0);
                silahli = true;
                AnimasyonKedi.SetBool("tekrar", false);

                AnimasyonKedi.SetBool("silahliidle", true);

                // AnimasyonKedi.SetFloat("hizblend", Vector3.ClampMagnitude(vector, 5f).magnitude, 1f, Time.deltaTime * 3f);  //Animasyonlar arasý tatlý bir geçiþ saðlýyor.eN SON BURADAN YOLLUYOR ANÝMASYONA HIZIN NE OLACAGINI


            }


        }

        if (silahli)
        {
            AnimasyonKedi.SetFloat("hizblendsilahli", Vector3.ClampMagnitude(vector, 5f).magnitude, 1f, Time.deltaTime * 3f);

            // AnimasyonKedi.SetFloat("hizblendsilahli", AnimasyonKediHizBlend); //Burada arka taraftsaki Hizblende ulaþtýk ///Birden durmasý yerine yavaþca durmasýný saglayacagýz
            if (Input.GetKey(KeyCode.Y))
            {
                silahli = false;


                AnimasyonKedi.SetFloat("hizblendsilahli", 0);

                AnimasyonKedi.SetBool("tekrar", true);

                AnimasyonKedi.SetBool("silahliidle", false);
            }


        }

        //Y acýsýný sabitliyor. FreeFly dan aaldým bunu
        //  Vector3 kamerayon = transform.forward;

        //  kamerayon. y = 0f;
        // transform.forward = kamerayon;
        //  transform.rotation= Kedi.transform.rotation;
        // Kedi.transform.rotation=transform.rotation;



        //      

        //  if ((Input.GetKey(KeyCode.T)))
        //  {
        //  silahli = true;



        //  }








        //  AnimasyonKedi.SetFloat("hizblend", Vector3.ClampMagnitude(vector, 5f).magnitude, 1f, Time.deltaTime * 3f);  //Animasyonlar arasý tatlý bir geçiþ saðlýyor.eN SON BURADAN YOLLUYOR ANÝMASYONA HIZIN NE OLACAGINI
        //AnimasyonKedi.SetFloat( "hizblend" , axisZ * Time.deltaTime);
        //Kamerayý adamýn baktýgý tarafa yonlendiriyoruz

        //Vector3 kamerayon = cam.transform.forward;

        // kamerayon.y = 0f;
        //transform.forward = kamerayon;

        //w  }

    }
}
