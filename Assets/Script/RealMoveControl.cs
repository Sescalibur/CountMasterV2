using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealMoveControl : MonoBehaviour
{
    
    private Vector3 beginPosition, finishPosition;
    //private GameObject[] adam;
    Camera cam;
    public static Vector3[] positions =new Vector3[360];
    private int i = 0;
    void Awake()
    {
        
       
    }
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        float playerSpeed = Time.deltaTime * 5f;
        cam = Camera.main;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            beginPosition = Camera.main.ScreenToWorldPoint(pos);
        }
        for (int i = 0; i < 360; i++)
        {
            var radians = (float)0.1 * Mathf.PI * i / 360;

            var vertrical = Mathf.Sin(radians);
            var horizontal = Mathf.Cos(radians);
            var spawnDir = new Vector3(horizontal, 0, vertrical);
            var spawnPos = transform.position + spawnDir * 2; // Radius is just the distance away from the point
            positions[i] = spawnPos;
            //Debug.Log(spawnPos);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            finishPosition = Camera.main.ScreenToWorldPoint(pos);
            Vector3 dif = finishPosition - beginPosition;

            if ((dif.x < 0) && (MoveController.enSol.gameObject.transform.position.x > -3)&& !SpawnControl.yakinDusman && MoveController.enSol!=null && MoveController.PlayerList !=null)
            {
                transform.position += new Vector3(dif.x, 0, 0) * Time.deltaTime * 30;
                beginPosition = finishPosition;
            }
            if ((dif.x > 0) && (MoveController.enSag.gameObject.transform.position.x < 3) && !SpawnControl.yakinDusman && MoveController.enSag != null && MoveController.PlayerList != null) 
            {
                transform.position += new Vector3(dif.x, 0, 0) * Time.deltaTime * 30;
                beginPosition = finishPosition;
            }
        }

        if (!SpawnControl.yakinDusman && cam !=null)
        {
            transform.Translate(0, 0, playerSpeed);
            cam.transform.position = new Vector3((float)(transform.position.x * 0.5), cam.transform.position.y,
                cam.transform.position.z);
        }
        
        
        
    }
    
}
