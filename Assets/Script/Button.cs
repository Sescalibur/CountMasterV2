using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    Button my;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void buttonclick()
    {
        LevelController.seviye++;
        MoveController.adamSayisi = 0;
        LevelController.winSahne = false;
        MoveController.PlayerList.Clear();
        Destroy(LevelController.Atananlevel);
        LevelController.levelControl = true;
        LevelController.dead = false;
        LevelController.Baslangic = true;
        CameraMove.UretKontrol = true;
    }
}
