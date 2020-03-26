using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class steamVRtest : MonoBehaviour
{
    public PanelManager panelManager;
    public SoundManager soundManager;

    public AudioClip selectAudio;
    public AudioClip chooseAudio;
    public AudioClip replyAudio;

    public SteamVR_Action_Boolean left;
    public SteamVR_Action_Boolean right;

    public GameObject[] currentButtons;
    private GameObject currentDialog;

    private int currentBtnIndex;
    private int currentDiaIndex;

    private int currentBtnLength;

    private int btnStageCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        soundManager.PlayOpening();
        currentBtnIndex = 0;
        currentDiaIndex = 0;
        currentBtnLength = 3;
        btnStageCnt = 0;
        foreach (GameObject btn in currentButtons)
            btn.SetActive(false);
        StartCoroutine("FirstShowBtn");
    }

    // Update is called once per frame
    void Update()
    {

        bool leftBool = left.GetStateDown(SteamVR_Input_Sources.Any);
        bool rightBool = right.GetStateDown(SteamVR_Input_Sources.Any);
        currentButtons[currentBtnIndex].GetComponent<Button>().Select();
        if (isEnding)
        {
            StartCoroutine(EndInfo());
        }
        else
        {
            if (leftBool)
            {
                currentBtnIndex++;
                currentBtnIndex %= currentBtnLength;
                this.GetComponent<AudioSource>().clip = selectAudio;
                this.GetComponent<AudioSource>().Play(0);
            }

            if (rightBool && !isEnding)
            {
                Button b = currentButtons[currentBtnIndex].GetComponent<Button>();
                b.onClick.Invoke();
                this.GetComponent<AudioSource>().clip = chooseAudio;
                this.GetComponent<AudioSource>().Play(0);
                HideCurrentDialogue();
                StartCoroutine(ShowReply());
                HideCurrentButton();
                StartCoroutine(ShowButton());
                btnStageCnt++;

            }
        } 


    }

    IEnumerator EndInfo()
    {
        soundManager.PlayEnding();
        panelManager.ShowEnding();
        yield return new WaitForSeconds(5);
        Application.Quit();
    }

    IEnumerator ShowReply()
    {
        yield return new WaitForSeconds(1.0f);
        if (isEnding)
            yield return null;
        this.GetComponent<AudioSource>().clip = replyAudio;
        this.GetComponent<AudioSource>().Play(0);
        yield return new WaitForSeconds(0.5f);
        ShowNextDialogue();
    }

    IEnumerator ShowButton()
    {
        yield return new WaitForSeconds(3);
        ShowNextButton();
        currentBtnIndex = 0;
    }
    //after closing panel and show first three buttons
    IEnumerator FirstShowBtn()
    {

        yield return new WaitForSeconds(15);
        soundManager.PlayInGame();
        yield return new WaitForSeconds(7);
        foreach (GameObject btn in currentButtons)
            btn.SetActive(true);
        currentButtons[0].GetComponent<Button>().Select();
        
    }

    private bool isEnding
    {
        get 
        {
            if (btnStageCnt >= 3)
                return true;
            return false;
        }
    }

    private void HideCurrentButton()
    {
        foreach (GameObject b in currentButtons)
        {
            b.SetActive(false);
        }
    }

    private void ShowNextButton()
    {
        GameObject nowBtn = currentButtons[currentBtnIndex];
        GameObject[] nextButtons = nowBtn.GetComponent<ButtonBehavior>().GetNextButtons();
        currentBtnLength = nextButtons.Length;
        for (int i = 0; i < currentButtons.Length; ++i)
        {
            if (i < nextButtons.Length)
            {
                currentButtons[i] = nextButtons[i];
                currentButtons[i].SetActive(true);
            }
            else
            {
                currentButtons[i].SetActive(false);
            }
                
        }
    }

    public void ShowNextDialogue()
    {

        GameObject nowBtn = currentButtons[currentBtnIndex];
        currentDialog = nowBtn.GetComponent<ButtonBehavior>().GetNextDialogue();
        if (currentDialog != null)
            currentDialog.SetActive(true);
        //Instantiate(nowBtn.GetComponent<ButtonBehavior>().GetNextDialogue());
        //dialogObj.GetComponent<Image>().sprite = nowBtn.GetComponent<ButtonBehavior>().GetNextDialogue().GetComponent<Image>().sprite;
    }



    private void HideCurrentDialogue()
    {
        if (currentDialog != null)
            currentDialog.SetActive(false);
    }

    private void ShowCurrentDialogue()
    {
        if (currentDialog != null)
            currentDialog.SetActive(true);
    }

}
