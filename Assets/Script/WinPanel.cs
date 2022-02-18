using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    // Start is called before the first frame update
    CanvasGroup canvas;

    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelController.winSahne)
        {
            canvas.alpha = 1;
            //Debug.Log("Calisti");
        }
        else
        {
            canvas.alpha = 0;
        }
    }
}
