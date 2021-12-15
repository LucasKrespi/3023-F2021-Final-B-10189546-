using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayController : MonoBehaviour
{
    private GameObject m_goDay;
    private Image Weather, SeasonEffect;
    private TextMeshProUGUI dayText;
    

    private int day;
    private int week;

    [SerializeField]
    private Day ScriptableObject_Day;
    private bool isWeatherBad;


    void Start()
    {
        m_goDay = gameObject;
        Weather = transform.Find("Weather").GetComponent<Image>();
        SeasonEffect = transform.Find("SeasonEvent").GetComponent<Image>();
        dayText = transform.Find("Number").GetComponent<TextMeshProUGUI>();

        AssignDayByName();
        ConstructDay();
        dayText.text = day.ToString();

        SingletonTime.instance.dayChange.AddListener(OnDayChange);
        SingletonTime.instance.yearChange.AddListener(OnDayChange);
        SingletonTime.instance.yearChange.AddListener(OnYearChange);

        OnDayChange();
    }


    // Update is called once per frame
    void Update()
    {
        if (isCurrentDay())
        {
            dayText.color = Color.red;
        }
        else
        {
            dayText.color = Color.white;
        }
    }
    public void ConstructDay()
    {

        if(ScriptableObject_Day.chanceOfBadWather <= Random.Range(0, 100))
        {
            Weather.sprite = ScriptableObject_Day.Weather[0];
            isWeatherBad = false;
        }
        else
        {
            Weather.sprite = ScriptableObject_Day.Weather[1];
            isWeatherBad = true;
        }

        SeasonEffect.sprite = ScriptableObject_Day.SeasonEvent;

    }

    private void AssignDayByName()
    {
        //Default Name of the GameObj == Day (1);
        char[] chars = gameObject.name.ToCharArray();

        if(chars[6] == ')')
        {
            day = (int)char.GetNumericValue(chars[5]);
        }
        else
        {
            day = ((int)char.GetNumericValue(chars[5]) * 10 + (int)char.GetNumericValue(chars[6]));
        }
        
    }

    private bool isCurrentDay()
    {
           
        if (day == SingletonTime.instance.dias)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnDayChange()
    {
        if (isCurrentDay())
        {
            SingletonTime.instance.dayWeather_Event.Invoke(ScriptableObject_Day, isWeatherBad);
        }
    }

    public void OnYearChange()
    {
        ConstructDay();
    }
}
