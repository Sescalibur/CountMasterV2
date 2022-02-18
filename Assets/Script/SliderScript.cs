using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider slider;
    void Start()
    {
        slider.maxValue = BossControl.heal;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = BossControl.heal;
    }
}
