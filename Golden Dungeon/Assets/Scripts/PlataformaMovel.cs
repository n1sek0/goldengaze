
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlataformaMovel : MonoBehaviour
{
    public float speed;
    public float moveTime;
    private float timer;
    public bool moveRight = true;

    private Transform platformTransform;

// Start is called before the first frame update
    void Start()
    {
        platformTransform = GetComponent<Transform>();
    }

// Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= moveTime)
        {
            moveRight = !moveRight;
            timer = 0f;
        }

        if (moveRight)
        {
            platformTransform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            platformTransform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
