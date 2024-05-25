using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_JoinGame : MonoBehaviour
{
    public void Continue() {

    }
    public void NewGame() {
        SceneManager.LoadScene(1);
    }
    public void Setting() {
        
    }
    public void ExitGame() {
        Application.Quit();
    }
}
