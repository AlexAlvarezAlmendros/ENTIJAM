using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameController : MonoBehaviour
{
    public int lives;
    public int hiscore;
    public static GameController Instance { get; private set; }
    

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //AudioManager.Instance.Play(GameMusic);
        StreamReader reader = new StreamReader("Hiscore.txt");
        string hiscorestring = reader.ReadLine();
        hiscore = int.Parse(hiscorestring);
        reader.Close();
        BeginGame();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void BeginGame()
    {

    }

    public void DecrementLives()
    {
        lives--;

        // Has player run out of lives?
        if (lives < 1)
        {
            SceneManager.LoadScene("Game_Over");
            // Restart the game
            BeginGame();
        }
    }
}
    