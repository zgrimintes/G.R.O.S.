using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int sheep_count, sheep_killed;

    private void Start()
    {
        instance = this;
    }

    public void sheep_mod(int op)
    {
        sheep_count += op;
    }
}
