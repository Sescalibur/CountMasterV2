using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveController : MonoBehaviour
{
    public static int adamSayisi = 1;
    private bool gectiMi = true;
    public static GameObject enSol;
    public static GameObject enSag;
    private Vector3 enSolV3,enSagV3;
    public static List<GameObject> PlayerList = new List<GameObject>();
    public static int BaslangicAdamSayisi = 1;
    public int heal = 10;
    public int damage = 1;
    private Vector3 kontrol;
    
    
    public static void AddPalyer(GameObject obje)
    {
        PlayerList.Add(obje);
    }
    void Awake()
    {
        PlayerList.Add(gameObject);
        adamSayisi++;
        enSag = gameObject;
        enSol = gameObject;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y < -0.5) 
        {
            PlayerList.Remove(gameObject);
            Destroy(gameObject);
            adamSayisi--;
        }
        GameObject.FindGameObjectWithTag("AdamSayisi").GetComponent<TextMeshPro>().text = adamSayisi.ToString();
        //for (int i = 0; i < RealMoveControl.positions.Length; i++)
        //{
        //    if (Vector3.Distance(RealMoveControl.positions[i],gameObject.transform.localPosition)>5)
        //    {
        //        gameObject.transform.Translate((transform.parent.position - gameObject.transform.position) * Time.deltaTime);
        //        Debug.Log("dene");
        //    }
        //}
       
        if (Vector3.Distance(transform.parent.position, gameObject.transform.position) > 1&&OdulControl.cekme)
        {
            //gameObject.transform.Translate((transform.parent.position - gameObject.transform.position) * Time.deltaTime*5);
            transform.position=Vector3.MoveTowards(transform.position,transform.parent.position,Time.deltaTime*3);
            //Debug.Log("dene");
        }
        

        //gameObject.transform.Translate((transform.parent.position-gameObject.transform.position)*Time.deltaTime);

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ge�it" && gectiMi == true)
        {
            Destroy(collision.gameObject);
            bornPosition(gameObject,collision.gameObject);
            gectiMi = false;
            GameObject.FindGameObjectWithTag("AdamSayisi").gameObject.GetComponent<TextMeshPro>().text =
                adamSayisi.ToString();

            foreach (Transform sil in collision.transform.parent.transform)
            {
                Destroy(sil.gameObject);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().heal -= damage;
            if (collision.gameObject.GetComponent<EnemyController>().heal <= 0)
            {
                SpawnControl.dusmanSayisi--;
                collision.transform.parent.GetComponent<SpawnControl>().enemyNumber--;
                //collision.gameObject.GetComponent<SpawnControl>().Enemy.Remove(collision.gameObject);
                Destroy(collision.gameObject);
            }

            heal -= collision.gameObject.GetComponent<EnemyController>().damage;
            if (heal <= 0)
            {
                PlayerList.Remove(gameObject);
                Destroy(gameObject);
                adamSayisi--;
            }
        }

        if (collision.gameObject.tag == "Boss")
        {
            gameObject.GetComponent<Animator>().SetBool("Dovus",true);
            collision.gameObject.GetComponent<Animator>().SetBool("Dovus",true);
            BossControl.heal-=damage;
            //StartCoroutine(savas(BossControl.heal, damage));
            if (BossControl.heal <= 0)
            {
                Destroy(collision.gameObject);
                SpawnControl.yakinDusman = false;
                LevelController.winSahne = true;
                LevelController.WinPanel = true;
            }
            if (heal <= 0)
            {
                PlayerList.Remove(gameObject);
                Destroy(gameObject);
                adamSayisi--;
            }
        }
    }

    private void bornPosition(GameObject adam,GameObject yazi)
    {
        string deneme = yazi.GetComponentInChildren<TextMeshPro>().text;
        char islem;
        islem = deneme[0];
        char[] sayi = new char[3];
        int k = 0;

        for (int i = 1; i < deneme.Length; i++)
        {
            sayi[k] = deneme[i];
            k += 1;
        }
        string sayilar = new string(sayi);
        int kullan�lanSayi = Convert.ToInt32(sayilar);

        if (islem == '+')
        {
            Vector3[] pozisyon = new Vector3[kullan�lanSayi];
            for (int i = 0; i < kullan�lanSayi; i++)
            {

                if (kullan�lanSayi > 0 && kullan�lanSayi < 25)
                {
                    sikKullan(i, (float)0.25, pozisyon, adam);
                }
                else if (kullan�lanSayi > 25 && kullan�lanSayi < 50)
                {
                    sikKullan(i, (float)0.5, pozisyon, adam);
                }
                else if (kullan�lanSayi > 50 && kullan�lanSayi < 75)
                {
                    sikKullan(i, (float)0.75, pozisyon, adam);
                }
                else if (kullan�lanSayi > 75)
                {
                    sikKullan(i, (float)1, pozisyon, adam);
                }
            }
        }

        if (islem == 'x' || islem == 'X')
        {
            int sinir = (kullan�lanSayi - 1) * adamSayisi;
            Vector3[] pozisyon = new Vector3[sinir];
            for (int j = 0; j < sinir; j++)
            {
                if (kullan�lanSayi <= 2)
                {
                    sikKullan(j, (float)0.25, pozisyon, adam);
                }
                else if (kullan�lanSayi > 2 && kullan�lanSayi <= 5)
                {
                    sikKullan(j, (float)0.5, pozisyon, adam);
                }
                else if (kullan�lanSayi > 5 && kullan�lanSayi <= 8)
                {
                    sikKullan(j, (float)0.75, pozisyon, adam);
                }
                else if (kullan�lanSayi > 8)
                {
                    sikKullan(j, (float)1, pozisyon, adam);
                }
            }
        }
    }

    void sikKullan(int i, float derece, Vector3[] pozisyon, GameObject adam)
    {
        pozisyon[i] = new Vector3(gameObject.transform.position.x + Random.RandomRange(-derece, +derece), adam.transform.position.y, gameObject.transform.position.z + Random.RandomRange(-derece, +derece));
        //pozisyon[i] = new Vector3(RealMoveControl.positions[i].x + Random.RandomRange(-derece, +derece), adam.transform.position.y,
        //    RealMoveControl.positions[i].z + Random.RandomRange(-derece, +derece));
        GameObject adamlar = Instantiate(adam, pozisyon[i], Quaternion.identity) as GameObject;
        adamlar.transform.parent = adam.transform.parent;
        adamlar.GetComponent<Animator>().SetBool("Run", true);

    }


    IEnumerator savas(int can,int damage)
    {
        yield return new WaitForSecondsRealtime(1);
        canAzalt(can,damage);
    }

    void canAzalt(int can, int damage)
    {
        can -= damage;
    }
    
}
