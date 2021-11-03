using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const string SaveFilename = "game.save";
    private static bool gameLoaded = false;
    GameObject bobBobski;
    GameObject saveGameButton;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objects = FindObjectsOfType<GameObject>();
        foreach(GameObject obj in objects)
        {
            if (obj.name == "Bob Bobski")
                bobBobski = obj;
            else if (obj.name == "SaveGameButton")
                saveGameButton = obj;
        }

        saveGameButton.GetComponent<Button>().onClick.AddListener(SaveGameState);
        LoadGameState();
    }

    public void SaveGameState()
    {
        string path = Path.Combine(Application.persistentDataPath, SaveFilename);
        StreamWriter sw = new StreamWriter(path);
        sw.WriteLine(DataSignifier.CharacterInfo + "," + 
            bobBobski.transform.position.x + "," + 
            bobBobski.transform.position.y);
        sw.Close();
    }

    public void LoadGameState()
    {
        if (gameLoaded)
            return;

        gameLoaded = true;
        string path = Path.Combine(Application.persistentDataPath, SaveFilename);
        if (!File.Exists(path))
        {
            Debug.LogWarning("Save file does not exist!");
            return;
        }

        StreamReader sr = new StreamReader(path);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] csv = line.Split(',');
            int dataSignifier = int.Parse(csv[0]);
            if (dataSignifier == DataSignifier.CharacterInfo)
            {
                Debug.Log("Setting char position!");
                float x_pos = float.Parse(csv[1]);
                float y_pos = float.Parse(csv[2]);
                bobBobski.gameObject.transform.position = new Vector3(x_pos, y_pos, 0);
            }
        }
        sr.Close();
    }
}

public static class DataSignifier
{
    public const int CharacterInfo = 0;
}
