using UnityEngine;
using System.Collections;
public class PlayerHealthy : MonoBehaviour {
 public int maxHealthy=100;
 public int currHealthy=100;
 
 public float currentHealth;

	private float i = 0.1f;
 
 // Use this for initialization
 void Start () {
  currentHealth=Screen.width/2;
 }
 
 // Update is called once per frame
 void Update () {
  //AddCurrentHealth(0);
		i = i+ 0.1f;
		AddCurrentHealth(i);
 }
 
 void OnGUI(){
  GUI.Box(new Rect(10,10,currentHealth,20),currHealthy+"/"+maxHealthy);
 }
 
 public void AddCurrentHealth(float health){
		currHealthy+=(int)health;
  
  if(currHealthy<0)
   currHealthy=0;
  if(currHealthy>maxHealthy)
   currHealthy=maxHealthy;
  if(maxHealthy<1)
   maxHealthy=1;
  currentHealth=(Screen.width/2)*(currHealthy/(float)maxHealthy);
 }
}