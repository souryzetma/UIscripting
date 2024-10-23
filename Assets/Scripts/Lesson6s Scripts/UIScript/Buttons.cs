using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Button pauseButton;
    [SerializeField]
    Button resumeButton;
    [SerializeField]
    Button retryButton;
    [SerializeField]
    Canvas mainCanvas;
    [SerializeField]
    Canvas pauseCanvas;
    private void Awake()
    {
        pauseCanvas.gameObject.SetActive(false);
    }
    void Start()
    {
        pauseButton.onClick.AddListener(OnPause);
        resumeButton.onClick.AddListener(Continue);
        retryButton.onClick.AddListener(ReStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
    void Continue()
    {
        Time.timeScale = 1.0f;
        mainCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
    }
    void OnPause()
    {
        Time.timeScale = 0f;
        mainCanvas.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(true);
    }

}
