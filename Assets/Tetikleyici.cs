using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetikleyici : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        ((HedefBul)(other.gameObject.GetComponent(typeof(HedefBul)))).yeniHedefBul();
        //Bu klas�n turunden bir obje ver dedik. HEdef bulu yani. Di�er script teki mevcuta buradan ula�t�k. �nce ona gidior sonra buraya geliyor. S�ras�yla geziyor. Enemy nin istrriger i�aretli. Bir tanesi i�aretli olmal�
        //((HedefBul)(other.gameObject.GetComponent(typeof(HedefBul)))).mevcut_hedef = 1     bu haldeydi onceden, hedefler rasgele olusturulsun diye bu hale getirdik 
    }


}
