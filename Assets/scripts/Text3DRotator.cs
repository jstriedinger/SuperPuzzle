using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text3DRotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(PlayerScript.instance.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 2);

    }
}
