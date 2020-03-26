using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public int hp;
    public int mp;
    public GameObject hpBar;
    public GameObject mpBar;

    public GameObject[] nextButtons;
    public GameObject nextDialogue;


    private void Awake()
    {
        hpBar = GameObject.Find("HPbar");
        mpBar = GameObject.Find("MPbar");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getHp()
    {
        return hp;
    }

    public int getMp()
    {
        return mp;
    }

    public void AdjustHp()
    {
        hpBar.GetComponent<HPControl>().AddHP(hp);
        Debug.Log("Add" + hp);
    }

    public void AdjustMp()
    {
        mpBar.GetComponent<MPControl>().AddMP(mp);
        Debug.Log("Add" + mp);
    }

    public GameObject[] GetNextButtons()
    {
        return nextButtons;
    }

    public GameObject GetNextDialogue()
    {
        return nextDialogue;
    }
}
