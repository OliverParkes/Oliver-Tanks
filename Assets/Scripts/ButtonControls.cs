using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControls : MonoBehaviour
{
    public void m_PlayButton()
    {
        SceneManager.LoadScene(2);
    }

    public void m_controlButton()
    {
        SceneManager.LoadScene(1);
    }

    public void m_mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
