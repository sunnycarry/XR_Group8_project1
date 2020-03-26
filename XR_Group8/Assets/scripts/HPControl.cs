using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPControl : MonoBehaviour
{

    public Image HP;
    public float Value;

    // Start is called before the first frame update
    void Start()
    {
        HP = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        HP.fillAmount = Value;
    }
    public void AddHP(float barchange)
    {
        barchange = (float)(barchange / 100.0f);
        Value = barchange + Value;
        if (Value < 0.0f)
            Value = 0;
    }
}
