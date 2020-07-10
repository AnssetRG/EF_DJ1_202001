using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionController : MonoBehaviour
{
    [SerializeField]
    private Button btnNormal;

    [SerializeField]
    private Button btnParao;
    // Start is called before the first frame update
    void Start()
    {
        btnNormal.onClick.AddListener(() => SetLifes(4));
        btnParao.onClick.AddListener(() => SetLifes(1));
    }

    void SetLifes(int lifes)
    {
        PlayerPrefs.SetInt("HP", lifes);
        StateController.LoadScene(StateController.State.Game);
    }
}
