using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Projectile_Script : MonoBehaviour
{
    public Text countText;
    public Text winText;
    private int count;

   
    void Start()
    {
        GameObject scoreGO = GameObject.Find("CountText");
        countText = scoreGO.GetComponent<Text>();
        

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 6)
        {
            winText.text = "You Win!";
        }

      

    }
}
