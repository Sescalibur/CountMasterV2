using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdulBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        //if (collision.transform.position == MoveController.PlayerList[MoveController.adamSayisi].transform.position)
        //{
        //    OdulControl.durdurma = false;
        //    Debug.Log("oldu");
        //}

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Run",false);
            collision.transform.Translate(Vector3.zero);
            OdulControl.durdurma = false;
            LevelController.winSahne = true;
            LevelController.WinPanel = true;
        }
    }

}
