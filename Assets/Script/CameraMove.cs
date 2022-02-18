using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool UretKontrol = true;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameObject born = GameObject.FindGameObjectWithTag("BornPosition");
        if (UretKontrol)
        {
            //for (int i = 0; i < MoveController.BaslangicAdamSayisi; i++)
            //{
            //    GameObject BaslangicAdam = Instantiate(player.gameObject, Vector3.zero, Quaternion.identity, transform.parent) as GameObject;
            //    BaslangicAdam.transform.parent = born.transform;
            //    MoveController.AddPalyer(BaslangicAdam);
            //}
            //MoveController.PlayerList.Add(GameObject.FindGameObjectWithTag("Player"));
            //MoveController.enSag = player;
            //MoveController.enSol = player;
            UretKontrol = false;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!SpawnControl.yakinDusman)
        {
            float kamerahizi = Time.deltaTime * 5f;
            transform.Translate(0, 0, kamerahizi);
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
