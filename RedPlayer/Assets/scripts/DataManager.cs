using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private int Shootbullet;
    public int totalShootBullet;
    private int EnemyKill;
    public int totalEnemyKill;

    EasyFileSave myFile;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            starsProcces();
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ShootBullet { 
        get 
        { 
            return Shootbullet; 
        } 

        set
        {
            Shootbullet = value;
            GameObject.Find("shootBulletText").GetComponent<Text>().text = "SHOOT BULLET:" +Shootbullet.ToString();
        }
    }
    public int enemyKill
    {
        get
        {
            return EnemyKill;
        }  
        
        set 
        {
            EnemyKill = value;
            GameObject.Find("enemyKillText").GetComponent<Text>().text = "ENEMY KÝLLED:" + EnemyKill.ToString();
            winProcces();
        }
    }

    void starsProcces()
    {
        myFile=new EasyFileSave();
        LoadData();
    }

    public void SaveData()
    {
        totalShootBullet += Shootbullet;
        totalEnemyKill += EnemyKill;


        myFile.Add("totalShootBullet", totalShootBullet);
        myFile.Add("totalEnemyKill", totalEnemyKill);

        myFile.Save();
    }

    public void LoadData()
    {
        if (myFile.Load())
        {
            totalShootBullet = myFile.GetInt("totalShootBullet");
            totalEnemyKill = myFile.GetInt("totalEnemyKill");
        }
    }
    
    public void winProcces()
    {
        if (enemyKill >= 5)
        {
            print("KAZANDINIZ");
        }
    }

    public void loseProcces()
    {
        print("KAYBETTÝNÝZ");
    }










}
