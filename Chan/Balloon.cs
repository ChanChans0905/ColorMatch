using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public GameObject ParentObject;
    public GameObject BalloonDestroyEffect;
    public GameObject BalloonLine;
    float ExpandingSpeed = 0.005f;
    Vector3 BalloonSize = new Vector3(1, 1, 1);
    Rigidbody Present_Rig;
    bool Respawned;
    Color Color_ColorToUse;
    GameObject ColorToUse;
    Color Color_Balloon;

    private void Start()
    {
        Present_Rig = ParentObject.GetComponent<Rigidbody>();
        ColorToUse = GameObject.FindWithTag("ColorToUse");
    }

    void Update()
    {
        if (!Respawned)
            ChangeBalloonColor();

        Movement();


    }

    void DestroyBalloon()
    {
        var DestroyVar = Instantiate(BalloonDestroyEffect, transform.position, transform.rotation);
        Destroy(DestroyVar, 3);
        Destroy(gameObject);
        Destroy(BalloonLine);
        Present_Rig.useGravity = true;
    }

    void Movement()
    {
        transform.localScale += BalloonSize * ExpandingSpeed * Time.deltaTime;

        //ParentObject.transform.position += new Vector3(ExpandingSpeed * 2f * Direction, ExpandingSpeed * 0.1f, 0);
    }

    void ChangeBalloonColor()
    {
        var ColorRenderer = gameObject.GetComponent<Renderer>();
        Color RandomColor = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), 0f);
        ColorRenderer.material.SetColor("_Color", RandomColor);
        Respawned = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            CheckTheColor();
        }
    }

    void CheckTheColor()
    {
        Color_ColorToUse = ColorToUse.GetComponent<Renderer>().material.color;
        Color_Balloon = GetComponent<Renderer>().material.color;

        float Diff_R = Mathf.Abs(Color_ColorToUse.r - Color_Balloon.r);
        float Diff_G = Mathf.Abs(Color_ColorToUse.g - Color_Balloon.g);
        float Diff_B = Mathf.Abs(Color_ColorToUse.b - Color_Balloon.b);

        if(Diff_R < 0.2f && Diff_G < 0.2f && Diff_B < 0.2f )
            DestroyBalloon();

        if(Diff_R > 0.2f)
            Debug.Log("빨강을 더 추가해보세요");
        if(Diff_G > 0.2f)
            Debug.Log("초록을 더 추가해보세요");
        if(Diff_B > 0.2f)
            Debug.Log("파랑을 더 추가해보세요");

        Debug.Log("R : " + Mathf.Abs(Color_ColorToUse.r - Color_Balloon.r));
        Debug.Log("G : " + Mathf.Abs(Color_ColorToUse.r - Color_Balloon.g));
        Debug.Log("B : " + Mathf.Abs(Color_ColorToUse.r - Color_Balloon.b));

        
    }

}
