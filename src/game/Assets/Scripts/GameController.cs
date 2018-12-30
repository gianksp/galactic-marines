using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static int score = 0;
    public static bool over = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public static void AddScore() {
        score++;
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 200, 50), "Score: "+score);

        if (over){
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 10, 300, 50), "Game Over: try again (last score " + score + ")"))
            {
                SceneManager.LoadScene("Main");
                over = false;
                score = 0;
            }
        }
    }
}
