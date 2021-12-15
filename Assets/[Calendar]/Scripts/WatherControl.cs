using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WatherControl : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem snowParticles;
    [SerializeField]
    private ParticleSystem rainParticles;
    [SerializeField]
    private Light2D light;
    [SerializeField]
    private AudioSource[] audioList;

    //Light
    private Color initialColor;
    private float initialIntensity;


    // Start is called before the first frame update
    void Start()
    {
        SingletonTime.instance.dayWeather_Event.AddListener(OnWeatherChange);

        snowParticles.Stop();
        rainParticles.Stop();

        initialColor = light.color;
        initialIntensity = light.intensity;

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnWeatherChange(Day day, bool isWeatherBad)
    {
        snowParticles.Stop();
        rainParticles.Stop();

        light.color = initialColor;
        light.intensity = initialIntensity;
        foreach(var audio in audioList)
        {
            audio.Stop();
        }

        switch (day.Season)
        {
            case SingletonTime.Seasons.SPRING:

                if (isWeatherBad)
                {
                    rainParticles.Play();
                }

                break;

            case SingletonTime.Seasons.SUMMER:

                if (isWeatherBad)
                {
                    rainParticles.Play();
                }

                break;

            case SingletonTime.Seasons.SUMMER_SOLSTICE:

                light.intensity = 1;
                light.color = new Color(0.79f,0.70f,0.60f,1); //Sepia color
                

                break;

            case SingletonTime.Seasons.FALL:

                if (isWeatherBad)
                {
                    rainParticles.Play();
                }
        
                break;

            case SingletonTime.Seasons.SPOOKYDAY:

                if (isWeatherBad)
                {
                    rainParticles.Play();
                }

                light.intensity = 0.5f;
                light.color = Color.blue;

                break;

            case SingletonTime.Seasons.WINTER:

                if (isWeatherBad)
                {
                    rainParticles.Play();
                }
      
                break;

            case SingletonTime.Seasons.SNOWY:

                if (isWeatherBad)
                {
                    snowParticles.Play();
                    audioList[1].Play();
                }
            
                break;

            case SingletonTime.Seasons.NEW_YEAR:

                if (isWeatherBad)
                {
                    snowParticles.Play();
                }

                audioList[0].Play();

                break;

        }
    }
}
