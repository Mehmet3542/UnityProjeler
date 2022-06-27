using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delayeffect : MonoBehaviour  // internetten almýþ anlatmadý
{
    public float amount = 0.02f;
    public float maxAmount = 0.03f;
    public float smooth = 3f;
    private Vector3 def;


    // Start is called before the first frame update
    void Start()
    {
        def = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float factorX = -Input.GetAxis("Mouse X") * amount;
        float factorY = -Input.GetAxis("Mouse X") * amount;

        factorX = Mathf.Clamp(factorX, -maxAmount, maxAmount);
        factorY = Mathf.Clamp(factorY, -maxAmount, maxAmount  );

        Vector3 target = new Vector3(def.x + factorX, def.y+ factorY, def.z);  

       transform.localPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * smooth);

    }
}
