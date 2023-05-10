using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileID;

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;

    [SerializeField] private TextMeshProUGUI profileIDText;
    [SerializeField] private TextMeshProUGUI levelsCompleted;



    public void SetData(GameData data)
    {

        if (data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);

            levelsCompleted.text =  data.MaxLevel + "/5";
        }
    }


    public string GetProfileID()
    {
        return this.profileID;
    }

}
