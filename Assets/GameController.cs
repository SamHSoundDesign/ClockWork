using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<ClockFace> incorrectClockFaces = new List<ClockFace>();
    [SerializeField] List<ClockFace> completedClockFaces = new List<ClockFace>();
    public List<ClockFace> mastClockHands = new List<ClockFace>();
    [SerializeField] ClockFace selectedClock;
    [SerializeField] int selectedClockIndex;
    private bool isSelectedClockMoving;

    private float tempSpeedStore;

    public ClockFace[] allClockFaces;


   


    void Start()
    {
        allClockFaces = FindObjectsOfType<ClockFace>();

        for (int i = 0; i < allClockFaces.Length; i++)
        {
            if(allClockFaces[i].isMasterClock)
            {
                mastClockHands.Add(allClockFaces[i]);
            }

            else
            {
                allClockFaces[i].UNSELECTEDChangeClockFace();
                incorrectClockFaces.Add(allClockFaces[i]);

            }
        }

        selectedClockIndex = 0;
        selectedClock = incorrectClockFaces[selectedClockIndex];
        selectedClock.SELECTEDChangeClockFace();



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            // Pause selected Clock
            selectedClock.PauseSelectedClock();

        }

        if (Input.GetKeyUp("space"))
        {
            selectedClock.ResumeSelectedClock();
        }

        if (Input.GetKeyDown("a"))
        {
            //Select PREV clockface
            selectedClock.UNSELECTEDChangeClockFace();

            if (selectedClockIndex == 0)
            {
                selectedClockIndex = incorrectClockFaces.Count - 1;
            }

            else
            {
                selectedClockIndex--;
            }

            selectedClock = incorrectClockFaces[selectedClockIndex];
            selectedClock.SELECTEDChangeClockFace();

        }

        if (Input.GetKeyDown("d"))
        {
            //Select NEXT clockface
            selectedClock.UNSELECTEDChangeClockFace();

            if (selectedClockIndex == incorrectClockFaces.Count - 1)
            {
                selectedClockIndex = 0;
            }
            else
            {
                selectedClockIndex++;
            }

            selectedClock = incorrectClockFaces[selectedClockIndex];
            selectedClock.SELECTEDChangeClockFace();
        }



        //Controlls
        if (selectedClock.isComplete)
        {
            return;
        }

       
      

        if (Input.GetKeyDown("w"))
        {

            selectedClock.AddSpeed();
            
        }

        if (Input.GetKeyDown("s"))
        {
            selectedClock.ReduceSpeed();
           
        }


    }


}
