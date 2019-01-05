using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

     
    public bool gameover = false;

    public GameObject gameoverUI;
    public GameObject completeUI;
	
    public void StopGame()
    {
        gameover = true;
        gameObject.SetActive(false);
        Invoke("BackToMenu", 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Water")
        {
            gameoverUI.SetActive(true);
            StopGame();
        }
        else if(collision.tag == "Ending")
        {
            completeUI.SetActive(true);
            StopGame();
        }
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
