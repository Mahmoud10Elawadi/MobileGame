using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWallFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    float yOffset;
    void Start()
    {
        yOffset = transform.position.y - target.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.hasChanged)
        {
            var pos = transform.position;
            pos.y = target.position.y + yOffset;
            transform.position = pos;
        }
    }
}
