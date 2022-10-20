using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionDoor : MonoBehaviour
{
    [SerializeField] float timeToReachTarget;
    float t;
    Vector3 startPosition;
    Vector3 target;
    bool opened;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        target = startPosition + new Vector3(0, 4, 0);
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(opened)
        {
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, target, t);

        }
    }

    public void OpenDoor()
    {
        opened = true;
    }
}
