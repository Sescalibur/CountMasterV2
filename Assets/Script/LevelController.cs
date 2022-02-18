using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject[] level;
    public static int seviye;
    public static bool Baslangic=true;
    public static bool levelControl = true;
    public static bool dead=true;
    public static bool levelUp = true;
    public static GameObject Atananlevel;
    public static bool winSahne=false;
    public static bool LoseSahne=false;
    private bool birkere = true;
    public static bool WinPanel=false;
    public static bool odul = false;
    // Start is called before the first frame update

    void Awake()
    {
        
    }
    void Start()
    {
        //ilkSeviye();
        //panel = GameObject.Find("Canvas").GetComponentInChildren()>().FindGameObjectWithTag("NextLevel");
        //Debug.Log(panel); 
        //panel.active = false;
        //Debug.Log(panel);
        //panel = GameObject.FindGameObjectWithTag("NextLevel");
    }

    // Update is called once per frame
    void Update()
    {
        if (Baslangic&&MoveController.PlayerList!=null&&SpawnControl.yakinDusman != null)
        {
            for (int i = 0; i < MoveController.PlayerList.Count; i++)
            {
                MoveController.PlayerList[i].GetComponent<Animator>().SetBool("Run", false);
                SpawnControl.yakinDusman = true;
            }
        }
        
        if (Input.anyKeyDown && Baslangic==true)
        {
            for (int i = 0; i < MoveController.PlayerList.Count; i++)
            {
                MoveController.PlayerList[i].GetComponent<Animator>().SetBool("Run", true);
            }
            Baslangic = false;
            SpawnControl.yakinDusman=false;
            GameObject.FindGameObjectWithTag("Panel").active = false;
            dead = true;
        }
        if ((MoveController.adamSayisi <= 0||MoveController.PlayerList==null) && dead)
        {
            //StartCoroutine(lose());
            LoseSahne = true;
            SpawnControl.yakinDusman = true;
        }
        if (levelControl)
        {
            Atananlevel = Instantiate(level[seviye]) as GameObject;
            levelControl = false;
            levelUp = true;
        }

        if (birkere)
        {
            MoveController.adamSayisi--;
            birkere = false;
        }
    }
    public GameObject ilkSeviye()
    {
        GameObject ilkSeviye = Instantiate(level[seviye]);
        return ilkSeviye;
    }

    void OnTriggerEnter(Collider collider)
    {
        //StartCoroutine(win());
        SpawnControl.yakinDusman = true;
        odul = true;
        //winSahne = true;
        //WinPanel = true;
    }

    IEnumerator win()
    {
        yield return new WaitForSecondsRealtime(2);
        winSahne = true;
        WinPanel = true;
    }

    IEnumerator lose()
    {
        yield return new WaitForSecondsRealtime(2);
        
        LoseSahne = true;
    }
}
