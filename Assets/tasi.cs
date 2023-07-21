using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tasi : MonoBehaviour
{

    Camera kamera;
    Vector2 baslangıc_pozisyonu;
    
    GameObject[] kutular;

    yonetici yonet;


    private void OnMouseDrag()
    {
        Vector3 pozisyon = kamera.ScreenToWorldPoint(Input.mousePosition);
        pozisyon.z = 0;
        transform.position = pozisyon;
        
    }

    void Start()
    {
        kamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        baslangıc_pozisyonu = transform.position;

        kutular = GameObject.FindGameObjectsWithTag("kutu");
        yonet = GameObject.Find("yonetici").GetComponent<yonetici>();

    }

    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject kutu in kutular)
            {
                if (kutu.name == gameObject.name)

                {
                    float mesafe = Vector3.Distance(kutu.transform.position, transform.position);

                    if (mesafe <= 1)
                    {
                        transform.position = kutu.transform.position;
                        yonet.sayi_arttir();
                        this.enabled = false;
                    }
                    else
                    {
                         transform.position = baslangıc_pozisyonu;
                    }
                }
            }
        }

    }



}
