using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class arrow : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (gameObject.name == "arrowLeft")
        { SceneManager.LoadScene("MenuSelect"); }
        if (gameObject.name == "arrowRight")
        { SceneManager.LoadScene("MenuSelect2"); }
    }
    
}
