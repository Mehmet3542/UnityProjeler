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
        //Bu klasýn turunden bir obje ver dedik. HEdef bulu yani. Diðer script teki mevcuta buradan ulaþtýk. Önce ona gidior sonra buraya geliyor. Sýrasýyla geziyor. Enemy nin istrriger iþaretli. Bir tanesi iþaretli olmalý
        //((HedefBul)(other.gameObject.GetComponent(typeof(HedefBul)))).mevcut_hedef = 1     bu haldeydi onceden, hedefler rasgele olusturulsun diye bu hale getirdik 
    }


}
