using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Day", menuName = "Day", order = 1)]
public class Day : ScriptableObject
{
    public SingletonTime.Seasons Season;
    public Sprite SeasonEvent;
    public Sprite[] Weather;

    [Range(0, 100)]
    public int chanceOfBadWather;

}
