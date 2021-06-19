using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockFace : MonoBehaviour
{
    public Light highLight;
    public HandRotation handRotation;
    public bool isMasterClock = false;
    public float speed = 40;
    public GameController gameController;

    [SerializeField] Color selectedColor = Color.cyan;
    [SerializeField] Color masterClockColor = Color.blue;
    [SerializeField] Color correctColor = Color.green;
    [SerializeField] Color pausedColor = Color.red;

    private float tempSpeedStore;

    public bool isComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        tempSpeedStore = 0;

        if (isMasterClock)
        {
            highLight.color = masterClockColor;
            highLight.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SELECTEDChangeClockFace()
    {
        highLight.color = selectedColor;
        highLight.enabled = true;
    } 
    
    public void UNSELECTEDChangeClockFace()
    {
        highLight.enabled = false;
    }

    public void PauseSelectedClock()
    {
        tempSpeedStore = speed;
        speed = 0;
        highLight.color = pausedColor;
    }
    
    public void ResumeSelectedClock()
    {
        highLight.color = selectedColor;
        speed = tempSpeedStore;
        tempSpeedStore = 0;
    }

    public void AddSpeed()
    {
        speed = speed + 5;
        if(speed == gameController.mastClockHands[0].speed)
        {
            //Clockface speed is same as master clockface speed
            SpeedCorrect();
        }
    }
    public void ReduceSpeed()
    {
        speed = speed - 5;

        if (speed == gameController.mastClockHands[0].speed)
        {
            //Clockface speed is same as master clockface speed
            SpeedCorrect();
        }
    }

    private void SpeedCorrect()
    {
        isComplete = true;
        highLight.color = correctColor;
    }
}
