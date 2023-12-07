using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public string SceneName;
    public string currentScene;
    
    Renderer ren;

    void Start()
    {
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            Debug.Log("z pressed");
            StartCoroutine(ChangeScene());
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
            SceneManager.UnloadScene(currentScene);
        }
    }

    IEnumerator ChangeScene()
    {
        
        
        

        yield return new WaitForSeconds(2f);


        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
}
