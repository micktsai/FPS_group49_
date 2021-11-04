using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniper : MonoBehaviour
{
    float zoomLevel = 8.0f;
    float zoomInSpeed = 100.0f;
    float zoomOutSpeed = 100.0f;

    private float initFOV;
    public GameObject far;
    public GameObject[] near;
    bool check;
    void Start()
    {
        //�����e�ṳ���������d�� unity�w�]��60
        initFOV = Camera.main.fieldOfView;
        check = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            check = !check;
        if (check)
        {
            ZoomInView();
            //�ҥ�ui����
            near[0].SetActive(true);
            near[1].SetActive(true);
            far.SetActive(false);
        }
        else
        {
            ZoomOutView();
            //����ui����
            near[0].SetActive(false);
            near[1].SetActive(false);
            far.SetActive(true);
        }
    }

    //��j�ṳ���������ϰ�
    void ZoomInView()
    {
        if (Mathf.Abs(Camera.main.fieldOfView - (initFOV / zoomLevel)) < 0f)
        {
            Camera.main.fieldOfView = initFOV / zoomLevel;
        }
        else if (Camera.main.fieldOfView - (Time.deltaTime * zoomInSpeed) >= (initFOV / zoomLevel))
        {
            Camera.main.fieldOfView -= (Time.deltaTime * zoomInSpeed);
        }
    }

    //�Y�p�ṳ���������ϰ�
    void ZoomOutView()
    {
        if (Mathf.Abs(Camera.main.fieldOfView - initFOV) < 0f)
        {
            Camera.main.fieldOfView = initFOV;
        }
        else if (Camera.main.fieldOfView + (Time.deltaTime * zoomOutSpeed) <= initFOV)
        {
            Camera.main.fieldOfView += (Time.deltaTime * zoomOutSpeed);
        }
    }
}
