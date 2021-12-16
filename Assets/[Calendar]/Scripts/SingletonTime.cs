using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SingletonTime : MonoBehaviour
{
    [HideInInspector]
    public int minutes;
    [HideInInspector]
    public int hours;
    [HideInInspector]
    public int days;
    [HideInInspector]
    private int weekCounter;
    [HideInInspector]
    public int weeks;
    [HideInInspector]
    public int years;

    public static SingletonTime instance;

    private float timer;

    //Events
    public UnityEvent<Day, bool> dayWeather_Event;
    public UnityEvent dayChange;
    public UnityEvent yearChange;

    // Start is called before the first frame update

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }

        timer = 0;
        minutes = 0;
        hours = 0;
        days = 1;
        weekCounter = 1;
        weeks = 1;
        years = 2021;
    }

    private void Update()
    {
        //For debug
        if (Input.GetKeyDown(KeyCode.N))
        {
            days++;
            weekCounter++;
            dayChange.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            days--;
            weekCounter--;
            dayChange.Invoke();
        }
    //}
  
    //// Update is called once per frame
    //private void FixedUpdate()
    //{
        timer += Time.deltaTime;

        if(timer >= 2)
        {
            minutes += 30;
            timer = 0;
        }

        if(minutes >= 60)
        {
            hours += 1;
            minutes = 0;
        }

        if( hours >= 24)
        {
            days += 1;
            dayChange.Invoke();
            weekCounter += 1;
            hours = 0;
        }

        if(weekCounter > 7)
        {
            weeks += 1;
            weekCounter = 1;
        }

        if(weeks > 4)
        {
            years += 1;
            weeks = 1;
            days = 1;
            yearChange.Invoke();
        }
    }


    public enum Seasons
    {
        SPRING = 0,
        SUMMER = 1,
        FALL = 2,
        WINTER = 3,
        SPOOKYDAY = 4,
        SUMMER_SOLSTICE = 5,
        SNOWY = 6,
        NEW_YEAR = 7
    }
}
