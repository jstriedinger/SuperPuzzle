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
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(PlayerScript.instance.transform.position.x - transform.position.x, transform.position.y, PlayerScript.instance.transform.position.z - transform.position.z));// PlayerScript.instance.transform.position.z - transform.position.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 2);

    }
}
