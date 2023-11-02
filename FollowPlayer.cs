using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject toFollow;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y ,-10);
    }
}
