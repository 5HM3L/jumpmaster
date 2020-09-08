
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainbuttons : MonoBehaviour
{   public GameObject about;
    public GameObject settings;
    public GameObject shop;
    public GameObject leaderboard;


      void Start(){
         
      }
         public void About(){
 about.SetActive(true);
   }
    public void AboutOff(){
 about.SetActive(false);
   }

   public void Settings(){
 settings.SetActive(true);
   }
    public void SettingsOff(){
 settings.SetActive(false);
   }

   public void Shop(){
 shop.SetActive(true);
   }
     public void ShopOff(){
 shop.SetActive(false);
   }

   public void Leaderboard(){
 leaderboard.SetActive(true);
   }
   public void LeaderboardOff(){
 leaderboard.SetActive(false);
   }
      
           
}