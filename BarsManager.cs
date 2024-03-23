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

    private void getParentRotation()
    {
        Quaternion parentRot = gameObject.GetComponentInParent<Transform>().rotation = Quaternion.identity;

        posCos = Mathf.Cos(parentRot.z);
        posSin = Mathf.Sin(parentRot.z);

        Debug.Log(parentRot.z);
    }

    private void Update()
    {
        getParentRotation();

        transform.rotation = Quaternion.identity;
        //transform.localPosition = new Vector3(0, -posSin, 0);
        Debug.Log(posSin);
    }
}
