using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdatePlayerText : MonoBehaviour
{

    public TMP_Text playerText;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    public void UpdateText()
    {
        playerText.text = "Player " + MainMenu.selectedPlayer;
    }
}
