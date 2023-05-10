using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotsMenu : MonoBehaviour
{
   private SaveSlot[] saveSlots;    
    void Awake()
    {
        saveSlots = GetComponentsInChildren<SaveSlot>();
    
    }

    private void Start() {
        ActivateMenu();
    }

    public void ActivateMenu(){
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.Instance.GetAllProfilesGameData();

        foreach (SaveSlot saveSlot in saveSlots)
        {
            
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileID(), out profileData); 
            saveSlot.SetData(profileData);
        }
    }
}
