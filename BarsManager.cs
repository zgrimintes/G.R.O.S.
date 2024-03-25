using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsManager : MonoBehaviour
{
    public Slider healthBarSlider;

    float posCos, posSin;

    public void setMaxValue(float value)
    {
        healthBarSlider.maxValue = value;
        healthBarSlider.value = value;
    }

    public void setValue(float value)
    {
        healthBarSlider.value = value;
    }

}