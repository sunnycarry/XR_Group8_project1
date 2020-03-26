using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPControl : MonoBehaviour
{
    public Image MP;
    public float Value;
   
    // Start is called before the first frame update
    void Start()
    {
        MP = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        MP.fillAmount = Value;
    }
    public void AddMP(float barchange)
    {
        barchange = (float)(barchange / 100.0f);
        Value = barchange + Value;
        if (Value < 0.0f)
            Value = 0;
    }
}
