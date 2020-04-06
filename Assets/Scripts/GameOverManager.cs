using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviourPun
{

    [SerializeField] GameObject GameOverText;
    [SerializeField] GameObject canvas;
    private Text GOtext;

    // Start is called before the first frame update
    void Start()
    {
        GOtext = GameOverText.GetComponent<Text>();
    }

    void Update()
    {
        HandleInput();
    }

    public void SetGameOverText(string inputText)
    {
        GOtext.text = inputText;
    }
    
    public void SetCanvasActive()
    {
        canvas.SetActive(true);
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown("r"))
        {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LoadLevel("MainMenu");
        }
    }

}
