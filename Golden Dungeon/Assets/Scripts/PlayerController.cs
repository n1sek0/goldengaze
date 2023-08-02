using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int health = 1;
    private int currentLives;

    private void Start()
    {
        currentLives = health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(collision.transform.position.y + 1 > transform.position.y)
            {Damage(1);}
            else
            {
                var enemy = collision.gameObject.GetComponent<InimigoController>();
                enemy.Kill();
            }
        }
    }

    public void Damage(int damageAmount)
    {
        currentLives -= damageAmount;
        if (currentLives <= 0)
        {
            ResetScene();
        }
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


