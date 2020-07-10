using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button btnJugar;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        btnJugar.onClick.AddListener(() => { StateController.LoadScene(StateController.State.Seleccion); });
    }
}
