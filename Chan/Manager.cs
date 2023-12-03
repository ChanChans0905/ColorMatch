using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] ColorToUse ColorToUse;
    public GameObject PresentPrefab;
    public GameObject BulletPrefab;
    public GameObject AimPosition;
    float Present_RespawnTimer = 20f;
    public LayerMask Mask = new LayerMask();

    void Update()
    {
        Present_RespawnTimer += Time.deltaTime;
        if (Present_RespawnTimer > 30f)
        {
            Present_RespawnTimer = 0;
            Instantiate(PresentPrefab, new Vector3(UnityEngine.Random.Range(-20f, 20f), UnityEngine.Random.Range(10f, 15f), UnityEngine.Random.Range(0f, 50f)), transform.rotation);
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Vector3 mouseWorldPosition = Vector3.zero;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, Mask))
        {
            AimPosition.transform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }


        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;

            Vector3 aimDir = (mouseWorldPosition - transform.position).normalized;
            Instantiate(BulletPrefab, transform.position, Quaternion.LookRotation(aimDir, Vector3.up));

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Palette_Red")
                    ColorToUse.ColorValue_R += 0.1f;

                if (hit.collider.tag == "Palette_Green")
                    ColorToUse.ColorValue_G += 0.1f;

                if (hit.collider.tag == "Palette_Blue")
                    ColorToUse.ColorValue_B += 0.1f;

                if (hit.collider.tag == "ResetButton")
                    ColorToUse.ColorValue_B = ColorToUse.ColorValue_G = ColorToUse.ColorValue_R = 0f;
            }


        }
    }
}
