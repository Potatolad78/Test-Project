using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuContinue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(ContinueClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ContinueClick()
    {
        Debug.Log("This is a sign.");
        SceneManager.LoadScene("TestScene");
    }
}
