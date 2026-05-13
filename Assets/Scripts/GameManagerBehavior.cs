using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
    public Text goldLabel;
    int gold;

    public Text waveLabel;
    public GameObject[] nextWaveLabels;
    public bool gameOver = false;

    private int wave;

    public int Wave
    {
        get { return wave; }
        set
        {
            wave = value;
            if (!gameOver)
            {
                if (wave != 0 && wave != 4)
                {
                    for (int i = 0; i < nextWaveLabels.Length; i++)
                    {
                        nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                    }
                }
            }
            waveLabel.text = "WAVE: " + (Wave + 1);
        }
    }

    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "GOLD:" + gold;
        }
    }

    void Start()
    {
        spriteRenderer = Tower.GetComponent<SpriteRenderer>();
        Gold = 1000;
        Wave = 0;
        Health = 5;
    }

    public Text healthLabel;
    // public GameObject[] healthIndicator;
    public int health;

    public GameObject Tower;
    public Sprite health_4;
    public Sprite health_3;
    public Sprite health_2;
    public Sprite health_1;
    public Sprite health_0;

    private SpriteRenderer spriteRenderer;

    public int Health
    {
        get { return health; }
        set
        {
            if (value < health)
            {
                Camera.main.GetComponent<CameraShake>().Shake();
            }
            health = value;
            healthLabel.text = "HEALTH" + health;
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
                gameOverText.GetComponent<Animator>().SetBool("gameover", true);
            }

            if (Health == 4) spriteRenderer.sprite = health_4;
            if (Health == 3) spriteRenderer.sprite = health_3;
            if (Health == 2) spriteRenderer.sprite = health_2;
            if (Health == 1) spriteRenderer.sprite = health_1;
            if (Health == 0) spriteRenderer.sprite = health_0;
        }
    }
}
