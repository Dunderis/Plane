using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 2;

    private void Start()
    {
        var pos = transform.position;
        pos.y += Random.Range(-3, 3f);
        transform.position = pos;
    }
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
