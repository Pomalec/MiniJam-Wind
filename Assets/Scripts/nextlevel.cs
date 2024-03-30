using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour
{
    public int sceneBuildIndex;


    private void OnTriggerEnter2D(Collider2D other){
         
         if(other.tag == "Player"){
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
         }
    }
}
