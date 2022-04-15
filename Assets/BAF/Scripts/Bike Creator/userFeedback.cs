using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class userFeedback : MonoBehaviour
{

    [SerializeField] GameObject container;
    bool active;
    
    // Start is called before the first frame update
    void Start()
    {
        //Open();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape) && active) Close();
        //else if(Input.GetKeyDown(KeyCode.Escape) && !active) Open();
    }

    void Open()
    {
        active = true;
        container.SetActive(true);
    }

    public void Close()
    {
        active = false;
        container.SetActive(false);
    }

    public void Quiter()
    {
        Application.Quit();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
