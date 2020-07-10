using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    private GameObject[] enemiesPrefabs;
    private Queue<int> times = new Queue<int>();
    private Queue<int> enemies = new Queue<int>();
    public int actual_time = 0;
    public int actual_enemies = 0;
    private int score = 0;
    public Text txtScore;
    private int hp = 0;
    public Text txtHP;
    private float time_enlapsed = 0;
    public Text txtTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        hp = PlayerPrefs.GetInt("HP", 0);
    }

    private void Start()
    {
        //First Wave
        times.Enqueue(8);
        enemies.Enqueue(4);
        //Second Wave
        times.Enqueue(6);
        enemies.Enqueue(8);
        //Third Wave
        times.Enqueue(4);
        enemies.Enqueue(16);
        //Forth Wave
        times.Enqueue(3);
        enemies.Enqueue(32);
        //Fifth Wave
        times.Enqueue(2);
        enemies.Enqueue(64);

        txtScore.text = "Score: " + score.ToString();
        txtHP.text = "HP: " + hp.ToString();

        GetWave();
    }

    void Update()
    {
        time_enlapsed += Time.deltaTime;
        if (time_enlapsed >= actual_time)
        {
            if (actual_enemies == 0) GetWave();

            Instantiate(enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length - enemies.Count)], Vector3.zero, Quaternion.identity);
            actual_enemies--;
            time_enlapsed = 0;
        }
        txtTime.text = time_enlapsed.ToString("f2");
    }

    void GetWave()
    {
        if (times.Count == 0)
        {
            PlayerPrefs.SetInt("Score", score);
            StateController.LoadScene(StateController.State.GameOver);
        }
        else
        {
            actual_time = times.Dequeue();
            actual_enemies = enemies.Dequeue();
        }
    }

    public void RestLife()
    {
        hp--;
        txtHP.text = "HP: " + hp.ToString();
        if (hp <= 0)
        {
            PlayerPrefs.SetInt("Score", score);
            StateController.LoadScene(StateController.State.GameOver);
        }
    }

    public void GainPoints(int points)
    {
        score += points;
        txtScore.text = "Score: " + score.ToString();
    }
}
