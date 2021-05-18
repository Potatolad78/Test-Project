using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SaveandPause : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Menu;
    void Save()
    {
        using(var writer = new StreamWriter(File.Open("Save.txt", FileMode.Create)))
        {
            writer.WriteLine(Enemy.transform.position.x);
            writer.WriteLine(Enemy.transform.position.y);
            writer.WriteLine(Enemy.transform.position.z);
            writer.WriteLine(Enemy.transform.rotation.x);
            writer.WriteLine(Enemy.transform.rotation.y);
            writer.WriteLine(Enemy.transform.rotation.z);
            writer.WriteLine(Enemy.transform.rotation.w);
        }

    }
    void Load()
    {
       using(var reader = new StreamReader(File.Open("Save.txt", FileMode.Open)))
       {
            Enemy.transform.position = new Vector3(float.Parse(reader.ReadLine()),float.Parse(reader.ReadLine()),float.Parse(reader.ReadLine()));
            Enemy.transform.rotation = new Quaternion(float.Parse(reader.ReadLine()),float.Parse(reader.ReadLine()),float.Parse(reader.ReadLine()),float.Parse(reader.ReadLine()));
       } 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(!Menu.activeSelf);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Save();
        }
        if (Input.GetKey(KeyCode.E))
        {
            Load();
        }
    }
}
