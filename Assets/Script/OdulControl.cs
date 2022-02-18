using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdulControl : MonoBehaviour
{
    public static bool OdulController = false;

    private GameObject adam;

    private int sinir = 10;

    private int y�kseklik = 1;

    private int yatay = -4;

    public static bool cekme = true;

    private bool birkere = true;

    public static bool durdurma = true;
    // Start is called before the first frame update
    void Start()
    {
        adam=GameObject.FindWithTag("BornPosition");
        //if (LevelController.odul)
        //{
        //    cekme = false;
        //    adam.transform.Translate(Vector3.forward * Time.deltaTime);
        //    SpawnControl.yakinDusman = true;
        //    for (int i = 0; i < MoveController.PlayerList.Count; i++)
        //    {
        //        GameObject positions = MoveController.PlayerList[i];
        //        positions.transform.position = new Vector3(yatay, y�kseklik, positions.transform.position.z);
        //        if (i == sinir)
        //        {
        //            y�kseklik++;
        //            if (sinir % 2 == 0)
        //            {
        //                sinir--;
        //                yatay++;
        //                if (yatay > 0)
        //                {
        //                    yatay = 0;
        //                }
        //            }
        //        }
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (OdulController)
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.active = false;
            }
        }
        else
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.active = true;
            }
        }

        if (LevelController.odul&&durdurma)
        {
            adam.transform.Translate(Vector3.forward * Time.deltaTime*5);
            GameObject.Find("KameraTutacak").gameObject.transform.Translate(Vector3.forward * Time.deltaTime*5);
            GameObject.Find("KameraTutacak").gameObject.transform.Translate(Vector3.up * Time.deltaTime *(float)0.5);
        }
        if (LevelController.odul&&birkere)
        {
            cekme = false;
            SpawnControl.yakinDusman = true;
            for (int i = 0; i < MoveController.PlayerList.Count; i++)
            {
                GameObject positions = MoveController.PlayerList[i];
                positions.GetComponent<Rigidbody>().useGravity=false;
                positions.transform.rotation = new Quaternion(0, 0, 0, 0);
                positions.transform.position = new Vector3(yatay, y�kseklik, positions.transform.position.z);
                yatay++;
                if (i == sinir)
                {
                    y�kseklik++;
                    yatay = -4 + y�kseklik;
                    if (sinir % 2 == 0)
                    {
                        sinir--;
                        yatay++;
                        if (yatay > 0)
                        {
                            yatay = 0;
                        }
                    }
                }
            }
            birkere = false;
        }
    }
}
