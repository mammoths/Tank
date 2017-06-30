using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankControllerDebug : MonoBehaviour
{
    public KeyCode launchkey; 
    public Slider sliderMoveFB;
    public Slider sliderTurnLR;
    public Slider sliderTurretLR;
    public Slider sliderTurretUD;

    public Tank tank;

    // Update is called once per frame
    void Update()
    {

       if (Input.GetKeyDown(launchkey))
        {
            tank.LaunchBullet();
        }

    }

    private float GetIntensity(Slider slider)
    {
        return Mathf.Lerp(-1, 1, slider.value);
    }
}
