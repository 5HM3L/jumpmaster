using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buy_items : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      //  PlayerPrefs.SetInt("coins",10000000);
        // PlayerPrefs.SetInt("red",0);
        // PlayerPrefs.SetInt("neon",0);
        // PlayerPrefs.SetInt("white",0);
        // PlayerPrefs.SetInt("black",0);
      //  PlayerPrefs.SetInt("multi",0);
    }

    // Update is called once per frame
    public void Green_master()
    {
      PlayerPrefs.SetInt("selected_hero",0);
    }

    public void Red_master(){
     if (PlayerPrefs.GetInt("red")==0){
    if (PlayerPrefs.GetInt("coins")>99){
      PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")-100);
       PlayerPrefs.SetInt("selected_hero",1);
        PlayerPrefs.SetInt("red",1);}};
    if (PlayerPrefs.GetInt("red")==1){PlayerPrefs.SetInt("selected_hero",1);}
       }
    public void Black_master(){
       if (PlayerPrefs.GetInt("black")==0){
        if (PlayerPrefs.GetInt("coins")>999){
      PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")-1000);
       PlayerPrefs.SetInt("selected_hero",2);
       PlayerPrefs.SetInt("black",1);
        }
       
    };
     if (PlayerPrefs.GetInt("black")==1){PlayerPrefs.SetInt("selected_hero",2);}
    }
    public void White_master(){
    if (PlayerPrefs.GetInt("white")==0){
       if (PlayerPrefs.GetInt("coins")>999){
      PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")-1000);
       PlayerPrefs.SetInt("selected_hero",3);
       PlayerPrefs.SetInt("white",1);}}
    if (PlayerPrefs.GetInt("white")==1){PlayerPrefs.SetInt("selected_hero",3);}
    }
    public void Neon_master(){
        if (PlayerPrefs.GetInt("neon")==0){
       if (PlayerPrefs.GetInt("coins")>9999){
      PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")-10000);
       PlayerPrefs.SetInt("selected_hero",4);
        PlayerPrefs.SetInt("neon",1);}};
    if (PlayerPrefs.GetInt("neon")==1){PlayerPrefs.SetInt("selected_hero",4);}

    }
    public void buyx2m(){
       if (PlayerPrefs.GetInt("coins")>499){
      if (PlayerPrefs.GetInt("multi")== 0 ){
        PlayerPrefs.SetInt("multi",2);
      }
      else {PlayerPrefs.SetInt("multi",PlayerPrefs.GetInt("multi")*2);}
    }}

    public void buyx4m(){
       if (PlayerPrefs.GetInt("coins")>999){
      if (PlayerPrefs.GetInt("multi")== 0 ){
        PlayerPrefs.SetInt("multi",4);
      }
      else {PlayerPrefs.SetInt("multi",PlayerPrefs.GetInt("multi")*4);}
    }}

    public void buyx8m(){
       if (PlayerPrefs.GetInt("coins")>2999){
      if (PlayerPrefs.GetInt("multi")== 0 ){
        PlayerPrefs.SetInt("multi",8);
      }
      else {PlayerPrefs.SetInt("multi",PlayerPrefs.GetInt("multi")*8);}
    }}
}
