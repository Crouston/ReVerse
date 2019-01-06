using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChooser : MonoBehaviour {

    public int sceneIndex = 0;

	public void OnCLick()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
