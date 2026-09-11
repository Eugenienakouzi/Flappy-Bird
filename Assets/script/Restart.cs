using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Restart : MonoBehaviour
{
    public GameObject restart;
    public GameObject Button_restart;
    public GameObject gameover;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
       
    }

    public void OnButtonClick()
    {
        // Réactiver le mouvement de l'oiseau
        restart.GetComponent<JumpBird>().play = true;
        restart.GetComponent<Rigidbody2D>().gravityScale = 1f;
        restart.GetComponent<JumpBird>().score = 0;
        gameover.SetActive(false);
        Button_restart.SetActive(false);





    }

}
