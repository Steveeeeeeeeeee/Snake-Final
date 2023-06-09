using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update
    [SerializeField] public string ID;
    public bool isUnlocked = false;

    public Image image;

    public Achievement(string ID, bool isUnlocked)
    {
        this.ID = ID;
        this.isUnlocked = isUnlocked;
    }


    [ContextMenu("Generate guid for ID")]

    private void GenerateGuid()
    {
        ID = System.Guid.NewGuid().ToString();
    }

    public class Test : MonoBehaviour
    {
        // Start is called before the first frame update

    }

    public void LoadData(GameData data)
    {
        data.achievements.TryGetValue(ID, out isUnlocked);



        if (isUnlocked)
        {

            image = GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            Debug.Log("Achievement " + ID + " is unlocked");

        }
    }

    public void SaveData(ref GameData data)
    {

        if (data.achievements.ContainsKey(ID))
        {
            data.achievements.Remove(ID);
        }
        data.achievements.Add(ID, isUnlocked);
    }


}
