using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectskins : MonoBehaviour
{public GameObject[] heroes;

    // Start is called before the first frame update
    void Start()

    {
        heroes[PlayerPrefs.GetInt("selected_hero")].SetActive(true);
        
    }

    // Update is called once per frame
 public void Selectskin()

    {   foreach (GameObject i in heroes )

        
    {
       i.SetActive(false); 
    }      
        heroes[PlayerPrefs.GetInt("selected_hero")].SetActive(true);
        
    }
}
