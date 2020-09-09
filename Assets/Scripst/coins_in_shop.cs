using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins_in_shop : MonoBehaviour
{
     public UnityEngine.UI.Text coins_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ShowCoins(){
     coins_text.text =PlayerPrefs.GetInt("coins").ToString() + "  coins";
     }
}
