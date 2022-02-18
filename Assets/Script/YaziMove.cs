using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class YaziMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MoveController.adamSayisi > 0 && MoveController.PlayerList!=null )
        {
            for (int j = 0; j < MoveController.PlayerList.Count; j++)
            {
                if (MoveController.enSag == null)
                {
                    MoveController.enSag = MoveController.PlayerList[0];
                }
                if (MoveController.enSol == null)
                {
                    MoveController.enSol = MoveController.PlayerList[0];
                }
                if (MoveController.enSol.transform.position.x > MoveController.PlayerList[j].transform.position.x)
                {
                    MoveController.enSol = MoveController.PlayerList[j];
                }
                if (MoveController.enSag.transform.position.x < MoveController.PlayerList[j].transform.position.x)
                {
                    MoveController.enSag = MoveController.PlayerList[j];
                }

            }
        }
    }
}
