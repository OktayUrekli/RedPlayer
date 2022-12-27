using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class playerManager : MonoBehaviour
{
    public float health;
    bool dead = false;

    public float bulletSpeed;

    public Slider sliderPHB;

    Transform muzzle;

    bool mouseIsNotOverUI;
    public Transform bullet,floatingText,bloodParticle;
    private void Start()
    {
        muzzle = transform.GetChild(1);
        sliderPHB.maxValue = health;
        sliderPHB.value = health;
    }

    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;



        if (Input.GetMouseButtonDown(0) &&mouseIsNotOverUI) // index 0 sol yuþ demek
        {
            shootBullet();
        }
    }

    public void getDamage(float damage)
    {
        Instantiate(floatingText,transform.position,Quaternion.identity).GetComponent<TextMesh>().text=damage.ToString();

        if(health - damage> 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        sliderPHB.value=health;
        amIDead();

    }


    public void amIDead()
    {
        if (health == 0)
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity),3f);
            DataManager.instance.loseProcces();
            dead = true;
            Destroy(gameObject);
        }
    }

    void shootBullet()
    {

        Transform tempBullet;
        tempBullet= Instantiate(bullet,muzzle.position,Quaternion.identity);

        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward*bulletSpeed);
        DataManager.instance.ShootBullet++;
    }

}
