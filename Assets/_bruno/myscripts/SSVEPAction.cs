using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class SSVEPAction : MonoBehaviour
{
    //GameObject Apagar el flicker
    public GameObject flick;
    public GameObject img;

    public GameObject flick2;
    public GameObject img2;
    public void ActivateImage()
    {

        //flckr = GetObject<Light1fgfgf>;

        //flckr = GetObject<Light1>;

        flick.SetActive(false);
        img.SetActive(true);

        //SceneManager.LoadScene(scenename);

    }

    public void ActivateImage2()
    {

        //flckr = GetObject<Light1fgfgf>;

        //flckr = GetObject<Light1>;

        flick2.SetActive(false);
        img2.SetActive(true);

        //SceneManager.LoadScene(scenename);

    }
}
