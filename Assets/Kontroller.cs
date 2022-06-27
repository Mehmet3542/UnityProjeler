using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontroller : MonoBehaviour
{
    Vector3 target;

    //private Rigidbody rb;
    public float hizx;
    public float hizy;
    public float hizz;
    float speed = 1.1f;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        YeniTarget(new Vector3(hizx, hizy, hizz));  //Bizim adamın konumu bu ne alaka anlamadım
        Debug.Log("1");

    }

    // Update is called once per frame
    void Update()
    {

        // rb.AddForce(Input.GetAxis("Horizontal") * hizx, 0f, Input.GetAxis("Vertical") * hizz);


        if (Input.GetMouseButtonDown(0)==true)
        {
            Debug.Log("2");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit TıklamaBilgisi;
            if (Physics.Raycast(ray.origin , ray.direction, out TıklamaBilgisi) == true)
            {
                YeniTarget(new Vector3(TıklamaBilgisi.point.x, transform.position.y, TıklamaBilgisi.point.z));
            }


        }

        Vector3 direction= target -transform.position;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        Debug.Log("4");


    }
    void YeniTarget(Vector3 newTarget)
    {
        Debug.Log("3");
        target = newTarget;
        transform.LookAt(target);
    }
}
