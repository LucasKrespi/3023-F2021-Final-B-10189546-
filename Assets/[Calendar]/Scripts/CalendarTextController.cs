using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalendarTextController : MonoBehaviour
{
    private TextMeshProUGUI clockText;
    private TextMeshProUGUI dateText;
    private SingletonTime singletonTimeInstance;

    // Start is called before the first frame update
    void Start()
    {
        dateText = transform.Find("Calendar/DateText").GetComponent<TextMeshProUGUI>();
        clockText = transform.Find("Time/TimeText").GetComponent<TextMeshProUGUI>();
        singletonTimeInstance = SingletonTime.instance;
    }

    // Update is called once per frame
    void Update()
    {
        clockText.text = "Time: " + singletonTimeInstance.hours.ToString() + ":" + singletonTimeInstance.minutes.ToString();
        dateText.text = "Date: " + singletonTimeInstance.days.ToString() + "/" + singletonTimeInstance.weeks.ToString() + "/" + singletonTimeInstance.years.ToString();
    }
}
