using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class GoalSection : MonoBehaviour
{
    [SerializeField] int goalVal = 1;
    [SerializeField] Color goalColor;
    [SerializeField] private TextMeshProUGUI goaUI;

    private List<Item> currentItems = new List<Item>();
    private int currentNum = 0;
    private bool solved = false;
    private bool closed = false;

    // Start is called before the first frame update
    void Start()
    {
        goaUI.text = "0 / "+ goalVal.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetSolved()
    {
        return solved;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "item" && !closed)
        {
            Item itemToAdd = collision.gameObject.GetComponent<Item>();
            if (itemToAdd != null)
            {
                if (!currentItems.Contains(itemToAdd))
                {
                    currentItems.Add(itemToAdd);
                    //sum
                    currentNum += itemToAdd.number;
                    goaUI.text = currentNum.ToString()+" / "+goalVal;
                    
                  
                    Color mostRepeatedColor = currentItems.GroupBy(x => x.color).OrderByDescending(x => x.Count()).First().ToList().First().color;
                    goaUI.color = mostRepeatedColor;

                    CheckWin();
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "item" && !closed)
        {
            Item itemToRemove = collision.gameObject.GetComponent<Item>();
            if (itemToRemove != null)
            {
                if (currentItems.Contains(itemToRemove))
                {
                    currentItems.Remove(itemToRemove);
                    //sum
                    currentNum -= itemToRemove.number;
                    goaUI.text = currentNum.ToString()+" / "+goalVal;

                    if(currentItems.Count() > 0 )
                    {
                        Color mostRepeatedColor = currentItems.GroupBy(x => x.color).OrderByDescending(x => x.Count()).First().ToList().First().color;
                        goaUI.color = mostRepeatedColor;
                    }
                    else
                    {
                        goaUI.color = Color.black;
                    }
                }
            }
        }
    }

    private void CheckWin()
    {
        if (goalVal == currentNum && goalColor == goaUI.color)
        {
            solved = true;
            goaUI.text = goalVal+"/"+ goalVal;
            Debug.Log("Yoo won!");
        } else
        {
            solved = false;
            goaUI.text = currentNum.ToString() + " / " + goalVal;
        }
    }

    public void Close()
    {
        closed = true;
    }


}
