using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    public GameObject Mercury;
    public GameObject Venus;
    public GameObject Earth;
    public GameObject Mars;
    public GameObject Jupiter;
    public GameObject Saturn;
    public GameObject Uranus;
    public GameObject Neptune;
    public GameObject Pluto;
    public GameObject Sun;
    public GameObject Sun_For_Earth;

    //Общие данные для всех объектов
    public float massSun = 1.9885f * Mathf.Pow(10, 30);
    public float G = 6.67f * Mathf.Pow(10, -11);//гравитационная постоянная
    public float h = 1f; //начальное h

    //Данные для Меркурия
    public float a_Mercury; //Большая полуось
    public float b_Mercury; //Малая полуось
    public float c_Mercury; //Полуось, что идёт по оси Z в эллипсоиде
    public float vp_Mercury; //скорость планеты в перигелии (ближ. точка)
    public float vt_Mercury; //Трансверсальная скорость
    public float r_Mercury; //√(x*x+y*y+z*z)
    public float R_Mercury; //радиус перигелия
    public float f_Mercury = 0;
    public float f1_Mercury;
    public float f2_Mercury;
    public float massMercury = 5.9726f * Mathf.Pow(10, 24);
    public float h1_Mercury;
    public float hi_Mercury; //значение приращения времени в i-той итерации
    public float a1_Mercury;
    public float rSred_Mercury;
    public float vtSred_Mercury;
    public float e_Mercury; // угловое ускорение
    public float PrirHi_Mercury; //Δhi
    public float PrirTi_Mercury; //Δti
    public float vrSred_Mercury;
    public float TSred1_Mercury;
    public float TSred2_Mercury;
    public float bhi_Mercury;
    public float EPS_Mercury;
    public float distance;
    public float orbitalPeriod_Mercury;
    public float X1_Mercury;
    public float Y1_Mercury;
    public float Z1_Mercury;

    //Данные для Венеры
    public float a_Venus; //Большая полуось
    public float b_Venus; //Малая полуось
    public float c_Venus; //Полуось, что идёт по оси Z в эллипсоиде
    public float vp_Venus; //скорость планеты в перигелии (ближ. точка)
    public float vt_Venus; //Трансверсальная скорость
    public float r_Venus; //√(x*x+y*y+z*z)
    public float R_Venus; //радиус перигелия
    public float f_Venus = 0;
    public float f1_Venus;
    public float f2_Venus;
    public float massVenus = 5.9726f * Mathf.Pow(10, 24);
    public float h1_Venus;
    public float hi_Venus; //значение приращения времени в i-той итерации
    public float a1_Venus;
    public float rSred_Venus;
    public float vtSred_Venus;
    public float e_Venus; // угловое ускорение
    public float vrSred_Venus;
    public float orbitalPeriod_Venus;
    public float X1_Venus;
    public float Y1_Venus;
    public float Z1_Venus;

    //Данные для Земли
    public float a; //Большая полуось
    public float b; //Малая полуось
    public float c; //Полуось, что идёт по оси Z в эллипсоиде
    public float vp; //скорость планеты в перигелии (ближ. точка)
    public float vt; //Трансверсальная скорость
    public float r; //√(x*x+y*y+z*z)
    public float R; //радиус перигелия
    public float f = 0;
    public float f1;
    public float f2;
    public float massEarth = 5.9726f * Mathf.Pow(10,24);
    public float h1;
    public float hi; //значение приращения времени в i-той итерации
    public float a1;
    public float rSred;
    public float vtSred;
    public float e; // угловое ускорение
    public float vrSred;
    public float orbitalPeriod;
    public float X1;
    public float Y1;
    public float Z1;

    //Данные для Марса
    public float a_Mars; //Большая полуось
    public float b_Mars; //Малая полуось
    public float c_Mars; //Полуось, что идёт по оси Z в эллипсоиде
    public float vp_Mars; //скорость планеты в перигелии (ближ. точка)
    public float vt_Mars; //Трансверсальная скорость
    public float r_Mars; //√(x*x+y*y+z*z)
    public float R_Mars; //радиус перигелия
    public float f_Mars = 0;
    public float f1_Mars;
    public float f2_Mars;
    public float massMars = 5.9726f * Mathf.Pow(10, 24);
    public float h1_Mars;
    public float hi_Mars; //значение приращения времени в i-той итерации
    public float a1_Mars;
    public float rSred_Mars;
    public float vtSred_Mars;
    public float e_Mars; // угловое ускорение
    public float vrSred_Mars;
    public float orbitalPeriod_Mars;
    public float X1_Mars;
    public float Y1_Mars;
    public float Z1_Mars;

    //Данные для Юпитера
    public float a_Jupiter; //Большая полуось
    public float b_Jupiter; //Малая полуось
    public float c_Jupiter; //Полуось, что идёт по оси Z в эллипсоиде
    public float vp_Jupiter; //скорость планеты в перигелии (ближ. точка)
    public float vt_Jupiter; //Трансверсальная скорость
    public float r_Jupiter; //√(x*x+y*y+z*z)
    public float R_Jupiter; //радиус перигелия
    public float f_Jupiter = 0;
    public float f1_Jupiter;
    public float f2_Jupiter;
    public float massJupiter = 5.9726f * Mathf.Pow(10, 24);
    public float h1_Jupiter;
    public float hi_Jupiter; //значение приращения времени в i-той итерации
    public float a1_Jupiter;
    public float rSred_Jupiter;
    public float vtSred_Jupiter;
    public float e_Jupiter; // угловое ускорение
    public float vrSred_Jupiter;
    public float orbitalPeriod_Jupiter;
    public float X1_Jupiter;
    public float Y1_Jupiter;
    public float Z1_Jupiter;

    //Данные для Сатурна
    public float a_Saturn; //Большая полуось
    public float b_Saturn; //Малая полуось
    public float c_Saturn; //Полуось, что идёт по оси Z в эллипсоиде
    public float vp_Saturn; //скорость планеты в перигелии (ближ. точка)
    public float vt_Saturn; //Трансверсальная скорость
    public float r_Saturn; //√(x*x+y*y+z*z)
    public float R_Saturn; //радиус перигелия
    public float f_Saturn = 0;
    public float f1_Saturn;
    public float f2_Saturn;
    public float massSaturn = 5.9726f * Mathf.Pow(10, 24);
    public float h1_Saturn;
    public float hi_Saturn; //значение приращения времени в i-той итерации
    public float a1_Saturn;
    public float rSred_Saturn;
    public float vtSred_Saturn;
    public float e_Saturn; // угловое ускорение
    public float vrSred_Saturn;
    public float orbitalPeriod_Saturn;
    public float X1_Saturn;
    public float Y1_Saturn;
    public float Z1_Saturn;

    //Данные для Урана
    public float a_Uranus; //Большая полуось
    public float b_Uranus; //Малая полуось
    public float c_Uranus; //Полуось, что идёт по оси Z в эллипсоиде
    public float vp_Uranus; //скорость планеты в перигелии (ближ. точка)
    public float vt_Uranus; //Трансверсальная скорость
    public float r_Uranus; //√(x*x+y*y+z*z)
    public float R_Uranus; //радиус перигелия
    public float f_Uranus = 0;
    public float f1_Uranus;
    public float f2_Uranus;
    public float massUranus = 5.9726f * Mathf.Pow(10, 24);
    public float h1_Uranus;
    public float hi_Uranus; //значение приращения времени в i-той итерации
    public float a1_Uranus;
    public float rSred_Uranus;
    public float vtSred_Uranus;
    public float e_Uranus; // угловое ускорение
    public float vrSred_Uranus;
    public float orbitalPeriod_Uranus;
    public float X1_Uranus;
    public float Y1_Uranus;
    public float Z1_Uranus;

    //Данные для Нептуна
    public float a_Neptune; //Большая полуось
    public float b_Neptune; //Малая полуось
    public float c_Neptune; //Полуось, что идёт по оси Z в эллипсоиде
    public float vp_Neptune; //скорость планеты в перигелии (ближ. точка)
    public float vt_Neptune; //Трансверсальная скорость
    public float r_Neptune; //√(x*x+y*y+z*z)
    public float R_Neptune; //радиус перигелия
    public float f_Neptune = 0;
    public float f1_Neptune;
    public float f2_Neptune;
    public float massNeptune = 5.9726f * Mathf.Pow(10, 24);
    public float h1_Neptune;
    public float hi_Neptune; //значение приращения времени в i-той итерации
    public float a1_Neptune;
    public float rSred_Neptune;
    public float vtSred_Neptune;
    public float e_Neptune; // угловое ускорение
    public float vrSred_Neptune;
    public float orbitalPeriod_Neptune;
    public float X1_Neptune;
    public float Y1_Neptune;
    public float Z1_Neptune;

    //Данные для Плутона
    public float a_Pluton; //Большая полуось
    public float b_Pluton; //Малая полуось
    public float c_Pluton;
    public float vp_Pluton; //скорость планеты в перигелии (ближ. точка)
    public float vt_Pluton; //Трансверсальная скорость
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

    public int scaleParameter = 130;

    // Start is called before the first frame update
    void Start()
    {
        MercuryModelStart();
        VenusModelStart();
        EarthModelStart();
        MarsModelStart();
        JupiterModelStart();
        SaturnModelStart();
        UranusModelStart();
        NeptuneModelStart();
        PlutoModelStart();
    }

    // Update is called once per frame
    void Update()
    {
        MercuryModel();
        VenusModel();
        EarthModel();
        MarsModel();
        JupiterModel();
        SaturnModel();
        UranusModel();
        NeptuneModel();
        PlutoModel();
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

    void MercuryModelStart()
    {
        //Задаются начальные данные
        a_Mercury = 0.38709927f * scaleParameter;
        b_Mercury = a_Mercury * Mathf.Sqrt(1 - Mathf.Pow(0.20563593f, 2));
        c_Mercury = (b_Mercury / Mathf.Cos(7f)) * Mathf.Sin(7f);

        orbitalPeriod_Mercury = 87.969f * 24f * 3600f;
        r_Mercury = 57909227000f;
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massMercury = 3.33022f * Mathf.Pow(10, 23);

        R_Mercury = (1 - 0.20563593f) * 57909227000f;
        h1_Mercury = -G * (massSun + massMercury);

        a1_Mercury = h1_Mercury / (R_Mercury * Mathf.Pow(53696.0123342f, 2));

        vp_Mercury = -2 * a1_Mercury * Mathf.PI * R_Mercury / (orbitalPeriod_Mercury * Mathf.Pow((-2 * a1_Mercury) - 1, 1.5f));

        rSred_Mercury = r_Mercury / R_Mercury;

        hi_Mercury = 1f;

        vt_Mercury = vp_Mercury / rSred_Mercury;

        vtSred_Mercury = (vt_Mercury / vp_Mercury);

        vrSred_Mercury = Mathf.Sqrt(Mathf.Pow(a1_Mercury + 1, 2) - Mathf.Pow((a1_Mercury + 1) / rSred_Mercury, 2));

        e_Mercury = -2 * Mathf.Pow((vp_Mercury / R_Mercury), 2) * vrSred_Mercury / Mathf.Pow(rSred_Mercury, 3);

        //Вычисление угла

        f_Mercury = f_Mercury + (vp_Mercury / R_Mercury) * (vtSred_Mercury / rSred_Mercury) * hi_Mercury + e_Mercury * Mathf.Pow(hi_Mercury, 2) / 2;
        Debug.Log("Начальное f = " + f_Mercury);
        X1_Mercury = a_Mercury * Mathf.Cos(f_Mercury * Mathf.Pow(10, 6));

        Y1_Mercury = b_Mercury * Mathf.Sin(f_Mercury * Mathf.Pow(10, 6));

        Z1_Mercury = c_Mercury * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(7f);

        Mercury.transform.position = new Vector3(X1_Mercury, Z1_Mercury, Y1_Mercury);

        f1_Mercury = f2_Mercury;
        f2_Mercury = f_Mercury;
    }
    void MercuryModel()
    {
        f_Mercury += f2_Mercury;

        X1_Mercury = a_Mercury * Mathf.Cos(f_Mercury * Mathf.Pow(10, 8));

        Y1_Mercury = b_Mercury * Mathf.Sin(f_Mercury * Mathf.Pow(10, 8));

        Z1_Mercury = c_Mercury * Mathf.Cos(f_Mercury * Mathf.Pow(10, 8)) * Mathf.Sin(17.14f);

        Mercury.transform.position = new Vector3(X1_Mercury, Z1_Mercury, Y1_Mercury);
    }

    void VenusModelStart()
    {
        //Задаются начальные данные
        a_Venus = 0.723332f * scaleParameter;
        b_Venus = a_Venus * Mathf.Sqrt(1 - Mathf.Pow(0.0068f, 2));
        c_Venus = (b_Venus / Mathf.Cos(3.39458f)) * Mathf.Sin(3.39458f);

        orbitalPeriod_Venus = 224.698f * 24f * 3600f;
        r_Venus = 108208930000f;
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massVenus = 4.8675f * Mathf.Pow(10, 24);

        R_Venus = (1 - 0.0068f) * 108208930000f;
        h1_Venus = -G * (massSun + massVenus);
        a1_Venus = h1_Venus / (R_Venus * Mathf.Pow(35129.8105621f, 2));
        vp_Venus = -2 * a1_Venus * Mathf.PI * R_Venus / (orbitalPeriod_Venus * Mathf.Pow((-2 * a1_Venus) - 1, 1.5f));
        rSred_Venus = r_Venus / R_Venus;
        hi_Venus = 1f;

        vt_Venus = vp_Venus / rSred_Venus;
        vtSred_Venus = (vt_Venus / vp_Venus);//Влиятельная переменная

        vrSred_Venus = Mathf.Sqrt(Mathf.Pow(a1_Venus + 1, 2) - Mathf.Pow((a1_Venus + 1) / rSred_Venus, 2));

        e_Venus = -2 * Mathf.Pow((vp_Venus / R_Venus), 2) * vrSred_Venus / Mathf.Pow(rSred_Venus, 3);

        //Вычисление угла

        f_Venus = f_Venus + (vp_Venus / R_Venus) * (vtSred_Venus / rSred_Venus) * hi_Venus + e_Venus * Mathf.Pow(hi_Venus, 2) / 2;

        X1_Venus = a_Venus * Mathf.Cos(f_Venus * Mathf.Pow(10, 6));
        Y1_Venus = b_Venus * Mathf.Sin(f_Venus * Mathf.Pow(10, 6));
        Z1_Venus = c_Venus * Mathf.Cos(f_Venus * Mathf.Pow(10, 6)) * Mathf.Sin(3.39458f);

        Venus.transform.position = new Vector3(X1_Venus, Z1_Venus, Y1_Venus);

        f1_Venus = f2_Venus;
        f2_Venus = f_Venus;
    }

    void VenusModel()
    {
        f_Venus += f2_Venus;

        X1_Venus = a_Venus * Mathf.Cos(f_Venus * Mathf.Pow(10, 8));
        Y1_Venus = b_Venus * Mathf.Sin(f_Venus * Mathf.Pow(10, 8));
        Z1_Venus = c_Venus * Mathf.Cos(f_Venus * Mathf.Pow(10, 8)) * Mathf.Sin(17.14f);

        Venus.transform.position = new Vector3(X1_Venus, Z1_Venus, Y1_Venus);
    }

    void EarthModelStart()
    {
        //Задаются начальные данные
        a = 1.00000261f * scaleParameter;
        b = a * Mathf.Sqrt(1 - Mathf.Pow(0.01671123f, 2)); //b = 0.99986296728f * scaleParameter;

        orbitalPeriod = 365.256363004f * 24f * 3600f;
        r = 149598261000f;
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massEarth = 5.9726f * Mathf.Pow(10, 24);

        R = (1 - 0.01671123f) * 149597870700f;
        //Debug.Log("R = " + R);
        h1 = -G * (massSun + massEarth);
        Debug.Log("h1 = " + h1); 
        a1 = h1 / (R * Mathf.Pow(30027f, 2)); //-77.3030194662f
        //Debug.Log("a1 = " + a1);
        vp = -2 * a1 * Mathf.PI * R / (orbitalPeriod * Mathf.Pow((-2 * a1) - 1, 1.5f));
        //Debug.Log("vp = " + vp);
        //Debug.Log("vp = " + vp);
        rSred = r / R;
        Debug.Log("rSred = " + rSred);
        hi = 1f;

        vt = vp / rSred;
        //Debug.Log("vt = " + vt);
        vtSred = (vt / vp);//Влиятельная переменная
        //Debug.Log("vtSred = " + vtSred);

        vrSred = Mathf.Sqrt(Mathf.Pow(a1 + 1, 2) - Mathf.Pow((a1 + 1) / rSred, 2));
        //Debug.Log("vrSred = " + vrSred);

        e = -2 * Mathf.Pow((vp / R), 2) * vrSred / Mathf.Pow(rSred, 2) /*(2 * Mathf.PI) / orbitalPeriod*/;
        Debug.Log("e = " + e);

        //Вычисление угла

        f = f + (vp / R) * (vtSred / rSred) * hi + e * Mathf.Pow(hi, 2) / 2;
        Debug.Log("Начальное f = " + f);
        X1 = a * Mathf.Cos(f * Mathf.Pow(10, 6));
        //Debug.Log("X1_Pluton = " + X1_Pluton);

        Y1 = b * Mathf.Sin(f * Mathf.Pow(10, 6));
        //Debug.Log("Y1_Pluton = " + Y1_Pluton);

        Earth.transform.position = new Vector3(X1, 0, Y1);

        f1 = f2;
        f2 = f;
    }
    void EarthModel()
    {
        f += f2 /* ((vp / R) * (vtSred / rSred) * hi) + (e * Mathf.Pow(hi, 2)) / 2 */;
        if (f > 360)
        {
            f -= 360;
        }

        X1 = a * Mathf.Cos(f * Mathf.Pow(10, 6));

        Y1 = b * Mathf.Sin(f *  Mathf.Pow(10, 6));



        Earth.transform.position = new Vector3(X1, 0, Y1);
    }

    void MarsModelStart()
    {
        //Задаются начальные данные
        a_Mars = 1.523662f * scaleParameter;
        b_Mars = a * Mathf.Sqrt(1 - Mathf.Pow(0.0933941f, 2));
        c_Mars = (b_Mars / Mathf.Cos(1.85061f)) * Mathf.Sin(1.85061f);

        orbitalPeriod_Mars = 779.94f * 24f * 3600f;
        r_Mars = 227943820000f;
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massMars = 6.4171f * Mathf.Pow(10, 23);

        R_Mars = (1 - 0.0933941f) * 227943820000f;
        h1_Mars = -G * (massSun + massMars);
        a1_Mars = h1_Mars / (R_Mars * Mathf.Pow(25333.9280645f, 2));
        vp_Mars = -2 * a1_Mars * Mathf.PI * R_Mars / (orbitalPeriod_Mars * Mathf.Pow((-2 * a1_Mars) - 1, 1.5f));
        rSred_Mars = r_Mars / R_Mars;
        hi_Mars = 1f;

        vt_Mars = vp_Mars / rSred_Mars;
        vtSred_Mars = (vt_Mars / vp_Mars);//Влиятельная переменная
        vrSred_Mars = Mathf.Sqrt(Mathf.Pow(a1_Mars + 1, 2) - Mathf.Pow((a1_Mars + 1) / rSred_Mars, 2));
        e_Mars = -2 * Mathf.Pow((vp_Mars / R_Mars), 2) * vrSred_Mars / Mathf.Pow(rSred_Mars, 3);

        //Вычисление угла

        f_Mars = f_Mars + (vp_Mars / R_Mars) * (vtSred_Mars / rSred_Mars) * hi_Mars + e_Mars * Mathf.Pow(hi_Mars, 2) / 2;

        X1_Mars = a_Mars * Mathf.Cos(f_Mars * Mathf.Pow(10, 6));
        Y1_Mars = b_Mars * Mathf.Sin(f_Mars * Mathf.Pow(10, 6));
        Z1_Mars = c_Mars * Mathf.Cos(f_Mars * Mathf.Pow(10, 8)) * Mathf.Sin(1.85061f);

        Mars.transform.position = new Vector3(X1_Mars, Z1_Mars, Y1_Mars);

        f1_Mars = f2_Mars;
        f2_Mars = f_Mars;
    }
    void MarsModel()
    {
        f_Mars += f2_Mars;

        X1_Mars = a_Mars * Mathf.Cos(f_Mars * Mathf.Pow(10, 6));
        Y1_Mars = b_Mars * Mathf.Sin(f_Mars * Mathf.Pow(10, 6));
        Z1_Mars = c_Mars * Mathf.Cos(f_Mars * Mathf.Pow(10, 6)) * Mathf.Sin(17.14f);

        Mars.transform.position = new Vector3(X1_Mars, Z1_Mars, Y1_Mars);
    }

    void JupiterModelStart()
    {
        //Задаются начальные данные
        a_Jupiter = 5.204267f * scaleParameter;
        b_Jupiter = a * Mathf.Sqrt(1 - Mathf.Pow(0.048775f, 2));
        c_Jupiter = (b_Jupiter / Mathf.Cos(1.304f)) * Mathf.Sin(1.304f);

        orbitalPeriod_Jupiter = 4332.589f * 24f * 3600f;
        r_Jupiter = 778547200000f;
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massJupiter = 1.8986f * Mathf.Pow(10, 27);

        R_Jupiter = (1 - 0.048775f) * 778547200000f;
        h1_Jupiter = -G * (massSun + massJupiter);
        a1_Jupiter = h1_Jupiter / (R_Jupiter * Mathf.Pow(13382.6343844f, 2));
        vp_Jupiter = -2 * a1_Jupiter * Mathf.PI * R_Jupiter / (orbitalPeriod_Jupiter * Mathf.Pow((-2 * a1_Jupiter) - 1, 1.5f));
        rSred_Jupiter = r_Jupiter / R_Jupiter;
        hi_Jupiter = 1f;

        vt_Jupiter = vp_Jupiter / rSred_Jupiter;
        vtSred_Jupiter = (vt_Jupiter / vp_Jupiter);//Влиятельная переменная
        vrSred_Jupiter = Mathf.Sqrt(Mathf.Pow(a1_Jupiter + 1, 2) - Mathf.Pow((a1_Jupiter + 1) / rSred_Jupiter, 2));
        e_Jupiter = -2 * Mathf.Pow((vp_Jupiter / R_Jupiter), 2) * vrSred_Jupiter / Mathf.Pow(rSred_Jupiter, 3);

        //Вычисление угла

        f_Jupiter = f_Jupiter + (vp_Jupiter / R_Jupiter) * (vtSred_Jupiter / rSred_Jupiter) * hi_Jupiter + e_Jupiter * Mathf.Pow(hi_Jupiter, 2) / 2;

        X1_Jupiter = a_Jupiter * Mathf.Cos(f_Jupiter * Mathf.Pow(10, 6));
        Y1_Jupiter = b_Jupiter * Mathf.Sin(f_Jupiter * Mathf.Pow(10, 6));
        Z1_Jupiter = c_Jupiter * Mathf.Cos(f_Jupiter * Mathf.Pow(10, 8)) * Mathf.Sin(1.304f);

        Jupiter.transform.position = new Vector3(X1_Jupiter, Z1_Jupiter, Y1_Jupiter);

        f1_Jupiter = f2_Jupiter;
        f2_Jupiter = f_Jupiter;
    }
    void JupiterModel()
    {
        f_Jupiter += f2_Jupiter;

        X1_Jupiter = a_Jupiter * Mathf.Cos(f_Jupiter * Mathf.Pow(10, 6));
        Y1_Jupiter = b_Jupiter * Mathf.Sin(f_Jupiter * Mathf.Pow(10, 6));
        Z1_Jupiter = c_Jupiter * Mathf.Cos(f_Jupiter * Mathf.Pow(10, 6)) * Mathf.Sin(17.14f);

        Jupiter.transform.position = new Vector3(X1_Jupiter, Z1_Jupiter, Y1_Jupiter);
    }

    void SaturnModelStart()
    {
        //Задаются начальные данные
        a_Saturn = 9.58f * scaleParameter;
        b_Saturn = a * Mathf.Sqrt(1 - Mathf.Pow(0.055723219f, 2));
        c_Saturn = (b_Saturn / Mathf.Cos(2.485240f)) * Mathf.Sin(2.485240f);

        orbitalPeriod_Saturn = 10759.22f * 24f * 3600f;
        r_Saturn = 1426666414179.9f;
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massSaturn = 5.6846f * Mathf.Pow(10, 26);

        R_Saturn = (1 - 0.055723219f) * 1426666414179.9f;
        h1_Saturn = -G * (massSun + massSaturn);
        a1_Saturn = h1_Saturn / (R_Saturn * Mathf.Pow(9922.3567002f, 2));
        vp_Saturn = -2 * a1_Saturn * Mathf.PI * R_Saturn / (orbitalPeriod_Saturn * Mathf.Pow((-2 * a1_Saturn) - 1, 1.5f));
        rSred_Saturn = r_Saturn / R_Saturn;
        hi_Saturn = 1f;

        vt_Saturn = vp_Saturn / rSred_Saturn;
        vtSred_Saturn = (vt_Saturn / vp_Saturn);//Влиятельная переменная
        vrSred_Saturn = Mathf.Sqrt(Mathf.Pow(a1_Saturn + 1, 2) - Mathf.Pow((a1_Saturn + 1) / rSred_Saturn, 2));
        e_Saturn = -2 * Mathf.Pow((vp_Saturn / R_Saturn), 2) * vrSred_Saturn / Mathf.Pow(rSred_Saturn, 3);

        //Вычисление угла

        f_Saturn = f_Saturn + (vp_Saturn / R_Saturn) * (vtSred_Saturn / rSred_Saturn) * hi_Saturn + e_Saturn * Mathf.Pow(hi_Saturn, 2) / 2;

        X1_Saturn = a_Saturn * Mathf.Cos(f_Saturn * Mathf.Pow(10, 6));
        Y1_Saturn = b_Saturn * Mathf.Sin(f_Saturn * Mathf.Pow(10, 6));
        Z1_Saturn = c_Saturn * Mathf.Cos(f_Saturn * Mathf.Pow(10, 8)) * Mathf.Sin(2.485240f);

        Saturn.transform.position = new Vector3(X1_Saturn, Z1_Saturn, Y1_Saturn);

        f1_Saturn = f2_Saturn;
        f2_Saturn = f_Saturn;
    }
    void SaturnModel()
    {
        f_Saturn += f2_Saturn;

        X1_Saturn = a_Saturn * Mathf.Cos(f_Saturn * Mathf.Pow(10, 6));
        Y1_Saturn = b_Saturn * Mathf.Sin(f_Saturn * Mathf.Pow(10, 6));
        Z1_Saturn = c_Saturn * Mathf.Cos(f_Saturn * Mathf.Pow(10, 6)) * Mathf.Sin(17.14f);

        Saturn.transform.position = new Vector3(X1_Saturn, Z1_Saturn, Y1_Saturn);
    }

    void UranusModelStart()
    {
        //Задаются начальные данные
        a_Uranus = 19.22941195f * scaleParameter;
        b_Uranus = a_Uranus * Mathf.Sqrt(1 - Mathf.Pow(0.044405586f, 2));
        c_Uranus = (b_Uranus / Mathf.Cos(0.772556f)) * Mathf.Sin(0.772556f);

        orbitalPeriod_Uranus = 30685.4f * 24f * 3600f;
        r_Uranus = 2876679082000f;
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massUranus = 8.6813f * Mathf.Pow(10, 25);

        R_Uranus = (1 - 0.044405586f) * 2876679082000f;
        h1_Uranus = -G * (massSun + massUranus);
        a1_Uranus = h1_Uranus / (R_Uranus * Mathf.Pow(6946.13472864f, 2));
        vp_Uranus = -2 * a1_Uranus * Mathf.PI * R_Uranus / (orbitalPeriod_Uranus * Mathf.Pow((-2 * a1_Uranus) - 1, 1.5f));
        rSred_Uranus = r_Uranus / R_Uranus;
        hi_Uranus = 1f;

        vt_Uranus = vp_Uranus / rSred_Uranus;
        vtSred_Uranus = (vt_Uranus / vp_Uranus);//Влиятельная переменная
        vrSred_Uranus = Mathf.Sqrt(Mathf.Pow(a1_Uranus + 1, 2) - Mathf.Pow((a1_Uranus + 1) / rSred_Uranus, 2));
        e_Uranus = -2 * Mathf.Pow((vp_Uranus / R_Uranus), 2) * vrSred_Uranus / Mathf.Pow(rSred_Uranus, 3);

        //Вычисление угла

        f_Uranus = f_Uranus + (vp_Uranus / R_Uranus) * (vtSred_Uranus / rSred_Uranus) * hi_Uranus + e_Uranus * Mathf.Pow(hi_Uranus, 2) / 2;

        X1_Uranus = a_Uranus * Mathf.Cos(f_Uranus * Mathf.Pow(10, 6));
        Y1_Uranus = b_Uranus * Mathf.Sin(f_Uranus * Mathf.Pow(10, 6));
        Z1_Uranus = c_Uranus * Mathf.Cos(f_Uranus * Mathf.Pow(10, 8)) * Mathf.Sin(0.772556f);

        Uranus.transform.position = new Vector3(X1_Uranus, Z1_Uranus, Y1_Uranus);

        f1_Uranus = f2_Uranus;
        f2_Uranus = f_Uranus;
    }
    void UranusModel()
    {
        f_Uranus += f2_Uranus;

        X1_Uranus = a_Uranus * Mathf.Cos(f_Uranus * Mathf.Pow(10, 6));
        Y1_Uranus = b_Uranus * Mathf.Sin(f_Uranus * Mathf.Pow(10, 6));
        Z1_Uranus = c_Uranus * Mathf.Cos(f_Uranus * Mathf.Pow(10, 6)) * Mathf.Sin(17.14f);

        Uranus.transform.position = new Vector3(X1_Uranus, Z1_Uranus, Y1_Uranus);
    }

    void NeptuneModelStart()
    {
        //Задаются начальные данные
        a_Neptune = 30.10366151f * scaleParameter;
        b_Neptune = a_Neptune * Mathf.Sqrt(1 - Mathf.Pow(0.011214269f, 2));
        c_Neptune = (b_Neptune / Mathf.Cos(1.767975f)) * Mathf.Sin(1.767975f);

        orbitalPeriod_Neptune = 60190.03f * 24f * 3600f;
        r_Neptune = 4503443661000f;
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massNeptune = 5.9726f * Mathf.Pow(10, 24);

        R_Neptune = (1 - 0.011214269f) * 4503443661000f;
        h1_Neptune = -G * (massSun + massNeptune);
        a1_Neptune = h1_Neptune / (R_Neptune * Mathf.Pow(5457.60693492f, 2));
        vp_Neptune = -2 * a1_Neptune * Mathf.PI * R_Neptune / (orbitalPeriod_Neptune * Mathf.Pow((-2 * a1_Neptune) - 1, 1.5f));
        rSred_Neptune = r_Neptune / R_Neptune;
        hi_Neptune = 1f;

        vt_Neptune = vp_Neptune / rSred_Neptune;
        vtSred_Neptune = (vt_Neptune / vp_Neptune);//Влиятельная переменная
        vrSred_Neptune = Mathf.Sqrt(Mathf.Pow(a1_Neptune + 1, 2) - Mathf.Pow((a1_Neptune + 1) / rSred_Neptune, 2));
        e_Neptune = -2 * Mathf.Pow((vp_Neptune / R_Neptune), 2) * vrSred_Neptune / Mathf.Pow(rSred_Neptune, 3);

        //Вычисление угла

        f_Neptune = f_Neptune + (vp_Neptune / R_Neptune) * (vtSred_Neptune / rSred_Neptune) * hi_Neptune + e_Neptune * Mathf.Pow(hi_Neptune, 2) / 2;

        X1_Neptune = a_Neptune * Mathf.Cos(f_Neptune * Mathf.Pow(10, 6));
        Y1_Neptune = b_Neptune * Mathf.Sin(f_Neptune * Mathf.Pow(10, 6));
        Z1_Neptune = c_Neptune * Mathf.Cos(f_Neptune * Mathf.Pow(10, 8)) * Mathf.Sin(1.767975f);

        Neptune.transform.position = new Vector3(X1_Neptune, Z1_Neptune, Y1_Neptune);

        f1_Neptune = f2_Neptune;
        f2_Neptune = f_Neptune;
    }
    void NeptuneModel()
    {
        f_Neptune += f2_Neptune;

        X1_Neptune = a_Neptune * Mathf.Cos(f_Neptune * Mathf.Pow(10, 6));
        Y1_Neptune = b_Neptune * Mathf.Sin(f_Neptune * Mathf.Pow(10, 6));
        Z1_Neptune = c_Neptune * Mathf.Cos(f_Neptune * Mathf.Pow(10, 6)) * Mathf.Sin(17.14f);

        Neptune.transform.position = new Vector3(X1_Neptune, Z1_Neptune, Y1_Neptune);
    }

    void PlutoModelStart()
    {
        f_Pluton = 0;
        a_Pluton = 39.482117f * scaleParameter;
        b_Pluton = a_Pluton * Mathf.Sqrt(1 - Mathf.Pow(0.2488273f, 2));
        Debug.Log("b_Pluton = " + b_Pluton);
        c_Pluton = 11.1189074357f;

        orbitalPeriod_Pluton = 90553.02f * 24f * 3600f;
        r_Pluton = 5.9064406f * Mathf.Pow(10, 12);//В а.е. = 29.667f
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massPluto = 1.303f * Mathf.Pow(10, 22);

        R_Pluton = (1 - 0.2488273f) * r_Pluton;//
        h1_Pluton = -G * (massSun + massPluto);
        a1_Pluton = h1_Pluton / (R_Pluton * Mathf.Pow(4669.1f, 2));//Vp = 1726.6724904f - старое значение
        //Debug.Log("a1_Pluton = " + a1_Pluton);
        vp_Pluton = 5467.55169498f;//(-2 * a1_Pluton * Mathf.PI * R_Pluton) / (orbitalPeriod_Pluton * Mathf.Pow((-2 * a1_Pluton) - 1, 1.5f)); // 1726.6724904f
        Debug.Log("vp_Pluton = " + vp_Pluton);
        rSred_Pluton = r_Pluton / R_Pluton;
        Debug.Log("rSred_Pluton = " + rSred_Pluton);

        hi_Pluton = 1f;

        vtSred_Pluton = 1 / rSred_Pluton;
        vrSred_Pluton = Mathf.Sqrt(Mathf.Pow(a1_Pluton + 1, 2) - Mathf.Pow((a1_Pluton + 1) / rSred_Pluton, 2));
        //Debug.Log("vrSred_Pluton = " + vrSred_Pluton);
        wRSred = (a1_Pluton + 1 / rSred_Pluton) / Mathf.Pow(rSred_Pluton, 2);//-3444729194,89
        //Debug.Log("wRSred = " + wRSred);

        r_Pluton = ((vp_Pluton * hi_Pluton * vrSred_Pluton) + (Mathf.Pow(vp_Pluton, 2) / R_Pluton) * wRSred * Mathf.Pow(hi_Pluton, 2)) / 2f;
        //Debug.Log("r_Pluton = " + r_Pluton);
        e_Pluton = (2 * Mathf.PI) / orbitalPeriod_Pluton;

        f_Pluton = f_Pluton + ((vp_Pluton / R_Pluton) * (vtSred_Pluton / rSred_Pluton) * hi_Pluton) + (e_Pluton * Mathf.Pow(hi_Pluton, 2) / 2);

        Debug.Log("Совсем начальное f_Pluton = " + f_Pluton);
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
    }

    void PlutoModel()
    {
        f_Pluton += f2_Pluton;

        X1_Pluton = a_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8));

        Y1_Pluton = b_Pluton * Mathf.Sin(f_Pluton * Mathf.Pow(10, 8));

        Z_Pluton = c_Pluton * Mathf.Cos(f_Pluton * Mathf.Pow(10, 8)) * Mathf.Sin(17.14f);

        Pluto.transform.position = new Vector3(X1_Pluton, Z_Pluton, Y1_Pluton);

        //distance_Pluton = Vector3.Distance(Pluto.transform.position, Sun.transform.position);
    }

}
