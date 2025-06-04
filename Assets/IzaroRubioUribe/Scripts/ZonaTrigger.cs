
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZonaTrigger : MonoBehaviour
{
    public GameObject uiMessage;
    public string sceneToLoad;

    private void Start()
    {
        uiMessage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        uiMessage.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        uiMessage.SetActive(false);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

