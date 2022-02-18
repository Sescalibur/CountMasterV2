using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    // Start is called before the first frame update
    CanvasGroup canvas;
    private bool kontrol = true;
    void Start()
    {
        canvas=GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelController.LoseSahne && kontrol)
        {
            canvas.alpha = 1;
            kontrol = false;
            Debug.Log("Calisti");
        }
        if(!LevelController.LoseSahne)
        {
            canvas.alpha = 0;
        }
        if (LevelController.WinPanel)
        {
            gameObject.SetActive(false);
        }
    }
}
