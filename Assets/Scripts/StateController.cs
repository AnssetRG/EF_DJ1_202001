using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StateController
{
    public enum State { Menu, Seleccion, Game, GameOver };
    public static void LoadScene(State state_to_load)
    {
        Debug.Log(state_to_load.ToString());
        SceneManager.LoadScene(state_to_load.ToString());
    }
}