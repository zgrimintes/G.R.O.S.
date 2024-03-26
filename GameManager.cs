using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int sheep_count, sheep_killed;

    public GameObject kill_counter;

    private void Start()
    {
        instance = this;
    }

    public void sheep_mod(int op)
    {
        sheep_count += op;
    }

    public void kill()
    {
        sheep_killed++;
        kill_counter.GetComponent<TextMeshProUGUI>().text = "Sheep killed: " + sheep_killed;
    }
}
