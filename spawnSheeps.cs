using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class spawnSheeps : MonoBehaviour
{
    SpriteRenderer sheepSpawner;
    public GameObject sheeps, hb;
    public float Cooldown;

    private float NextSheep = 2;

    // Start is called before the first frame update
    void Start()
    {
        sheepSpawner = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > NextSheep)
        {
            NextSheep = Time.time + Cooldown;
            GameObject newSheep = Instantiate(sheeps, sheepSpawner.transform.position, Quaternion.identity); //I'm creating a new GameObject so i can change the script on it
            GameObject newSheep_HP = Instantiate(hb, newSheep.transform.position, Quaternion.identity); //I'm creating a HP bar too

            newSheep_HP.GetComponent<BarsManager>().parent = newSheep;
            newSheep.tag = "Fighter";
            newSheep.GetComponent<Health>().hp_bar = newSheep_HP;
        }
    }
}
