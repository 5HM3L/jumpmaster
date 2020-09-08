﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{public GameObject menu;
public GameObject pausebtn;


      void Start(){
         
      }
         public void block2(){
        pausebtn.SetActive(true);
        Time.timeScale = 0;
        
         }
         public void resume2(){

        Time.timeScale = 1f;
         pausebtn.SetActive(false);
         }
      
           
}