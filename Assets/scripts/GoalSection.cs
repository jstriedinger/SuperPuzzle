using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class GoalSection : MonoBehaviour
{
    [SerializeField] int goalVal = 1;
    [SerializeField] Color goalColor;
    [SerializeField] private TextMeshProUGUI currentNumTxt;
    [SerializeField] private TextMeshProUGUI goalTxt;


    private List<Item> currentItems = new List<Item>();
    private int currentNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentNumTxt.text = "0";
        goalTxt.text = goalVal.ToString();
        goalTxt.color = goalColor;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            Item itemToAdd = other.gameObject.GetComponent<Item>();
            if (itemToAdd != null)
            {
                if (!currentItems.Contains(itemToAdd))
                {
                    currentItems.Add(itemToAdd);
                    //sum
                    currentNum += itemToAdd.number;
                    currentNumTxt.text = currentNum.ToString();
                    
                  
                    Color mostRepeatedColor = currentItems.GroupBy(x => x.color).OrderByDescending(x => x.Count()).First().ToList().First().color;
                    currentNumTxt.color = mostRepeatedColor;

                    CheckWin();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            Item itemToRemove = other.gameObject.GetComponent<Item>();
            if (itemToRemove != null)
            {
                if (currentItems.Contains(itemToRemove))
                {
                    currentItems.Remove(itemToRemove);
                    //sum
                    currentNum -= itemToRemove.number;
                    currentNumTxt.text = currentNum.ToString();

                    if(currentItems.Count() > 0 )
                    {
                        Color mostRepeatedColor = currentItems.GroupBy(x => x.color).OrderByDescending(x => x.Count()).First().ToList().First().color;
                        currentNumTxt.color = mostRepeatedColor;
                    }
                    else
                    {
                        currentNumTxt.color = Color.black;
                    }
                }
            }
        }
    }

    private void CheckWin()
    {
        if (goalVal == currentNum && goalColor == currentNumTxt.color)
            Debug.Log("Yoo won!");
    }


}
