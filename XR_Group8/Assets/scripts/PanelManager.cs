using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public MPControl mpControl;

    public GameObject[] openPanel;
    public GameObject[] endingPanel;
    // Start is called before the first frame update
    void Start()
    {
        HideAllPanel();
        StartCoroutine("StartPanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartPanel()
    {
        for (int i = 0; i < openPanel.Length; ++i)
        {
            openPanel[i].SetActive(true);
            for (int j = 0; j < openPanel.Length; ++j)
            {
                if (i == j)
                    continue;
                openPanel[j].SetActive(false);
            }
            yield return new WaitForSeconds(10);
        }
        foreach (GameObject g in openPanel)
            g.SetActive(false);
    }

    private void HideAllPanel()
    {
        foreach (GameObject g in openPanel)
            g.SetActive(false);
        foreach (GameObject g in endingPanel)
            g.SetActive(false);
    }
    public void ShowEnding()
    {
        int endIndex = SetEndingIndex();
        endingPanel[endIndex].SetActive(true);
        Debug.Log(endIndex);
    }

    private int SetEndingIndex()
    {
        if (mpControl.Value <= 0.15f)
            return 0;
        else if (mpControl.Value > 0.15f && mpControl.Value < 0.35f)
            return 1;
        else
            return 2;
    }


}
