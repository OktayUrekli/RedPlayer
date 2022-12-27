using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyManager : MonoBehaviour
{
    public float health;
    public float damage;
    bool colliderBusy = false;

    public Slider slider;
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            other.GetComponent<playerManager>().getDamage(damage);
        }
        else if (other.tag == "Bullet")
        {
            getDamage(other.GetComponent<bulletManager>().bulletDamage);
            Destroy (other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            colliderBusy=false;
        }
    }

    public void getDamage(float damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        amIDead();

    }


    public void amIDead()
    {
        if (health == 0)
        {
            DataManager.instance.enemyKill++;
            Destroy(gameObject);
        }
    }
}
