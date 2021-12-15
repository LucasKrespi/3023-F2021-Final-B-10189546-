using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SingletonTime : MonoBehaviour
{
    [SerializeField]
    public int minutos;
    public int horas;
    public int dias;
    private int weekCounter;
    public int semanas;
    public int anos;

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
        minutos = 0;
        horas = 0;
        dias = 1;
        weekCounter = 1;
        semanas = 1;
        anos = 2021;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            dias++;
            weekCounter++;
            dayChange.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            dias--;
            weekCounter--;
            dayChange.Invoke();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(timer >= 2)
        {
            minutos += 30;
            timer = 0;
        }

        if(minutos >= 60)
        {
            horas += 1;
            minutos = 0;
        }

        if( horas >= 24)
        {
            dias += 1;
            dayChange.Invoke();
            weekCounter += 1;
            horas = 0;
        }

        if(weekCounter > 7)
        {
            semanas += 1;
            weekCounter = 1;
        }

        if(semanas > 4)
        {
            anos += 1;
            semanas = 1;
            dias = 1;
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
