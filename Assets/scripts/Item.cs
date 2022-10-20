using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public int number;
    [SerializeField] public Color color;


    private Material myMaterial;
    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        //myMaterial.color = color;
        myMaterial.SetColor("_EmissionColor", color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
