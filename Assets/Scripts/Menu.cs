using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    #region Variables

    public GameObject[] enableOnPause;
    public List<GameObject> disableOnResume;
    #endregion
    #region Unity Functions
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 
            || SceneManager.GetActiveScene().name == "GameOver")
        {
            //We are in the main menu
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            //We are not in the main menu
            Resume();
        }

        Time.timeScale = 1;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    #endregion
    #region Navigation buttons
    public void Pause()
    {
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        // for each loop, loop once for every "element" (everything) in the array/list
        foreach(GameObject go in enableOnPause)
        {
            go.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //How to add to a list example
        //disableOnResume.Add(gameObject);

        // arrays and lists start counting from 0
        // 0, 1, 2  = Count is 3

        // for arrays count is enableOnPause.Length

        for (int i = 0; i < disableOnResume.Count; i++)
        {
            disableOnResume[i].SetActive(false);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Marble");
    }

    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    #endregion

    #region Options

    public void ToggleFullScreen(bool isTicked)
    {
        Screen.fullScreen = isTicked;
        Debug.Log("Changed to fullscreen " + Screen.fullScreen);
    }

    #endregion
}
