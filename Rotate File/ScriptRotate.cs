
    void MercuryModelStart()
    {
        //Задаются начальные данные
        a_Mercury = 0.38709927f * 400f;
        b_Mercury = a_Mercury * Mathf.Sqrt(1 - Mathf.Pow(0.20563593f, 2));
        c_Mercury = (6.17887640771f / 130f) * 516.66333548f;

        //Вычисление фокуса планеты
        //MercuryObject.transform.parent = Mercury_Focus.transform;
        //Mercury_Focus.transform.position = new Vector3(-(0.20563593f * a_Mercury), 0, 0);

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
        //Debug.Log("Ожидаемое f_Mercury = " + 7.76478202f * Mathf.Pow(10,-7));
        //Debug.Log("Начальное f_Mercury = " + f_Mercury);
        X1_Mercury = a_Mercury;

        Y1_Mercury = b_Mercury;

        Z1_Mercury = c_Mercury * Mathf.Sin(7f);

        MercuryObject.transform.position = new Vector3(X1_Mercury, Z1_Mercury, Y1_Mercury);

        f1_Mercury = f2_Mercury;
        f2_Mercury = f_Mercury;
    }
    void MercuryModel()
    {
        f_Mercury += f2_Mercury / 60;

        if (!DegreeYearsForMercury)
        {
            degreeForMercury = (int.Parse(textYearText.text) - 2000) * 4.15210316139 * 360;
            DegreeYearsForMercury = true;
            LastDegreeYearsForMercury = degreeForMercury;
        }
        else degreeForMercury = LastDegreeYearsForMercury;

        if (degreeForMercury > 360)
        {
            while (degreeForMercury > 360)
            {
                degreeForMercury -= 360;
            }
            degreeForMercury += 29.124279;
        }
        else if (degreeForMercury < 360 && degreeForMercury > 29.124279)
        {
            degreeForMercury += 29.124279;
        }
        else if (degreeForMercury < 29.124279)
        {
            degreeForMercury += 29.124279;
        }

        X1_Mercury = a_Mercury * Mathf.Cos( ( (f_Mercury * Mathf.Pow(10, 6)) + (float)degreeForMercury + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Mercury / 60))) /** Mathf.Deg2Rad*/);
        Y1_Mercury = b_Mercury * Mathf.Sin( ( (f_Mercury * Mathf.Pow(10, 6)) + (float)degreeForMercury + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Mercury / 60))) /** Mathf.Deg2Rad*/);
        Z1_Mercury = c_Mercury * Mathf.Cos( (f_Mercury * Mathf.Pow(10, 6) + ((float)degreeForMercury - 29.124279f) + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Mercury / 60))) /** Mathf.Deg2Rad*/) * Mathf.Sin(7f);

        MercuryObject.transform.position = new Vector3(X1_Mercury - (0.20563593f * a_Mercury), Z1_Mercury, Y1_Mercury);

		X1_Mercury_Orbit = a_Mercury * Mathf.Cos( ( (f_Mercury * Mathf.Pow(10, 7)) + 29.124279f));
		Y1_Mercury_Orbit = b_Mercury * Mathf.Sin( ( (f_Mercury * Mathf.Pow(10, 7)) + 29.124279f));
		Z1_Mercury_Orbit = c_Mercury * Mathf.Cos( (f_Mercury * Mathf.Pow(10, 7))) * Mathf.Sin(7f);
		
		Orbit_Mercury.transform.position = new Vector3(X1_Mercury_Orbit - (0.20563593f * a_Mercury), Z1_Mercury_Orbit, Y1_Mercury_Orbit);

        Mercury.GetComponent<TrailRenderer>().enabled = false;
        Orbit_Mercury.SetActive(true);
    }

    void VenusModelStart()
    {
        //Задаются начальные данные
        a_Venus = 0.723332f * 400f;
       // Debug.Log("a_Venus = " + a_Venus);
        b_Venus = a_Venus * Mathf.Sqrt(1 - Mathf.Pow(0.0068f, 2));
        //Debug.Log("b_Venus = " + b_Venus);
        c_Venus = (5.57767250387f / 130f) * 414.74730829f;

        //Вычисление фокуса планеты
        //VenusObject.transform.parent = Venus_Focus.transform;
        //Venus_Focus.transform.position = new Vector3(-(0.0068f * a_Venus), 0, 0);

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
        //Debug.Log("Ожидаемое f_Venus = " + 3.03990293f * Mathf.Pow(10, -7));
        //Debug.Log("Начальное f_Venus = " + f_Venus);

        X1_Venus = a_Venus;
        Y1_Venus = b_Venus;
        Z1_Venus = c_Venus * Mathf.Sin(3.39458f);

        VenusObject.transform.position = new Vector3(X1_Venus, Z1_Venus, Y1_Venus);

        f1_Venus = f2_Venus;
        f2_Venus = f_Venus;
    }

    void VenusModel()
    {
        f_Venus += f2_Venus / 60;

        if (!DegreeYearsForVenus)
        {
            degreeForVenus = (int.Parse(textYearText.text) - 2000) * 1.6255434539 * 360;
            DegreeYearsForVenus = true;
            LastDegreeYearsForVenus = degreeForVenus;
        }
        else degreeForVenus = LastDegreeYearsForVenus;

        if (degreeForVenus > 360)
        {
            while (degreeForVenus > 360)
            {
                degreeForVenus -= 360;
            }
            degreeForVenus += 54.85229;
        }
        else if (degreeForVenus < 360 && degreeForVenus > 54.85229)
        {
            degreeForVenus += 54.85229;
        }
        else if (degreeForVenus < 54.85229)
        {
            degreeForVenus += 54.85229;
        }

        X1_Venus = a_Venus * Mathf.Cos( ( (f_Venus * Mathf.Pow(10, 6)) + (float)degreeForVenus + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Venus / 60))));
        Y1_Venus = b_Venus * Mathf.Sin( ( (f_Venus * Mathf.Pow(10, 6)) + (float)degreeForVenus + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Venus / 60))));
        Z1_Venus = c_Venus * Mathf.Cos( (f_Venus * Mathf.Pow(10, 6) + ((float)degreeForVenus - 54.85229f) + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Venus / 60)))) * Mathf.Sin(3.39458f);

        X1_Venus_Orbit = a_Venus * Mathf.Cos( ( (f_Venus * Mathf.Pow(10, 7)) + 54.85229f));
        Y1_Venus_Orbit = b_Venus * Mathf.Sin( ( (f_Venus * Mathf.Pow(10, 7)) + 54.85229f));
        Z1_Venus_Orbit = c_Venus * Mathf.Cos( (f_Venus * Mathf.Pow(10, 7))) * Mathf.Sin(3.39458f);

        VenusObject.transform.position = new Vector3(X1_Venus - (0.0068f * a_Venus), Z1_Venus, Y1_Venus);
        Orbit_Venus.transform.position = new Vector3(X1_Venus_Orbit - (0.0068f * a_Venus), Z1_Venus_Orbit, Y1_Venus_Orbit);

        Venus.GetComponent<TrailRenderer>().enabled = false;
        Orbit_Venus.SetActive(true);
    }

    void EarthModelStart()
    {
        //Задаются начальные данные
        a = 1.00000261f * 400f;
        b = a * Mathf.Sqrt(1 - Mathf.Pow(0.01671123f, 2));
        Debug.Log("b = " + b);

        //Вычисление фокуса планеты
        //EarthObject.transform.parent = Earth_Focus.transform;
        //Earth_Focus.transform.position = new Vector3(-(0.01671123f * a), 0, 0);

        orbitalPeriod = 365.256363004f * 24f * 3600f;
        r = 149598261000f;
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massEarth = 5.9726f * Mathf.Pow(10, 24);

        R = (1 - 0.01671123f) * 149597870700f;
        //Debug.Log("R = " + R);
        h1 = -G * (massSun + massEarth);
        //Debug.Log("h1 = " + h1); 
        a1 = h1 / (R * Mathf.Pow(30027f, 2)); //-77.3030194662f
        //Debug.Log("a1 = " + a1);
        vp = -2 * a1 * Mathf.PI * R / (orbitalPeriod * Mathf.Pow((-2 * a1) - 1, 1.5f));
        //Debug.Log("vp = " + vp);
        //Debug.Log("vp = " + vp);
        rSred = r / R;
        //Debug.Log("rSred = " + rSred);
        hi = 1f;

        vt = vp / rSred;
        //Debug.Log("vt = " + vt);
        vtSred = (vt / vp);//Влиятельная переменная
        //Debug.Log("vtSred = " + vtSred);

        vrSred = Mathf.Sqrt(Mathf.Pow(a1 + 1, 2) - Mathf.Pow((a1 + 1) / rSred, 2));
        //Debug.Log("vrSred = " + vrSred);

        e = -2 * Mathf.Pow((vp / R), 2) * vrSred / Mathf.Pow(rSred, 2) /*(2 * Mathf.PI) / orbitalPeriod*/;
        //Debug.Log("e = " + e);

        //Вычисление угла

        f = f + (vp / R) * (vtSred / rSred) * hi + e * Mathf.Pow(hi, 2) / 2;
        //Debug.Log("Начальное f = " + f);
        X1 = a * (-0.37015197049f);
        //Debug.Log("X1_Pluton = " + X1_Pluton);

        Y1 = b * 0.92897121523f;
        //Debug.Log("Y1_Pluton = " + Y1_Pluton);

        EarthObject.transform.position = new Vector3(X1, 0, Y1);

        f1 = f2;
        f2 = f;
    }
    void EarthModel()
    {
        f += f2 / 60;
        if (f > 360)
        {
            f -= 360;
        }

        X1 = a * Mathf.Cos( ((f * Mathf.Pow(10, 6)) + 114.20783f + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2/60))));
        Y1 = b * Mathf.Sin( ((f * Mathf.Pow(10, 6)) + 114.20783f + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2/60))));

        X1_Orbit = a * Mathf.Cos( ((f * Mathf.Pow(10, 7)) + 114.20783f));
        Y1_Orbit = b * Mathf.Sin( ((f * Mathf.Pow(10, 7)) + 114.20783f));

        EarthObject.transform.position = new Vector3(X1 - (0.01671123f * a), 0, Y1);

        Orbit_Earth.transform.position = new Vector3(X1_Orbit - (0.01671123f * a), 0, Y1_Orbit);

        Earth.GetComponent<TrailRenderer>().enabled = false;
        Orbit_Earth.SetActive(true);
    }

    void MarsModelStart()
    {
        //Задаются начальные данные
        a_Mars = 1.523662f * 380;
        //Debug.Log("a_Mars = " + a_Mars);
        b_Mars = a_Mars * Mathf.Sqrt(1 - Mathf.Pow(0.0933941f, 2));
        //Debug.Log("b_Mars = " + b_Mars);
        c_Mars = (6.39992951135f / 130f) * 328.156769677f;

        //Вычисление фокуса планеты
        //MarsObject.transform.parent = Mars_Focus.transform;
        //Mars_Focus.transform.position = new Vector3(-(0.0933941f * a_Mars), 0, 0);

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
        //Debug.Log("Ожидаемое f_Mars = " + 8.75785457 * Mathf.Pow(10, -8));
        //Debug.Log("Начальное f_Mars = " + f_Mars);

        X1_Mars = a_Mars;
        Y1_Mars = b_Mars;
        Z1_Mars = c_Mars * Mathf.Sin(1.85061f);

        MarsObject.transform.position = new Vector3(X1_Mars, Z1_Mars, Y1_Mars);

        f1_Mars = f2_Mars;
        f2_Mars = f_Mars;
    }
    void MarsModel()
    {
        f_Mars += f2_Mars / 60;

        if (!DegreeYearsForMars)
        {
            degreeForMars = (int.Parse(textYearText.text) - 2000) * 0.53168412909 * 360;
            DegreeYearsForMars = true;
            LastDegreeYearsForMars = degreeForMars;
        }
        else degreeForMars = LastDegreeYearsForMars;

        if (degreeForMars > 360)
        {
            while (degreeForMars > 360)
            {
                degreeForMars -= 360;
            }
            degreeForMars += 286.46230;
        }
        else if (degreeForMars < 360 && degreeForMars > 286.46230)
        {
            degreeForMars += 286.46230;
        }
        else if (degreeForMars < 286.46230)
        {
            degreeForMars += 286.46230;
        }

        X1_Mars = a_Mars * Mathf.Cos( ((f_Mars * Mathf.Pow(10, 6)) + (float)degreeForMars + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Mars / 60))));
        Y1_Mars = b_Mars * Mathf.Sin( ((f_Mars * Mathf.Pow(10, 6)) + (float)degreeForMars + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Mars / 60))));
        Z1_Mars = c_Mars * Mathf.Cos( (f_Mars * Mathf.Pow(10, 6) + ((float)degreeForMars - 286.46230f) + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Mars / 60)))) * Mathf.Sin(1.85061f);

        X1_Mars_Orbit = a_Mars * Mathf.Cos( ((f_Mars * Mathf.Pow(10, 8)) + 286.46230f));
        Y1_Mars_Orbit = b_Mars * Mathf.Sin( ((f_Mars * Mathf.Pow(10, 8)) + 286.46230f));
        Z1_Mars_Orbit = c_Mars * Mathf.Cos( (f_Mars * Mathf.Pow(10, 8))) * Mathf.Sin(1.85061f);

        MarsObject.transform.position = new Vector3(X1_Mars - (0.0933941f * a_Mars), Z1_Mars, Y1_Mars);
        Orbit_Mars.transform.position = new Vector3(X1_Mars_Orbit - (0.0933941f * a_Mars), Z1_Mars_Orbit, Y1_Mars_Orbit);

        Mars.GetComponent<TrailRenderer>().enabled = false;
        Orbit_Mars.SetActive(true);
    }

    void JupiterModelStart()
    {
        //Задаются начальные данные
        a_Jupiter = 5.204267f * 160;
        //Debug.Log("a_Jupiter = " + a_Jupiter);
        b_Jupiter = a_Jupiter * Mathf.Sqrt(1 - Mathf.Pow(0.048775f, 2));
        //Debug.Log("b_Jupiter = " + b_Jupiter);
        c_Jupiter = (15.40043075f / 130f) * 153.720014749f;

        //Вычисление фокуса планеты
        //JupiterObject.transform.parent = Jupiter_Focus.transform;
        //Jupiter_Focus.transform.position = new Vector3(-(0.048775f * a_Jupiter), 0, 0);

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
        //Debug.Log("Ожидаемое f_Jupiter = " + 1.57656336 * Mathf.Pow(10, -8));
        //Debug.Log("Начальное f_Jupiter = " + f_Jupiter);

        X1_Jupiter = a_Jupiter;
        Y1_Jupiter = b_Jupiter;
        Z1_Jupiter = c_Jupiter * Mathf.Sin(1.304f);

        JupiterObject.transform.position = new Vector3(X1_Jupiter, Z1_Jupiter, Y1_Jupiter);

        f1_Jupiter = f2_Jupiter;
        f2_Jupiter = f_Jupiter;
    }
    void JupiterModel()
    {
        f_Jupiter += f2_Jupiter / 60;

        if (!DegreeYearsForJupiter)
        {
            degreeForJupiter = (int.Parse(textYearText.text) - 2000) * 0.08430441082 * 360;
            DegreeYearsForJupiter = true;
            LastDegreeYearsForJupiter = degreeForJupiter;
        }
        else degreeForJupiter = LastDegreeYearsForJupiter;

        if (degreeForJupiter > 360)
        {
            while (degreeForJupiter > 360)
            {
                degreeForJupiter -= 360;
            }
            degreeForJupiter += 275.066;
        }
        else if (degreeForJupiter < 360 && degreeForJupiter > 275.066)
        {
            degreeForJupiter += 275.066;
        }
        else if (degreeForJupiter < 275.066)
        {
            degreeForJupiter += 275.066;
        }

        X1_Jupiter = a_Jupiter * Mathf.Cos( ((f_Jupiter * Mathf.Pow(10, 6)) + (float)degreeForJupiter + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Jupiter / 60))));
        Y1_Jupiter = b_Jupiter * Mathf.Sin( ((f_Jupiter * Mathf.Pow(10, 6)) + (float)degreeForJupiter + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Jupiter / 60))));
        Z1_Jupiter = c_Jupiter * Mathf.Cos( (f_Jupiter * Mathf.Pow(10, 6) + ((float)degreeForJupiter - 275.066f) + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Jupiter / 60)))) * Mathf.Sin(1.304f);

        X1_Jupiter_Orbit = a_Jupiter * Mathf.Cos( ((f_Jupiter * Mathf.Pow(10, 8)) + 275.066f));
        Y1_Jupiter_Orbit = b_Jupiter * Mathf.Sin( ((f_Jupiter * Mathf.Pow(10, 8)) + 275.066f));
        Z1_Jupiter_Orbit = c_Jupiter * Mathf.Cos( (f_Jupiter * Mathf.Pow(10, 8))) * Mathf.Sin(1.304f);

        JupiterObject.transform.position = new Vector3(X1_Jupiter - (0.048775f * a_Jupiter), Z1_Jupiter, Y1_Jupiter);
        Orbit_Jupiter.transform.position = new Vector3(X1_Jupiter_Orbit - (0.048775f * a_Jupiter), Z1_Jupiter_Orbit, Y1_Jupiter_Orbit);

        Jupiter.GetComponent<TrailRenderer>().enabled = false;
        Orbit_Jupiter.SetActive(true);
    }

    void SaturnModelStart()
    {
        //Задаются начальные данные
        a_Saturn = 9.58f * 120;
       // Debug.Log("a_Saturn = " + a_Saturn);
        b_Saturn = a_Saturn * Mathf.Sqrt(1 - Mathf.Pow(0.055723219f, 2));
       //Debug.Log("b_Saturn = " + b_Saturn);
        c_Saturn = (54.0539020805f / 130f) * 120;

        //Вычисление фокуса планеты
        //SaturnObject.transform.parent = Saturn_Focus.transform;
        //Saturn_Focus.transform.position = new Vector3(-(0.055723219f * a_Saturn), 0, 0);

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

        X1_Saturn = a_Saturn;
        Y1_Saturn = b_Saturn;
        Z1_Saturn = c_Saturn * Mathf.Sin(2.485240f);

        SaturnObject.transform.position = new Vector3(X1_Saturn, Z1_Saturn, Y1_Saturn);

        f1_Saturn = f2_Saturn;
        f2_Saturn = f_Saturn;
    }
    void SaturnModel()
    {
        f_Saturn += f2_Saturn / 60;

        if (!DegreeYearsForSaturn)
        {
            degreeForSaturn = (int.Parse(textYearText.text) - 2000) * 0.03394821957 * 360;
            DegreeYearsForSaturn = true;
            LastDegreeYearsForSaturn = degreeForSaturn;
            Debug.Log("degreeForSaturn" + degreeForSaturn);
        }
        else degreeForSaturn = LastDegreeYearsForSaturn;

        if (degreeForSaturn > 360)
        {
            while (degreeForSaturn > 360)
            {
                degreeForSaturn -= 360;
            }
            degreeForSaturn += 336.013862;
        }
        else if (degreeForSaturn < 360 && degreeForSaturn > 336.013862)
        {
            degreeForSaturn += 336.013862;
        }
        else if (degreeForSaturn < 336.013862)
        {
            degreeForSaturn += 336.013862;
        }

        X1_Saturn = a_Saturn * Mathf.Cos( ((f_Saturn * Mathf.Pow(10, 6)) + (float)degreeForSaturn + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Saturn))));
        Y1_Saturn = b_Saturn * Mathf.Sin( ((f_Saturn * Mathf.Pow(10, 6)) + (float)degreeForSaturn + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Saturn))));
        Z1_Saturn = c_Saturn * Mathf.Cos( (f_Saturn * Mathf.Pow(10, 6) + ((float)degreeForSaturn - 336.013862f) + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Saturn)))) * Mathf.Sin(2.485240f);

        X1_Saturn_Orbit = a_Saturn * Mathf.Cos( ((f_Saturn * Mathf.Pow(10, 9)) + 336.013862f));
        Y1_Saturn_Orbit = b_Saturn * Mathf.Sin( ((f_Saturn * Mathf.Pow(10, 9)) + 336.013862f));
        Z1_Saturn_Orbit = c_Saturn * Mathf.Cos( (f_Saturn * Mathf.Pow(10, 9))) * Mathf.Sin(2.485240f);

        SaturnObject.transform.position = new Vector3(X1_Saturn - (0.055723219f * a_Saturn), Z1_Saturn, Y1_Saturn);
        Orbit_Saturn.transform.position = new Vector3(X1_Saturn_Orbit - (0.055723219f * a_Saturn), Z1_Saturn_Orbit, Y1_Saturn_Orbit);

        Saturn.GetComponent<TrailRenderer>().enabled = false;
        Orbit_Saturn.SetActive(true);
    }

    void UranusModelStart()
    {
        //Задаются начальные данные
        a_Uranus = 19.22941195f * 80;
        //Debug.Log("a_Uranus = " + a_Uranus);
        b_Uranus = a_Uranus * Mathf.Sqrt(1 - Mathf.Pow(0.044405586f, 2));
        //Debug.Log("b_Uranus = " + b_Uranus);
        c_Uranus = (33.7087709089f / 130f) * 80;

        //Вычисление фокуса планеты
        //UranusObject.transform.parent = Uranus_Focus.transform;
        //Uranus_Focus.transform.position = new Vector3(-(0.044405586f * a_Uranus), 0, 0);

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
        //Debug.Log("Ожидаемое f_Uranus = " + 2.22601012 * Mathf.Pow(10, -9));
        //Debug.Log("Начальное f_Uranus = " + f_Uranus);

        X1_Uranus = a_Uranus;
        Y1_Uranus = b_Uranus;
        Z1_Uranus = c_Uranus * Mathf.Sin(0.772556f);

        UranusObject.transform.position = new Vector3(X1_Uranus, Z1_Uranus, Y1_Uranus);

        f1_Uranus = f2_Uranus;
        f2_Uranus = f_Uranus;
    }
    void UranusModel()
    {
        f_Uranus += f2_Uranus / 60;

        if (!DegreeYearsForUranus)
        {
            degreeForUranus = (int.Parse(textYearText.text) - 2000) * 0.01190326223 * 360;
            DegreeYearsForUranus = true;
            LastDegreeYearsForUranus = degreeForUranus;
        }
        else degreeForUranus = LastDegreeYearsForUranus;

        if (degreeForUranus > 360)
        {
            while (degreeForUranus > 360)
            {
                degreeForUranus -= 360;
            }
            degreeForUranus += 96.541318;
        }
        else if (degreeForUranus < 360 && degreeForUranus > 96.541318)
        {
            degreeForUranus += 96.541318;
        }
        else if (degreeForUranus < 96.541318)
        {
            degreeForUranus += 96.541318;
        }

        X1_Uranus = a_Uranus * Mathf.Cos( ((f_Uranus * Mathf.Pow(10, 6)) + (float)degreeForUranus + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Uranus / 60))));
        Y1_Uranus = b_Uranus * Mathf.Sin( ((f_Uranus * Mathf.Pow(10, 6)) + (float)degreeForUranus + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Uranus / 60))));
        Z1_Uranus = c_Uranus * Mathf.Cos( (f_Uranus * Mathf.Pow(10, 6) + ((float)degreeForUranus - 96.541318f) + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Uranus / 60)))) * Mathf.Sin(0.772556f);

        X1_Uranus_Orbit = a_Uranus * Mathf.Cos( ((f_Uranus * Mathf.Pow(10, 9)) + 96.541318f));
        Y1_Uranus_Orbit = b_Uranus * Mathf.Sin( ((f_Uranus * Mathf.Pow(10, 9)) + 96.541318f));
        Z1_Uranus_Orbit = c_Uranus * Mathf.Cos( (f_Uranus * Mathf.Pow(10, 9))) * Mathf.Sin(0.772556f);

        UranusObject.transform.position = new Vector3(X1_Uranus - (0.044405586f * a_Uranus), Z1_Uranus, Y1_Uranus);
        Orbit_Uranus.transform.position = new Vector3(X1_Uranus_Orbit - (0.044405586f * a_Uranus), Z1_Uranus_Orbit, Y1_Uranus_Orbit);

        Uranus.GetComponent<TrailRenderer>().enabled = false;
        Orbit_Uranus.SetActive(true);
    }

    void NeptuneModelStart()
    {
        //Задаются начальные данные
        a_Neptune = 30.10366151f * 60;
       // Debug.Log("a_Neptune = " + a_Neptune);
        b_Neptune = a_Neptune * Mathf.Sqrt(1 - Mathf.Pow(0.011214269f, 2));
        //Debug.Log("b_Neptune = " + b_Neptune);
        c_Neptune = (120.796410958f / 130f) * 60;

        //Вычисление фокуса планеты
        //NeptuneObject.transform.parent = Neptune_Focus.transform;
        //Neptune_Focus.transform.position = new Vector3(0.011214269f * a_Neptune, 0, 0);

        orbitalPeriod_Neptune = 60190.03f * 24f * 3600f;
        r_Neptune = 4503443661000f;
        G = 6.67f * Mathf.Pow(10, -11);
        massSun = 1.9885f * Mathf.Pow(10, 30);
        massNeptune = 1.0243f * Mathf.Pow(10, 26);

        R_Neptune = (1 - 0.011214269f) * 4503443661000f;
        h1_Neptune = -G * (massSun + massNeptune);
        a1_Neptune = h1_Neptune / (R_Neptune * Mathf.Pow(5457.60693492f, 2));
        vp_Neptune = -2 * a1_Neptune * Mathf.PI * R_Neptune / (orbitalPeriod_Neptune * Mathf.Pow((-2 * a1_Neptune) - 1, 1.5f));
        rSred_Neptune = r_Neptune / R_Neptune;
        hi_Neptune = 1f;

        vt_Neptune = vp_Neptune / rSred_Neptune;
        vtSred_Neptune = (vt_Neptune / vp_Neptune);
        vrSred_Neptune = Mathf.Sqrt(Mathf.Pow(a1_Neptune + 1, 2) - Mathf.Pow((a1_Neptune + 1) / rSred_Neptune, 2));
        e_Neptune = -2 * Mathf.Pow((vp_Neptune / R_Neptune), 2) * vrSred_Neptune / Mathf.Pow(rSred_Neptune, 3);

        //Вычисление угла

        f_Neptune = f_Neptune + (vp_Neptune / R_Neptune) * (vtSred_Neptune / rSred_Neptune) * hi_Neptune + e_Neptune * Mathf.Pow(hi_Neptune, 2) / 2;

        X1_Neptune = a_Neptune;
        Y1_Neptune = b_Neptune;
        Z1_Neptune = c_Neptune * Mathf.Sin(1.767975f);

        NeptuneObject.transform.position = new Vector3(X1_Neptune, Z1_Neptune, Y1_Neptune);

        f1_Neptune = f2_Neptune;
        f2_Neptune = f_Neptune;
    }
    void NeptuneModel()
    {
        f_Neptune += f2_Neptune / 60;

        if (!DegreeYearsForNeptune)
        {
            degreeForNeptune = (int.Parse(textYearText.text) - 2000) * 0.00606838645 * 360;
            DegreeYearsForNeptune = true;
            LastDegreeYearsForNeptune = degreeForNeptune;
        }
        else degreeForNeptune = LastDegreeYearsForNeptune;

        if (degreeForNeptune > 360)
        {
            while (degreeForNeptune > 360)
            {
                degreeForNeptune -= 360;
            }
            degreeForNeptune += 265.646853;
        }
        else if (degreeForNeptune < 360 && degreeForNeptune > 265.646853)
        {
            degreeForNeptune += 265.646853;
        }
        else if (degreeForNeptune < 265.646853)
        {
            degreeForNeptune += 265.646853;
        }

        X1_Neptune = a_Neptune * Mathf.Cos(((f_Neptune * Mathf.Pow(10, 6)) + (float)degreeForNeptune + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Neptune / 60))));
        Y1_Neptune = b_Neptune * Mathf.Sin(((f_Neptune * Mathf.Pow(10, 6)) + (float)degreeForNeptune + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Neptune / 60))));
        Z1_Neptune = c_Neptune * Mathf.Cos((f_Neptune * Mathf.Pow(10, 6) + ((float)degreeForNeptune - 265.646853f) + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Neptune / 60)))) * Mathf.Sin(1.767975f);

        X1_Neptune_Orbit = a_Neptune * Mathf.Cos( ((f_Neptune * Mathf.Pow(10, 9)) + 265.646853f));
        Y1_Neptune_Orbit = b_Neptune * Mathf.Sin( ((f_Neptune * Mathf.Pow(10, 9)) + 265.646853f));
        Z1_Neptune_Orbit = c_Neptune * Mathf.Cos( (f_Neptune * Mathf.Pow(10, 9))) * Mathf.Sin(1.767975f);

        NeptuneObject.transform.position = new Vector3(X1_Neptune - (0.011214269f * a_Neptune), Z1_Neptune - (0.011214269f * a_Neptune), Y1_Neptune);
        Orbit_Neptune.transform.position = new Vector3(X1_Neptune_Orbit - (0.011214269f * a_Neptune), Z1_Neptune_Orbit - (0.011214269f * a_Neptune), Y1_Neptune_Orbit);

        Neptune.GetComponent<TrailRenderer>().enabled = false;
        Orbit_Neptune.SetActive(true);
    }

    void PlutoModelStart()
    {
        f_Pluton = 0;
        a_Pluton = 39.482117f * 60;
       // Debug.Log("a_Pluton = " + a_Pluton);
        b_Pluton = a_Pluton * Mathf.Sqrt(1 - Mathf.Pow(0.2488273f, 2));
       // Debug.Log("b_Pluton = " + b_Pluton);
        c_Pluton = (1582.94026497f/130f) * 60;

        //Вычисление фокуса планеты
        //Pluto_Focus.transform.position = new Vector3(-(0.2488273f * a_Pluton) - 589.4537f, 0, 0);
        //PlutoObject.transform.parent = Pluto_Focus.transform;

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
        //Debug.Log("vp_Pluton = " + vp_Pluton);
        rSred_Pluton = r_Pluton / R_Pluton;
        //Debug.Log("rSred_Pluton = " + rSred_Pluton);

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

      //  Debug.Log("Ожидаемое f_Pluton = " + 7.5432063 * Mathf.Pow(10, -10));
      //  Debug.Log("Начальное f_Pluton = " + f_Pluton);

        X1_Pluton = a_Pluton * (-0.40295898941f);

        Y1_Pluton = b_Pluton * 0.91521803568f;

        Z_Pluton = c_Pluton * Mathf.Sin(17.14f);

        PlutoObject.transform.position = new Vector3(X1_Pluton, Z_Pluton, Y1_Pluton);

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
        f_Pluton += f2_Pluton / 60;

        if (!DegreeYearsForPluto)
        {
            degreeForPluto = (int.Parse(textYearText.text) - 2000) * 0.00403361879 * 360;
            DegreeYearsForPluto = true;
            LastDegreeYearsForPluto = degreeForPluto;
        }
        else degreeForPluto = LastDegreeYearsForPluto;

        if (degreeForPluto > 360)
        {
            while (degreeForPluto > 360)
            {
                degreeForPluto -= 360;
            }
            degreeForPluto += 113.76329;
        }
        else if (degreeForPluto < 360 && degreeForPluto > 113.76329)
        {
            degreeForPluto += 113.76329;
        }
        else if (degreeForPluto < 113.76329)
        {
            degreeForPluto += 113.76329;
        }

        X1_Pluton = a_Pluton * Mathf.Cos( ((f_Pluton * Mathf.Pow(10, 6)) + (float)degreeForPluto + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Pluton / 60))));
        Y1_Pluton = b_Pluton * Mathf.Sin( ((f_Pluton * Mathf.Pow(10, 6)) + (float)degreeForPluto + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Pluton / 60))));
        Z_Pluton = c_Pluton * Mathf.Cos( (f_Pluton * Mathf.Pow(10, 6) + ((float)degreeForPluto - 113.76329f) + (Convert.ToInt32(textForCoordinateDataForEarth.text) * (f2_Pluton / 60)))) * Mathf.Sin(17.14f);

        X1_Pluton_Orbit = a_Pluton * Mathf.Cos( ((f_Pluton * Mathf.Pow(10, 9)) + 113.76329f));
        Y1_Pluton_Orbit = b_Pluton * Mathf.Sin( ((f_Pluton * Mathf.Pow(10, 9)) + 113.76329f));
        Z_Pluton_Orbit = c_Pluton * Mathf.Cos( (f_Pluton * Mathf.Pow(10, 9))) * Mathf.Sin(17.14f);

        PlutoObject.transform.position = new Vector3(X1_Pluton - 589.4537f, Z_Pluton, Y1_Pluton);
        Orbit_Pluto.transform.position = new Vector3(X1_Pluton_Orbit - 589.4537f, Z_Pluton_Orbit, Y1_Pluton_Orbit);

        Pluto.GetComponent<TrailRenderer>().enabled = false;
        Orbit_Pluto.SetActive(true);
    }
}
