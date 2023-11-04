using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private float SecondsToDestroy;

    public void showText(string Text)
    {
        if (floatingTextPrefab != null)
        {
            GameObject fltxt = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity); //I'm istantiating the text prefab in the location of the enemy
            fltxt.GetComponentInChildren<TextMeshProUGUI>().text = Text;
            Destroy(fltxt, SecondsToDestroy);
        }
    }

}
