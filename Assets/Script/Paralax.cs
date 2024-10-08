using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private Renderer renderer;
    private Vector2 offset;
    public float speed = 0.5f;
    void Start()
    {
        renderer = GetComponent<Renderer> ();
        offset = renderer.material.mainTextureOffset;
    }

       void Update()
    {
        offset.x += speed * Time.deltaTime;
        renderer.material.mainTextureOffset = offset;
    }
}
