using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Button ExitButton;
    private void Start()
    {
        ExitButton.onClick.AddListener(OnExitButtonClicked);
    }
    
    private void OnExitButtonClicked()
    {
        //ApllicationQuiteService.Quit();
        SceneManager.LoadScene(SceneName.Start);
    }
}
