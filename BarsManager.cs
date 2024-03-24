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

    private void getRot()
    {
        float rotz = GetComponentInParent<Transform>().localRotation.z;

        posCos = Mathf.Cos(rotz);
        posSin = Mathf.Sin(rotz);

        Debug.Log(rotz);
    }

    private void Update()
    {
        getRot();

        transform.rotation = Quaternion.identity;
        //transform.localPosition = new Vector3 (0, GetComponentInParent<Transform>().localRotation.z, 0);
    }
}