using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSection : MonoBehaviour
{
    [SerializeField] SectionDoor door;
    [SerializeField] AudioClip winSFX;
    private GoalSection[] goals;
    private bool solved = false;

    // Start is called before the first frame update
    void Start()
    {
        goals = GetComponentsInChildren<GoalSection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!solved)
            CheckWonSection();
    }

    void CheckWonSection()
    {
        bool isItSolved = true;
        foreach (var goal in goals)
        {
            if(!goal.GetSolved())
            {
                isItSolved = false;
                break;
            }
        }
        solved = isItSolved;
        if(solved)
        {
            door.OpenDoor();
            foreach (var goal in goals)
            {
                goal.Close();
            }
            AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position);

        }
    }
}
