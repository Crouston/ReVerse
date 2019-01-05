using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {

    public GameObject water;
    private float cooldown;
	// Use this for initialization
	void Start () {
        cooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
        cooldown -= Time.deltaTime;
		if(Input.GetKeyDown("z")&& cooldown <= 0)
        {
            See();
            cooldown = 5f;
        }
	}

    private void See()
    {
        water.SetActive(true);
        Invoke("Hidden", 2f);
    }

    private void Hidden()
    {
        water.SetActive(false);
        CancelInvoke();
    }
}
