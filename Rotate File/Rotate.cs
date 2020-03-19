using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    public GameObject Earth;
    public GameObject Pluto;
    public GameObject Sun;
    public GameObject Sun_For_Earth;

    //Данные для Земли
    public float vp; //скорость планеты в перигелии (ближ. точка)
    public float r; //√(x*x+y*y+z*z)
    public float R; //радиус перигелия
    public float f = 0;
    public float f1;
    public float f2;
    public float massSun = 1.9885f * Mathf.Pow(10,30);
    public float massEarth = 5.9726f * Mathf.Pow(10,24);
    public float G = 6.67f * Mathf.Pow(10,-11); //гравитационная постоянная
    public float h1;
    public float h = 0.0001f; //начальное h
    public float hi; //значение приращения времени в i-той итерации
    public float a1;
    public float rSred;
    public float vtSred;
    public float e; // угловое ускорение
    public float PrirHi; //Δhi
    public float PrirTi; //Δti
    public float vrSred;
    public float TSred1;
    public float TSred2;
    public float bhi;
    public float EPS;
    public float distance;
    public float orbitalPeriod;
    public float X1;
    public float Y1;
    public float Z1;

    //Данные для Плутона
    public float a_Pluton; //Большая полуось
    public float b_Pluton; //Малая полуось
    public float c_Pluton;
    public float vp_Pluton; //скорость планеты в перигелии (ближ. точка)
    public float r_Pluton; //√(x*x+y*y+z*z)
    public float r1_Pluton;
    public float r2_Pluton;
    public float R_Pluton; //радиус перигелия
    public float f_Pluton = 0;
    public float f1_Pluton;
    public float f2_Pluton;
    public float massPluto;
    public float h1_Pluton;
    public float hi_Pluton; //значение приращения времени в i-той итерации
    public float a1_Pluton;
    public float rSred_Pluton;
    public float rSred1_Pluton;
    public float rSred2_Pluton;
    public float vtSred_Pluton;
    public float wRSred;
    public float e_Pluton; // угловое ускорение
    public float PrirHi_Pluton; //Δhi
    public float PrirTi_Pluton; //Δti
    public float vrSred_Pluton;
    public float bhi_Pluton;
    public float EPS_Pluton;
    public float distance_Pluton;
    public float orbitalPeriod_Pluton;
    public float X1_Pluton;
    public float Y1_Pluton;
    public float X2_Pluton;
    public float Y2_Pluton;
    public float Z_Pluton;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        EarthModelStart();
        PlutoModelStart();
        Debug.Log("Частота кадров = " + (1.0f / Time.deltaTime).ToString("F0"));
    }

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        EarthModel();
        PlutoModel();
        //Debug.Log("Частота кадров = " + (1.0f / Time.deltaTime).ToString("F0"));
    }

    float TfSred(float f, float a1)
    {
        float tSred = (((a1 + 1) * Mathf.Abs(Mathf.Sin(f))) / ((2 * a1) * (((a1 + 1) * Mathf.Cos(f)) - a1))) + (a1 * (Mathf.Asin((a1 + 1 - (a1 * Mathf.Cos(f))) / (((a1 + 1) * Mathf.Cos(f)) - a1)) - (Mathf.PI/2)) / Mathf.Pow((-2 * a1) - 1, 3 / 2));
        //Debug.Log("tSred = " + tSred);
        return tSred;
    }

    float TrSred(float rSred, float a1, float vrSred)
    {
        float tSred = ((rSred * Mathf.Abs(vrSred)) / ((2 * a1) + 1)) - ((a1 * ((Mathf.PI / 2) + Mathf.Asin((((2 * a1 + 1) * rSred) - a1) / (a1 - 1)))) / Mathf.Pow((-2 * a1) - 1, 1.5f));
        return tSred;
    }

    void PlutoModelStart()
    {
        //Pluto.transform.RotateAround(Sun.transform.position, Vector3.forward, 17.14f); //наклонение орбиты (в случае Плутона нужно это учитывать)
        f_Pluton = 0;
        a_Pluton = 39.482117f;
        b_Pluton = a_Pluton * Mathf.Sqrt(1 - Mathf.Pow(0.2488273f, 2));
        c_Pluton = 11.1189074357f;

        h = 0.0001f;
        orbitalPeriod_Pluton = 90553.02f * 24f * 3600f;
        r_Pluton = 4.45005f * Mathf.Pow(10, 12);//В а.е. = 29.667f
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massPluto = 1.303f * Mathf.Pow(10, 22);

        R_Pluton = (1 - 0.2488273f) * 5906440633.93f;//
        h1_Pluton = -G * (massSun + massPluto);
        a1_Pluton = h1_Pluton / (R_Pluton * Mathf.Pow(1726.6724904f, 2));//-105.774552536f; //Vp = 29813979130.6f - старое значение
        //Debug.Log("a1_Pluton = " + a1_Pluton);
        vp_Pluton = 1726.6724904f /*(-2 * a1_Pluton * Mathf.PI * R_Pluton) / (orbitalPeriod_Pluton * Mathf.Pow((-2 * a1_Pluton) - 1, 1.5f))*/;
        rSred_Pluton = 1.6621161561f;//r_Pluton / R_Pluton;

        hi_Pluton = h;

        vtSred_Pluton = 1 / rSred_Pluton;
        vrSred_Pluton = Mathf.Sqrt(Mathf.Pow(a1_Pluton + 1, 2) - Mathf.Pow((a1_Pluton + 1) / rSred_Pluton, 2));
        //Debug.Log("vrSred_Pluton = " + vrSred_Pluton);
        wRSred = (a1_Pluton + 1 / rSred_Pluton) / Mathf.Pow(rSred_Pluton, 2);//-3444729194,89
        //Debug.Log("wRSred = " + wRSred);

        r_Pluton = ((vp_Pluton * hi_Pluton * vrSred_Pluton) + (Mathf.Pow(vp_Pluton, 2) / R_Pluton) * wRSred * Mathf.Pow(hi_Pluton, 2)) / 2f;
        //Debug.Log("r_Pluton = " + r_Pluton);
        e_Pluton = (2 * Mathf.PI) / orbitalPeriod_Pluton;
        f_Pluton = f_Pluton + ((vp_Pluton / R_Pluton) * (vtSred_Pluton / rSred_Pluton) * hi_Pluton) + (e_Pluton * Mathf.Pow(hi_Pluton, 2) / 2);
        Debug.Log("Угловое ускорение = " + e_Pluton);
        Debug.Log("Совсем начальное f_Pluton = " + f_Pluton * Mathf.Pow(10, 8));
        //Debug.Log("f_Pluton = " + f_Pluton);

        X1_Pluton = a_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(110.30347f) + Pluto.transform.position.x / 1.55f;//r_Pluton * ((Mathf.Cos(f_Pluton + 113.76329f) * Mathf.Cos(110.30347f)) - (Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Sin(113.76329f)));
        //Debug.Log("CoordinateX_Pluton = " + CoordinateX_Pluton);
        Y1_Pluton = b_Pluton * Mathf.Sin(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(110.30347f) + Pluto.transform.position.z / 1.55f;//r_Pluton * ((Mathf.Cos(f_Pluton + 113.76329f) * Mathf.Sin(110.30347f)) + (Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Cos(113.76329f)));
        //Debug.Log("CoordinateY_Pluton = " + CoordinateY_Pluton);
        Z_Pluton = c_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(17.14f);//r_Pluton * Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Sin(17.14f);
        //Debug.Log("CoordinateZ_Pluton = " + CoordinateZ_Pluton);
        Pluto.transform.position = new Vector3(X1_Pluton, Z_Pluton, Y1_Pluton);
        distance_Pluton = Vector3.Distance(Pluto.transform.position, Sun.transform.position);

        r1_Pluton = 49.31f;
        r2_Pluton = r_Pluton;
        rSred1_Pluton = r1_Pluton / R_Pluton;
        rSred2_Pluton = r2_Pluton / R_Pluton;
        f1_Pluton = 0;
        f2_Pluton = f_Pluton;

        /*
        //2 итерация
        PrirTi_Pluton = (vp_Pluton / R_Pluton) * (TrSred(rSred2_Pluton, a1_Pluton, vrSred_Pluton) - TrSred(rSred1_Pluton, a1_Pluton, vrSred_Pluton));
        // Debug.Log("PrirTi = " + PrirTi);

        PrirHi_Pluton = PrirTi_Pluton - 0.0001f;
        //  Debug.Log("PrirHi = " + PrirHi);

        bhi_Pluton = PrirHi_Pluton / 0.0001f;
        //Debug.Log("bhi_Pluton = " + bhi_Pluton);
        if (Mathf.Abs(bhi_Pluton) >= 0.9f)
        {
            hi_Pluton -= PrirHi_Pluton;
        }

        else if (Mathf.Abs(bhi_Pluton) < 0.9f)
        {
            hi_Pluton = h;
        }

        //Debug.Log("hi_Pluton = " + hi_Pluton);


        r_Pluton = ((vp_Pluton * hi_Pluton * vrSred_Pluton) + (Mathf.Pow(vp_Pluton, 2) / R_Pluton) * wRSred * Mathf.Pow(hi_Pluton, 2)) / 1.8f;
        //Debug.Log("r_Pluton = " + r_Pluton);
        f_Pluton = f2_Pluton + ((vp_Pluton / R_Pluton) * (vtSred_Pluton / rSred_Pluton) * hi_Pluton) + (e_Pluton * Mathf.Pow(hi_Pluton, 2) / 2);
        Debug.Log("Начальное f_Pluton = " + f_Pluton * Mathf.Pow(10, 8));

        X1_Pluton = a_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(110.30347f) + Pluto.transform.position.x / 1.55f;//r_Pluton * ((Mathf.Cos(f_Pluton + 113.76329f) * Mathf.Cos(110.30347f)) - (Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Sin(113.76329f)));
        //Debug.Log("CoordinateX_Pluton = " + X1_Pluton);
        Y1_Pluton = b_Pluton * Mathf.Sin(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(110.30347f) + Pluto.transform.position.z / 1.55f;//r_Pluton * ((Mathf.Cos(f_Pluton + 113.76329f) * Mathf.Sin(110.30347f)) + (Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Cos(113.76329f)));
        //Debug.Log("CoordinateY_Pluton = " + Y1_Pluton);
        Z_Pluton = c_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(17.14f);//r_Pluton * Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Sin(17.14f);
        //Debug.Log("CoordinateZ_Pluton = " + Z_Pluton);
        Pluto.transform.position = new Vector3(X1_Pluton, Z_Pluton, Y1_Pluton);

        r1_Pluton = r2_Pluton;
        r2_Pluton = r_Pluton;
        rSred1_Pluton = r1_Pluton / R_Pluton;
        rSred2_Pluton = r2_Pluton / R_Pluton;
        f1_Pluton = f2_Pluton;
        f2_Pluton = f_Pluton;

        //3 итерация
        PrirTi_Pluton = (vp_Pluton / R_Pluton) * (TrSred(rSred2_Pluton, a1_Pluton, vrSred_Pluton) - TrSred(rSred1_Pluton, a1_Pluton, vrSred_Pluton));
        // Debug.Log("PrirTi = " + PrirTi);

        PrirHi_Pluton = PrirTi_Pluton - 0.0001f;
        //  Debug.Log("PrirHi = " + PrirHi);

        bhi_Pluton = PrirHi_Pluton / 0.0001f;
        //Debug.Log("bhi_Pluton = " + bhi_Pluton);
        if (Mathf.Abs(bhi_Pluton) >= 0.9f)
        {
            hi_Pluton -= PrirHi_Pluton;
        }

        else if (Mathf.Abs(bhi_Pluton) < 0.9f)
        {
            hi_Pluton = h;
        }

        //Debug.Log("hi_Pluton = " + hi_Pluton);


        r_Pluton = ((vp_Pluton * hi_Pluton * vrSred_Pluton) + (Mathf.Pow(vp_Pluton, 2) / R_Pluton) * wRSred * Mathf.Pow(hi_Pluton, 2)) / 1.8f;
        //Debug.Log("r_Pluton = " + r_Pluton);
        f_Pluton = f2_Pluton + ((vp_Pluton / R_Pluton) * (vtSred_Pluton / rSred_Pluton) * hi_Pluton) + (e_Pluton * Mathf.Pow(hi_Pluton, 2) / 2);
        Debug.Log("Начальное f_Pluton = " + f_Pluton * Mathf.Pow(10, 8));

        X1_Pluton = a_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(110.30347f) + Pluto.transform.position.x / 1.55f;//r_Pluton * ((Mathf.Cos(f_Pluton + 113.76329f) * Mathf.Cos(110.30347f)) - (Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Sin(113.76329f)));
        //Debug.Log("CoordinateX_Pluton = " + X1_Pluton);
        Y1_Pluton = b_Pluton * Mathf.Sin(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(110.30347f) + Pluto.transform.position.z / 1.55f;//r_Pluton * ((Mathf.Cos(f_Pluton + 113.76329f) * Mathf.Sin(110.30347f)) + (Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Cos(113.76329f)));
        //Debug.Log("CoordinateY_Pluton = " + Y1_Pluton);
        Z_Pluton = c_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(17.14f);//r_Pluton * Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Sin(17.14f);
        //Debug.Log("CoordinateZ_Pluton = " + Z_Pluton);
        Pluto.transform.position = new Vector3(X1_Pluton, Z_Pluton, Y1_Pluton);

        r1_Pluton = r2_Pluton;
        r2_Pluton = r_Pluton;
        rSred1_Pluton = r1_Pluton / R_Pluton;
        rSred2_Pluton = r2_Pluton / R_Pluton;
        f1_Pluton = f2_Pluton;
        f2_Pluton = f_Pluton;

        //4 итерация
        //3 итерация
        PrirTi_Pluton = (vp_Pluton / R_Pluton) * (TrSred(rSred2_Pluton, a1_Pluton, vrSred_Pluton) - TrSred(rSred1_Pluton, a1_Pluton, vrSred_Pluton));
        // Debug.Log("PrirTi = " + PrirTi);

        PrirHi_Pluton = PrirTi_Pluton - 0.0001f;
        //  Debug.Log("PrirHi = " + PrirHi);

        bhi_Pluton = PrirHi_Pluton / 0.0001f;
        //Debug.Log("bhi_Pluton = " + bhi_Pluton);
        if (Mathf.Abs(bhi_Pluton) >= 0.9f)
        {
            hi_Pluton -= PrirHi_Pluton;
        }

        else if (Mathf.Abs(bhi_Pluton) < 0.9f)
        {
            hi_Pluton = h;
        }

        //Debug.Log("hi_Pluton = " + hi_Pluton);


        r_Pluton = ((vp_Pluton * hi_Pluton * vrSred_Pluton) + (Mathf.Pow(vp_Pluton, 2) / R_Pluton) * wRSred * Mathf.Pow(hi_Pluton, 2)) / 1.8f;
        //Debug.Log("r_Pluton = " + r_Pluton);
        f_Pluton = f2_Pluton + ((vp_Pluton / R_Pluton) * (vtSred_Pluton / rSred_Pluton) * hi_Pluton) + (e_Pluton * Mathf.Pow(hi_Pluton, 2) / 2);
        Debug.Log("Начальное f_Pluton = " + f_Pluton * Mathf.Pow(10, 8));

        X1_Pluton = a_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(110.30347f) + Pluto.transform.position.x / 1.55f;//r_Pluton * ((Mathf.Cos(f_Pluton + 113.76329f) * Mathf.Cos(110.30347f)) - (Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Sin(113.76329f)));
        //Debug.Log("CoordinateX_Pluton = " + X1_Pluton);
        Y1_Pluton = b_Pluton * Mathf.Sin(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(110.30347f) + Pluto.transform.position.z / 1.55f;//r_Pluton * ((Mathf.Cos(f_Pluton + 113.76329f) * Mathf.Sin(110.30347f)) + (Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Cos(113.76329f)));
        //Debug.Log("CoordinateY_Pluton = " + Y1_Pluton);
        Z_Pluton = c_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(17.14f);//r_Pluton * Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Sin(17.14f);
        //Debug.Log("CoordinateZ_Pluton = " + Z_Pluton);
        Pluto.transform.position = new Vector3(X1_Pluton, Z_Pluton, Y1_Pluton);

        r1_Pluton = r2_Pluton;
        r2_Pluton = r_Pluton;
        rSred1_Pluton = r1_Pluton / R_Pluton;
        rSred2_Pluton = r2_Pluton / R_Pluton;
        f1_Pluton = f2_Pluton;
        f2_Pluton = f_Pluton;
        */

        //Debug.Log("Начальное f2_Pluton = " + f2_Pluton * Mathf.Pow(10, 8));
        EPS_Pluton = 0.9999775f;
    }

    void PlutoModel()
    {
        //Pluto.transform.RotateAround(Vector3.zero, Vector3.up, Mathf.Abs(2 * f * Mathf.Pow(10, 6)));
        //distance_Pluton = Vector3.Distance(Pluto.transform.position, Sun.transform.position);
        //r_Pluton = distance_Pluton * 149597870.7f;

        PrirTi_Pluton = (vp_Pluton / R_Pluton) * (TrSred(rSred2_Pluton, a1_Pluton, vrSred_Pluton) - TrSred(rSred1_Pluton, a1_Pluton, vrSred_Pluton));
        //Debug.Log("PrirTi_Pluton = " + PrirTi_Pluton);

        PrirHi_Pluton = PrirTi_Pluton - 0.0001f;
        //Debug.Log("PrirHi_Pluton = " + PrirHi_Pluton);

        bhi_Pluton = PrirHi_Pluton / 0.0001f;
        //Debug.Log("bhi_Pluton = " + bhi_Pluton);
        //Debug.Log("bhi_Pluton = " + bhi_Pluton);

        //if (Mathf.Abs(bhi_Pluton) >= 0.9f)
        //{
        //    hi_Pluton += PrirHi_Pluton;
        //}

        //else if (Mathf.Abs(bhi_Pluton) < 0.9f)
        //{
            hi_Pluton = 0.0001f;
        //}

        r_Pluton = ((vp_Pluton * hi_Pluton * vrSred_Pluton) + (Mathf.Pow(vp_Pluton, 2) / R_Pluton) * wRSred * Mathf.Pow(hi_Pluton, 2)) / 1.8f;

        f_Pluton += f2_Pluton /*(((vp_Pluton / R_Pluton) * (vtSred_Pluton / rSred_Pluton) * hi_Pluton) + (e_Pluton * Mathf.Pow(hi_Pluton, 2) / 2))*/;
        //Debug.Log("f2_Pluton = " + f2_Pluton * Mathf.Pow(10, 8));
        //Debug.Log("f_Pluton = " + f_Pluton * Mathf.Pow(10, 8));
        X1_Pluton = a_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8)) /** Mathf.Sin(110.30347f) + Pluto.transform.position.x / 1.55f*/;      //r_Pluton * ((Mathf.Cos(f_Pluton + 113.76329f) * Mathf.Cos(110.30347f)) - (Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Sin(113.76329f)));
        //Debug.Log("CoordinateX_Pluton = " + X1_Pluton);
        Y1_Pluton = b_Pluton * Mathf.Sin(f_Pluton * Mathf.Pow(10, 8)) /** Mathf.Sin(110.30347f) + Pluto.transform.position.z / 1.55f*/;     //r_Pluton * ((Mathf.Cos(f_Pluton + 113.76329f) * Mathf.Sin(110.30347f)) + (Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Cos(113.76329f)));
        //Debug.Log("CoordinateY_Pluton = " + Y1_Pluton);
        Z_Pluton = c_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(17.14f);
        //r_Pluton * Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Sin(17.14f);
        //Debug.Log("CoordinateZ_Pluton = " + Z_Pluton);

        //X1_Pluton = (a_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8) + 113.76329f) * Mathf.Cos(110.30347f) - Mathf.Sin(f_Pluton * Mathf.Pow(10, 8) + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Sin(110.30347f)) + Pluto.transform.position.x / 2f;//r_Pluton * ((Mathf.Cos(f_Pluton + 113.76329f) * Mathf.Cos(110.30347f)) - (Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Sin(113.76329f)));
        ////Debug.Log("CoordinateX_Pluton = " + CoordinateX_Pluton);
        //Y1_Pluton = (b_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8) + 113.76329f) * Mathf.Sin(110.30347f) + Mathf.Sin(f_Pluton * Mathf.Pow(10, 8) + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Cos(110.30347f)) + Pluto.transform.position.z / 2f;//r_Pluton * ((Mathf.Cos(f_Pluton + 113.76329f) * Mathf.Sin(110.30347f)) + (Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Cos(17.14f) * Mathf.Cos(113.76329f)));
        ////Debug.Log("CoordinateY_Pluton = " + CoordinateY_Pluton);
        //Z_Pluton = c_Pluton * Mathf.Sin(f_Pluton * Mathf.Pow(10, 8) + 113.76329f) * Mathf.Sin(17.14f);//r_Pluton * Mathf.Sin(f_Pluton + 113.76329f) * Mathf.Sin(17.14f);
        ////Debug.Log("CoordinateZ_Pluton = " + CoordinateZ_Pluton);

        Pluto.transform.position = new Vector3(X1_Pluton, Z_Pluton, Y1_Pluton);

        //X2_Pluton = X1_Pluton * Mathf.Cos(17.14f) - Y1_Pluton * Mathf.Sin(17.14f);

        //Y2_Pluton = X1_Pluton * Mathf.Sin(17.14f) + Y1_Pluton * Mathf.Cos(17.14f);

        distance_Pluton = Vector3.Distance(Pluto.transform.position, Sun.transform.position);
        //Debug.Log("distance_Pluton = " + distance_Pluton);
        //r1_Pluton = r2_Pluton;
        //r2_Pluton = r_Pluton;
        //rSred1_Pluton = r1_Pluton / R_Pluton;
        //rSred2_Pluton = r2_Pluton / R_Pluton;
        //f1_Pluton = f2_Pluton;
        //f2_Pluton = f_Pluton;
    }

    void EarthModelStart()
    {
        //Задаются начальные данные
        orbitalPeriod = 365.256363004f * 24 * 60 * 60;
        r = 149598261f * 1000f;
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massEarth = 5.9726f * Mathf.Pow(10, 24);

        R = (1 - 0.01671123f) * 149598261000f;
        // Debug.Log("R = " + R);
        h1 = -1.32633f * Mathf.Pow(10, 20);
        // Debug.Log("h1 = " + h1);
        a1 = -0.98328914068f; // h1 / (R * Mathf.Pow(vp, 2)); //-77.3030194662f
        // Debug.Log("a1 = " + a1);
        vp = ((-2 * a1 * Mathf.PI * R) / (orbitalPeriod * Mathf.Pow((-2 * a1) - 1, 1.5f)));
        //Debug.Log("vp = " + vp);
        rSred = r / R;//1 / (((a1 + 1) * Mathf.Cos(f)) - a1);
        //Debug.Log("rSred = " + rSred);

        hi = 0.0001f;//при i = 1 hi = h

        vtSred = 1 / rSred;
        //Debug.Log("vtSred = " + vtSred);

        vrSred = Mathf.Sqrt(Mathf.Pow(a1 + 1, 2) - Mathf.Pow((a1 + 1) / rSred, 2));
        //Debug.Log("vrSred = " + vrSred);

        e = -2 * Mathf.Pow((vp / R), 2) * vrSred / Mathf.Pow(rSred, 3);
        //Debug.Log("e = " + e);

        //Вычисление угла
        f = ((vp / R) * (vtSred / rSred) * hi) + (e * Mathf.Pow(hi, 2) / 2);
        //Debug.Log("f = " + f);
        Earth.transform.RotateAround(Sun_For_Earth.transform.position, Vector3.up, -2 * f * Mathf.Pow(10, 8));

        f1 = 0;
        // Debug.Log("f1 = " + f1);

        f2 = f;
        // Debug.Log("f2 = " + f2);

        PrirTi = (vp / R) * (TfSred(f2, a1) - TfSred(f1, a1));
        // Debug.Log("PrirTi = " + PrirTi);

        PrirHi = PrirTi - h;
        //  Debug.Log("PrirHi = " + PrirHi);

        hi -= PrirHi;
        // Debug.Log("hi = " + hi);
        f = ((vp / R) * (vtSred / rSred) * hi) + (e * Mathf.Pow(hi, 2)) / 2;
        f1 = f2;
        f2 = f;

        EPS = 0.9999775f;
    }
    void EarthModel()
    {
        Earth.transform.RotateAround(Sun_For_Earth.transform.position, Vector3.up, -2 * f * Mathf.Pow(10, 8));

        distance = Vector3.Distance(Earth.transform.position, Sun.transform.position);
        //Debug.Log("distance = " + distance);
        r = distance * 4903276333.33f;
        rSred = r / R;

        if (rSred < 1)
        {
            rSred = 1;
        }

        vtSred = 1 / rSred;
        //Debug.Log("vtSred = " + vtSred);

        vrSred = Mathf.Sqrt(Mathf.Pow(a1 + 1, 2) - Mathf.Pow((a1 + 1) / rSred, 2));
        //Debug.Log("vrSred = " + vrSred);

        e = -2 * Mathf.Pow((vp / R), 2) * vrSred / Mathf.Pow(rSred, 3);
        //Debug.Log("e = " + e);

        PrirTi = (vp / R) * (TfSred(f2, a1) - TfSred(f1, a1));
        // Debug.Log("PrirTi = " + PrirTi);

        PrirHi = PrirTi - h;
        // Debug.Log("PrirHi = " + PrirHi);

        bhi = PrirHi / h;
        // Debug.Log("bhi = " + bhi);

        if (Mathf.Abs(bhi) >= 1f)
        {
            hi -= PrirHi;
        }

        else if (Mathf.Abs(bhi) < 1f)
        {
            hi = h;
        }
        hi = 0.1f;
        // Debug.Log("hi = " + hi);
        f = ((vp / R) * (vtSred / rSred) * hi) + (e * Mathf.Pow(hi, 2)) / 2;
        Debug.Log("f = " + f);
        //f1 = f2;
        //f2 = f;
    }

}
