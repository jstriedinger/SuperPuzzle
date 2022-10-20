using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    [Header("Grab object")]
    [SerializeField] Transform grabArea;
    [SerializeField] float pickupRange = 5f;
    [SerializeField] float pickupForce = 150f;
    private GameObject itemOnHand;
    private Rigidbody rigidbodyOnHand;
    private Camera cam;

    [Header("Cursor")]
    [SerializeField] private Texture2D cursorGrabbing;
    [SerializeField] private Texture2D cursorHand;




    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * pickupRange, Color.yellow);
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        bool gotHit = Physics.Raycast(ray, out hit, pickupRange, LayerMask.GetMask("item"));
        if (gotHit)
        {
            if (itemOnHand == null)
            {
                //change cursor
                
                Cursor.SetCursor(cursorHand, Vector2.zero, CursorMode.Auto);
                Debug.Log("Curso hand");
                if (Input.GetMouseButtonDown(0))
                {
                    grabObject(hit.transform.gameObject);
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    dropObject();
                }
                else
                {
                    
                    Cursor.SetCursor(cursorGrabbing, Vector2.zero, CursorMode.Auto);
                }

            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                dropObject();
            }
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        MoveObject();
       
    }

    void MoveObject()
    {
        if(itemOnHand != null  && Vector3.Distance(itemOnHand.transform.position, grabArea.position) > 0.1f)
        {
            Vector3 moveDir = grabArea.position - itemOnHand.transform.position;
            rigidbodyOnHand.AddForce(moveDir * pickupForce);
        }

    }

    private void grabObject(GameObject grabbedObj)
    {
        Rigidbody rb = grabbedObj.GetComponent<Rigidbody>();
        if( rb )
        {
            rigidbodyOnHand = rb;
            rigidbodyOnHand.useGravity = false;
            rigidbodyOnHand.drag = 10;
            rigidbodyOnHand.constraints = RigidbodyConstraints.FreezeRotation;

            rigidbodyOnHand.transform.parent = grabArea;
            itemOnHand = grabbedObj;
        }
    }

    private void dropObject()
    {
        if(itemOnHand )
        {
            rigidbodyOnHand.useGravity = true;
            rigidbodyOnHand.drag = 1;
            rigidbodyOnHand.constraints = RigidbodyConstraints.None;

            rigidbodyOnHand.transform.parent = null;
            itemOnHand = null;

        }
    }
}
