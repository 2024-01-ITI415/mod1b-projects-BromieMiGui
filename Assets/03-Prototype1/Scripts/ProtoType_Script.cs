using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Gamemode
{
    idle,
    playing,
    levelEnd
}
public class ProtoType_Script : MonoBehaviour
{
    [Header("Set in Inspector")]
    static private ProtoType_Script S;
    public Text uitLevel;
    public Text uitShots;
    public Text uitButton;
    public Vector3 PostPos;
    public GameObject[] Posts;

    [Header("Set Dynamically")]
    public int level;
    public int levelMax;
    public int shotsTaken;
    public GameObject Post;
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot";
    // Start is called before the first frame update
    void Start()
    {
        S = this;
        level = 0;
        levelMax = Posts.Length;
        StartLevel();
    }
    void StartLevel()
    {
        if (Post != null)
        {
            Destroy(Post);
        }
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }
        Post = Instantiate<GameObject>(Posts[level]);
        Post.transform.position = PostPos;
        shotsTaken = 0;
        SwitchView("wShow Both");
        ProjectileLine.S.Clear();
        Goal.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }
    void UpdateGUI()
    {
        uitLevel.text = "Level:" + (level + 1) + "of" + levelMax;
        uitShots.text = "Shots Taken:" + shotsTaken;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateGUI();
        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            mode = GameMode.levelEnd;
            SwitchView("Show Both");
            Invoke("NextLevel", 2f);
        }
    }
    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }
    public void SwitchView(string eView = "")
    {
        if (eView == "")
        {
            eView = uitButton.text;
        }
        showing = eView;
        switch (showing)
        {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Both";
                break;
            case "Show Castle":
                FollowCam.POI = S.Post;
                uitButton.text = "Show Both";
                break;
            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;


        }
    }
    public static void ShotFired()
    {
        S.shotsTaken++;
    }


}
