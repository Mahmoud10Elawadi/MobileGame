using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public Renderer renderObject;

    // Update is called once per frame
    void Update()
    {
        renderObject.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);
    }
}
