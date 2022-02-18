using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    public static int heal = 50;
    public int damage = 8;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(heal);
        if (gameObject.transform.position.z - MoveController.PlayerList[0].transform.position.z < 4 &&
            MoveController.adamSayisi > 0 && MoveController.PlayerList != null)
        {
            gameObject.GetComponent<Animator>().SetBool("Run",true);
            gameObject.GetComponent<Animator>().SetBool("Dovus", true);
            SpawnControl.yakinDusman = true;
            transform.LookAt(MoveController.PlayerList[0].transform);
            transform.Translate(Vector3.forward * Time.deltaTime);
            for (int j = 0; j < MoveController.PlayerList.Count; j++) 
            {
                MoveController.PlayerList[j].transform.LookAt(gameObject.transform);
                MoveController.PlayerList[j].transform.Translate(Vector3.forward * Time.deltaTime);
            }

            if (Camera.main.transform.position.z - MoveController.PlayerList[0].transform.position.z <= -9) 
            { 
                GameObject.FindGameObjectWithTag("AdamSayisi").gameObject.transform
                    .Translate(Vector3.forward * Time.deltaTime); 
                GameObject.Find("KameraTutacak").gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
            }

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MoveController>().heal -= damage;
            gameObject.GetComponent<Animator>().SetBool("Dovus",true);
            
        }
    }
}
