using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void buttonClick2()
    {
        MoveController.PlayerList.Clear();
        Destroy(LevelController.Atananlevel);
        LevelController.levelControl = true;
        LevelController.dead = false;
        LevelController.Baslangic = true;
        CameraMove.UretKontrol = true;
        LevelController.LoseSahne = false;
    }
}
