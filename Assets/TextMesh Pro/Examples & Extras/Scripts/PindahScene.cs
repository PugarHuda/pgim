using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void pindahScene(string Setting) {
SceneManager.LoadScene(Setting);
}
}
