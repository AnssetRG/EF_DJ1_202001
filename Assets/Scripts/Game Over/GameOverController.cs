using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Text score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + PlayerPrefs.GetInt("score", 0).ToString();
        StartCoroutine(WaitToMenu());
    }

    IEnumerator WaitToMenu()
    {
        yield return new WaitForSeconds(3);
        StateController.LoadScene(StateController.State.Menu);
    }
}
