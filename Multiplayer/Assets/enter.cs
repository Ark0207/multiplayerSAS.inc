using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enter : MonoBehaviour
{
    
    //public Light mydirectionalLight;
    public string sceneToLoad = "game";
    public float newIntensity;
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void entergame()
    {
        
    }
    public void NightMode()
    {
        Debug.Log("Night");
        newIntensity = 0.05f;
        StartCoroutine(LoadSceneAndChangeLightIntensity(sceneToLoad, newIntensity));
    }
    public void DayMode()
    {
        newIntensity = 1f;
        StartCoroutine(LoadSceneAndChangeLightIntensity(sceneToLoad, newIntensity));
        Debug.Log("day");
    }
   IEnumerator LoadSceneAndChangeLightIntensity(string sceneName,float newIntensity)
    {
        Debug.Log("thishellmachineworks" + sceneToLoad);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        
        while(!asyncLoad.isDone)
        {
            Debug.Log("Loading-----");
            yield return null;
        }
        
        Debug.Log("loaded");
        yield return new WaitForSeconds(1f);
        Light[] Lights = FindObjectsOfType<Light>();
        foreach (Light light in Lights)
        {     
            if (light.type == LightType.Directional)
            {
                Debug.Log("Light has found");
                light.intensity = newIntensity;
            }
        }
    }

   
}