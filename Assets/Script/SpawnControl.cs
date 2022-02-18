using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public List<GameObject> Enemy = new List<GameObject>();
    private bool DusmanYarat = true;
    int i = 0;
    public int enemyNumber = 0;
    public static int dusmanSayisi = 0;
    public static bool yakinDusman = false;
    [SerializeField] GameObject Enemys;
    private int yazilanDusmanSayisi = 0;
    //Camera cam = Camera.main;
    public void AddPalyer(GameObject obje)
    {
        Enemy.Add(obje);
    }
    void Start()
    {
        if (DusmanYarat)
        {
            for (int i = 0; i < Random.Range(1,10); i++)
            {
                GameObject Enemy = Instantiate(Enemys.gameObject, new Vector3(transform.position.x,0,transform.position.z), Quaternion.identity);
                Enemy.transform.parent=transform;
                Enemy.transform.Rotate(0,180,0);
                AddPalyer(gameObject);
                dusmanSayisi++;
                enemyNumber++;
                yazilanDusmanSayisi++;
            }
            DusmanYarat = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy[i].transform.position.y < -0.5&&enemyNumber>0)
        {
            Enemy.Remove(gameObject);
            Destroy(gameObject);
            dusmanSayisi--;
            enemyNumber--;
        }
        if (transform.position.z - GameObject.FindGameObjectWithTag("BornPosition").transform.position.z < 4 && MoveController.adamSayisi>0 &&MoveController.PlayerList!=null)
        {
            yakinDusman = true;
            foreach (Transform VARIABLE in gameObject.transform)
            {
                if (VARIABLE!=null)
                {
                    VARIABLE.gameObject.GetComponent<Animator>().SetBool("Run", true);
                    VARIABLE.LookAt(GameObject.FindGameObjectWithTag("BornPosition").transform);
                    VARIABLE.Translate(Vector3.forward * Time.deltaTime);
                    if (MoveController.PlayerList.Count <= 0)
                    {
                        VARIABLE.gameObject.GetComponent<Animator>().SetBool("Run",false);
                    }
                    for (int j = 0; j < MoveController.PlayerList.Count; j++)
                    {
                        MoveController.PlayerList[j].transform.LookAt(VARIABLE);
                        MoveController.PlayerList[j].transform.Translate(Vector3.forward * Time.deltaTime/2);
                    }
                    GameObject.FindGameObjectWithTag("BornPosition").gameObject.transform.Translate(Vector3.forward * Time.deltaTime/2);
                    //GameObject.FindGameObjectWithTag("AdamSayisi").gameObject.transform.position = new Vector3(
                    //    (MoveController.enSol.transform.position.x + MoveController.enSag.transform.position.x) / 2,
                    //    GameObject.FindGameObjectWithTag("AdamSayisi").gameObject.transform.position.y,
                    //    MoveController.PlayerList[0].transform.position.z);
                    if (Camera.main.transform.position.z - MoveController.PlayerList[0].transform.position.z <= -9)
                    {
                        GameObject.FindGameObjectWithTag("AdamSayisi").gameObject.transform.Translate(Vector3.forward * Time.deltaTime/2);
                        GameObject.Find("KameraTutacak").gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
                    }
                    
                    //Camera.main.transform.localPosition = new Vector3(Camera.main.transform.localPosition.x,
                    //    Camera.main.transform.localPosition.y, Camera.main.transform.localPosition.z + Time.deltaTime);
                    //GameObject.FindGameObjectWithTag("BornPosition").transform.LookAt(VARIABLE);
                    //GameObject.FindGameObjectWithTag("BornPosition").transform.Translate(Vector3.forward * Time.deltaTime);
                }
            }
            

            //foreach (Transform VARIABLE in gameObject.transform)
            //{
            //    VARIABLE.gameObject.GetComponent<Animator>().SetBool("Run", true);
            //}
            //transform.LookAt(MoveController.PlayerList[0].transform);
            //transform.Translate(Vector3.forward * Time.deltaTime);
            //for (int j = 0; j < MoveController.PlayerList.Count; j++)
            //{
            //    MoveController.PlayerList[j].transform.LookAt(transform);
            //    MoveController.PlayerList[j].transform.Translate(Vector3.forward * Time.deltaTime);
            //    //MoveController.PlayerList[j].transform.Rotate(0,0,0,0);
            //}
        }

        if (enemyNumber <= 0)
        {
            yakinDusman = false;
            Destroy(gameObject);
            foreach (var player in MoveController.PlayerList)
            {
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            //GameObject.FindGameObjectWithTag("BornPosition").transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        i++;
        if (i == Enemy.Count)
        {
            i = 0;
        }

        //for (int j = 0; j < 360; j++)
        //{
        //    var radians = 2 * Mathf.PI / j;

        //    var vertrical = Mathf.Sin(radians);
        //    var horizontal = Mathf.Cos(radians);

        //    var spawnDir = new Vector3(horizontal, 0, vertrical);

        //    var spawnPos = transform.parent.position + spawnDir * 2; // Radius is just the distance away from the point

        //    Debug.Log(spawnPos);
        //}

        //GameObject adamlar = Instantiate(adam, spawnPos, Quaternion.identity) as GameObject;
        //adamlar.transform.parent = adam.transform.parent;
        //adamlar.GetComponent<Animator>().SetBool("Run", true);


    }


}
