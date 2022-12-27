using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menumanagerMs : MonoBehaviour
{
    public GameObject dataBoard;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playButton()
    {
        SceneManager.LoadScene(1);
    }

    public void dataBoardButton()
       
    {
        DataManager.instance.LoadData();

        dataBoard.transform.GetChild(1).GetComponent<Text>().text ="total shoot bullet: " + DataManager.instance.totalShootBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = "total enemy kill: "+DataManager.instance.totalEnemyKill.ToString();
        dataBoard.SetActive(true);
    }

    public void exitButton()
    {
        dataBoard.SetActive(false);
    }
}
