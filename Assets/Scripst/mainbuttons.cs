
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainbuttons : MonoBehaviour
{   public GameObject about;
    public GameObject settings;
    public GameObject shop;
    public GameObject leaderboard;
  
    public UnityEngine.UI.Text red_skin;
    public UnityEngine.UI.Text black_skin;
    public UnityEngine.UI.Text white_skin;
    public UnityEngine.UI.Text neon_skin;
     public UnityEngine.UI.Text coin_multi;


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
 if (PlayerPrefs.GetInt("red")==0){
   red_skin.text="Red master 100 coins";}
   else
   {
       red_skin.text="Red master";
   }
   if (PlayerPrefs.GetInt("black")==0){
   black_skin.text="Black master 1000 coins";}
   else
   {
       black_skin.text="Black master";
   }
   if (PlayerPrefs.GetInt("white")==0){
   white_skin.text="White master 1000 coins";}
   else
   {
       white_skin.text="White master";
   }
   if (PlayerPrefs.GetInt("neon")==0){
   neon_skin.text="Neon purple master 10000 coins";}
   else
   {
       neon_skin.text="Neon purple master";
   }
  coin_multi.text="Total coin multiplier: "+PlayerPrefs.GetInt("multi").ToString()+" X";

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