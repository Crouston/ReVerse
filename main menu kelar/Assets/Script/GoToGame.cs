using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour {

    void PlayGame()
    {
        SceneManager.LoadScene("tes");
    }
	// Use this for initialization
	void Start () {
        Invoke("PlayGame", 2 * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
