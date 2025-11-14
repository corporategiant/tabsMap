using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using System.Collections.Generic; // For List<T>
using TMPro;




public class addStampv5 : MonoBehaviour
{
    public string username;
    public string StudentID;
    public TextMeshProUGUI usernametext;
    public bool EndScreen;
    public string SaveStampsPHPUrl;
    public string GetStampsPHPUrl;
    public string currentQuizMaster;
    public string currentQuizMasterusername;
    public string currentQuizMasterStudentID;
    public string filename;
    public string foldername;
    public bool getStampsAtStart;
    public string QuizMaster1;
    public int QuizMaster1isOn;
    public string QuizMaster2;
    public int QuizMaster2isOn;
    public string QuizMaster3;
    public int QuizMaster3isOn;
    public string QuizMaster4;
    public int QuizMaster4isOn;
    public string QuizMaster5;
    public int QuizMaster5isOn;
    public string QuizMaster6;
    public int QuizMaster6isOn;
    public string QuizMaster7;
    public int QuizMaster7isOn;
    public string QuizMaster8;
    public int QuizMaster8isOn;
    public string QuizMaster9;
    public int QuizMaster9isOn;
    public string QuizMaster10;
    public int QuizMaster10isOn;
    public string QuizMaster11;
    public int QuizMaster11isOn;
    public string QuizMaster12;
    public int QuizMaster12isOn;
    public string QuizMaster13;
    public int QuizMaster13isOn;
    public string QuizMaster14;
    public int QuizMaster14isOn;
    public string QuizMaster15;
    public int QuizMaster15isOn;
    public string QuizMaster16;
    public int QuizMaster16isOn;
    public string QuizMaster17;
    public int QuizMaster17isOn;
    public string QuizMaster18;
    public int QuizMaster18isOn;
    public string QuizMaster19;
    public int QuizMaster19isOn;
    public string QuizMaster20;
    public int QuizMaster20isOn;
    public GameObject Stamp1;
    public GameObject Stamp2;
    public GameObject Stamp3;
    public GameObject Stamp4;
    public GameObject Stamp5;
    public GameObject Stamp6;
    public GameObject Stamp7;
    public GameObject Stamp8;
    public GameObject Stamp9;
    public GameObject Stamp10;
    public GameObject Stamp11;
    public GameObject Stamp12;
    public GameObject Stamp13;
    public GameObject Stamp14;
    public GameObject Stamp15;
    public GameObject Stamp16;
    public GameObject Stamp17;
    public GameObject Stamp18;
    public GameObject Stamp19;
    public GameObject Stamp20;

    [System.Serializable]
    public class StampsData
    {
        public string filename = PlayerPrefs.GetString("username") + PlayerPrefs.GetString("StudentID");
        public string QuizMaster1;
        public int QuizMaster1isOn;
        public string QuizMaster2;
        public int QuizMaster2isOn;
        public string QuizMaster3;
        public int QuizMaster3isOn;
        public string QuizMaster4;
        public int QuizMaster4isOn;
        public string QuizMaster5;
        public int QuizMaster5isOn;
        public string QuizMaster6;
        public int QuizMaster6isOn;
        public string QuizMaster7;
        public int QuizMaster7isOn;
        public string QuizMaster8;
        public int QuizMaster8isOn;
        public string QuizMaster9;
        public int QuizMaster9isOn;
        public string QuizMaster10;
        public int QuizMaster10isOn;
        public string QuizMaster11;
        public int QuizMaster11isOn;
        public string QuizMaster12;
        public int QuizMaster12isOn;
        public string QuizMaster13;
        public int QuizMaster13isOn;
        public string QuizMaster14;
        public int QuizMaster14isOn;
        public string QuizMaster15;
        public int QuizMaster15isOn;
        public string QuizMaster16;
        public int QuizMaster16isOn;
        public string QuizMaster17;
        public int QuizMaster17isOn;
        public string QuizMaster18;
        public int QuizMaster18isOn;
        public string QuizMaster19;
        public int QuizMaster19isOn;
        public string QuizMaster20;
        public int QuizMaster20isOn;
    
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // For testing

        // PlayerPrefs.SetString("QuizMasterusername", "Guest");
        // PlayerPrefs.SetString("QuizMasterStudentID", "KOKO3311");


        currentQuizMasterusername = PlayerPrefs.GetString("QuizMasterusername");
        currentQuizMasterStudentID = PlayerPrefs.GetString("QuizMasterStudentID");
        currentQuizMaster = currentQuizMasterusername + currentQuizMasterStudentID;
        filename = PlayerPrefs.GetString("username") + PlayerPrefs.GetString("StudentID");
        foldername = PlayerPrefs.GetString("username") + PlayerPrefs.GetString("StudentID");
        SaveStampsPHPUrl = "https://www.corporategiant.co.uk/tabsQuizData/stampsData/" + foldername + "/write_json.php";
        GetStampsPHPUrl = "https://www.corporategiant.co.uk/tabsQuizData/stampsData/" + foldername + "/get_data.php";

        if (getStampsAtStart == true)
        {
            Debug.Log("Start SetStamps");
            StartCoroutine(FetchJsonData());
            //SetStamps();
            //AddStamps();
            //StartCoroutine(SaveStamps());
        }
    }

        public void StartCheckStamps()
    {
        usernametext.text = PlayerPrefs.GetString("username");
        currentQuizMasterusername = PlayerPrefs.GetString("QuizMasterusername");
        currentQuizMasterStudentID = PlayerPrefs.GetString("QuizMasterStudentID");
        currentQuizMaster = currentQuizMasterusername + currentQuizMasterStudentID;
        filename = PlayerPrefs.GetString("username") + PlayerPrefs.GetString("StudentID");
        foldername = PlayerPrefs.GetString("username") + PlayerPrefs.GetString("StudentID");
        SaveStampsPHPUrl = "https://www.corporategiant.co.uk/tabsQuizData/stampsData/" + foldername + "/write_json.php";
        GetStampsPHPUrl = "https://www.corporategiant.co.uk/tabsQuizData/stampsData/" + foldername + "/get_data.php";

        if (getStampsAtStart == true)
        {
            Debug.Log("Start SetStamps");
            StartCoroutine(FetchJsonData());
            //SetStamps();
            //AddStamps();
            //StartCoroutine(SaveStamps());
        }
    }



    public void FetchData()
    {
        StartCoroutine(FetchJsonData());
    }

    IEnumerator FetchJsonData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(GetStampsPHPUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string jsonString = webRequest.downloadHandler.text;
                Debug.Log("Received JSON: " + jsonString);

                // Deserialize the JSON string
                StampsData data = JsonUtility.FromJson<StampsData>(jsonString);

                Debug.Log("QuizMaster1 : " + data.QuizMaster1);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster1", data.QuizMaster1);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster1isOn", data.QuizMaster1isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster2", data.QuizMaster2);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster2isOn", data.QuizMaster2isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster3", data.QuizMaster3);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster3isOn", data.QuizMaster3isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster4", data.QuizMaster4);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster4isOn", data.QuizMaster4isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster5", data.QuizMaster5);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster5isOn", data.QuizMaster5isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster6", data.QuizMaster6);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster6isOn", data.QuizMaster6isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster7", data.QuizMaster7);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster7isOn", data.QuizMaster7isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster8", data.QuizMaster8);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster8isOn", data.QuizMaster8isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster9", data.QuizMaster9);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster9isOn", data.QuizMaster9isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster10", data.QuizMaster10);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster10isOn", data.QuizMaster10isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster11", data.QuizMaster11);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster11isOn", data.QuizMaster11isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster12", data.QuizMaster12);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster12isOn", data.QuizMaster12isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster13", data.QuizMaster13);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster13isOn", data.QuizMaster13isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster14", data.QuizMaster14);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster14isOn", data.QuizMaster14isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster15", data.QuizMaster15);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster15isOn", data.QuizMaster15isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster16", data.QuizMaster16);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster16isOn", data.QuizMaster16isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster17", data.QuizMaster17);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster17isOn", data.QuizMaster17isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster18", data.QuizMaster18);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster18isOn", data.QuizMaster18isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster19", data.QuizMaster19);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster19isOn", data.QuizMaster19isOn);
                PlayerPrefs.SetString(username + StudentID + "QuizMaster20", data.QuizMaster20);
                PlayerPrefs.SetInt(username + StudentID + "QuizMaster20isOn", data.QuizMaster20isOn);


                QuizMaster1 = data.QuizMaster1;
                QuizMaster1isOn = data.QuizMaster1isOn;
                QuizMaster2 = data.QuizMaster2;
                QuizMaster2isOn = data.QuizMaster2isOn;
                QuizMaster3 = data.QuizMaster3;
                QuizMaster3isOn = data.QuizMaster3isOn;
                QuizMaster4 = data.QuizMaster4;
                QuizMaster4isOn = data.QuizMaster4isOn;
                QuizMaster5 = data.QuizMaster5;
                QuizMaster5isOn = data.QuizMaster5isOn;
                QuizMaster6 = data.QuizMaster6;
                QuizMaster6isOn = data.QuizMaster6isOn;
                QuizMaster7 = data.QuizMaster7;
                QuizMaster7isOn = data.QuizMaster7isOn;
                QuizMaster8 = data.QuizMaster8;
                QuizMaster8isOn = data.QuizMaster8isOn;
                QuizMaster9 = data.QuizMaster9;
                QuizMaster9isOn = data.QuizMaster9isOn;
                QuizMaster10 = data.QuizMaster10;
                QuizMaster10isOn = data.QuizMaster10isOn;
                QuizMaster11 = data.QuizMaster11;
                QuizMaster11isOn = data.QuizMaster11isOn;
                QuizMaster12 = data.QuizMaster12;
                QuizMaster12isOn = data.QuizMaster12isOn;
                QuizMaster13 = data.QuizMaster13;
                QuizMaster13isOn = data.QuizMaster13isOn;
                QuizMaster14 = data.QuizMaster14;
                QuizMaster14isOn = data.QuizMaster14isOn;
                QuizMaster15 = data.QuizMaster15;
                QuizMaster15isOn = data.QuizMaster15isOn;
                QuizMaster16 = data.QuizMaster16;
                QuizMaster16isOn = data.QuizMaster16isOn;
                QuizMaster17 = data.QuizMaster17;
                QuizMaster17isOn = data.QuizMaster17isOn;
                QuizMaster18 = data.QuizMaster18;
                QuizMaster18isOn = data.QuizMaster18isOn;
                QuizMaster19 = data.QuizMaster19;
                QuizMaster19isOn = data.QuizMaster19isOn;
                QuizMaster20 = data.QuizMaster20;
                QuizMaster20isOn = data.QuizMaster20isOn;

            }
            else
            {
                Debug.LogError("Error fetching JSON: " + webRequest.error);
            }
            SetStamps();
        }
    }






    public void SetStamps()
    {
        QuizMaster1 = PlayerPrefs.GetString(username + StudentID + "QuizMaster1");
        QuizMaster1isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster1isOn");
        QuizMaster2 = PlayerPrefs.GetString(username + StudentID + "QuizMaster2");
        QuizMaster2isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster2isOn");
        QuizMaster3 = PlayerPrefs.GetString(username + StudentID + "QuizMaster3");
        QuizMaster3isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster4isOn");
        QuizMaster4 = PlayerPrefs.GetString(username + StudentID + "QuizMaster4");
        QuizMaster4isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster5isOn");
        QuizMaster5 = PlayerPrefs.GetString(username + StudentID + "QuizMaster5");
        QuizMaster5isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster6isOn");
        QuizMaster6 = PlayerPrefs.GetString(username + StudentID + "QuizMaster6");
        QuizMaster6isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster7isOn");
        QuizMaster7 = PlayerPrefs.GetString(username + StudentID + "QuizMaster7");
        QuizMaster7isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster7isOn");
        QuizMaster8 = PlayerPrefs.GetString(username + StudentID + "QuizMaster8");
        QuizMaster8isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster8isOn");
        QuizMaster9 = PlayerPrefs.GetString(username + StudentID + "QuizMaster9");
        QuizMaster9isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster9isOn");
        QuizMaster10 = PlayerPrefs.GetString(username + StudentID + "QuizMaster10");
        QuizMaster10isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster10isOn");
        QuizMaster11 = PlayerPrefs.GetString(username + StudentID + "QuizMaster11");
        QuizMaster11isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster11isOn");
        QuizMaster12 = PlayerPrefs.GetString(username + StudentID + "QuizMaster12");
        QuizMaster12isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster12isOn");
        QuizMaster13 = PlayerPrefs.GetString(username + StudentID + "QuizMaster13");
        QuizMaster13isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster14isOn");
        QuizMaster14 = PlayerPrefs.GetString(username + StudentID + "QuizMaster14");
        QuizMaster14isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster15isOn");
        QuizMaster15 = PlayerPrefs.GetString(username + StudentID + "QuizMaster15");
        QuizMaster15isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster16isOn");
        QuizMaster16 = PlayerPrefs.GetString(username + StudentID + "QuizMaster16");
        QuizMaster16isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster17isOn");
        QuizMaster17 = PlayerPrefs.GetString(username + StudentID + "QuizMaster17");
        QuizMaster17isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster17isOn");
        QuizMaster18 = PlayerPrefs.GetString(username + StudentID + "QuizMaster18");
        QuizMaster18isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster18isOn");
        QuizMaster19 = PlayerPrefs.GetString(username + StudentID + "QuizMaster19");
        QuizMaster19isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster19isOn");
        QuizMaster20 = PlayerPrefs.GetString(username + StudentID + "QuizMaster20");
        QuizMaster20isOn = PlayerPrefs.GetInt(username + StudentID + "QuizMaster20isOn");
                


        if (QuizMaster1isOn == 1)
        {
            Stamp1.SetActive(true);
        }
        if (QuizMaster2isOn == 1)
        {
            Stamp2.SetActive(true);
        }
        if (QuizMaster3isOn == 1)
        {
            Stamp3.SetActive(true);
        }
        if (QuizMaster4isOn == 1)
        {
            Stamp4.SetActive(true);
        }
        if (QuizMaster5isOn == 1)
        {
            Stamp5.SetActive(true);
        }
        if (QuizMaster6isOn == 1)
        {
            Stamp6.SetActive(true);
        }
        if (QuizMaster7isOn == 1)
        {
            Stamp7.SetActive(true);
        }
        if (QuizMaster8isOn == 1)
        {
            Stamp8.SetActive(true);
        }
        if (QuizMaster9isOn == 1)
        {
            Stamp9.SetActive(true);
        }
        if (QuizMaster10isOn == 1)
        {
            Stamp10.SetActive(true);
        }
        if (QuizMaster11isOn == 1)
        {
            Stamp11.SetActive(true);
        }
        if (QuizMaster12isOn == 1)
        {
            Stamp12.SetActive(true);
        }
        if (QuizMaster13isOn == 1)
        {
            Stamp13.SetActive(true);
        }
        if (QuizMaster14isOn == 1)
        {
            Stamp14.SetActive(true);
        }
        if (QuizMaster15isOn == 1)
        {
            Stamp15.SetActive(true);
        }
        if (QuizMaster16isOn == 1)
        {
            Stamp16.SetActive(true);
        }
        if (QuizMaster17isOn == 1)
        {
            Stamp17.SetActive(true);
        }
        if (QuizMaster18isOn == 1)
        {
            Stamp18.SetActive(true);
        }
        if (QuizMaster19isOn == 1)
        {
            Stamp19.SetActive(true);
        }
        if (QuizMaster20isOn == 1)
        {
            Stamp20.SetActive(true);
        }


        if(EndScreen==true){

        AddStamps();
        }

    }
    public void AddStamps()
    {
        if (QuizMaster1isOn == 0)
        {
            QuizMaster1 = currentQuizMaster;
            Stamp1.SetActive(true);
            QuizMaster1isOn = 1;
            PlayerPrefs.SetString(username + StudentID + "QuizMaster1", QuizMaster1);
            PlayerPrefs.SetInt(username + StudentID + "QuizMaster1isOn", 1);
        }
        else if (QuizMaster1isOn == 1)
        {
            if (QuizMaster1 != currentQuizMaster)
            {
                if (QuizMaster2isOn == 0)
                {
                    QuizMaster2 = currentQuizMaster;
                    Stamp2.SetActive(true);
                    QuizMaster2isOn = 1;
                    PlayerPrefs.SetString(username + StudentID + "QuizMaster2", QuizMaster2);
                    PlayerPrefs.SetInt(username + StudentID + "QuizMaster2isOn", 1);
                }
                else if (QuizMaster2isOn == 1)
                {
                    if (QuizMaster2 != currentQuizMaster)
                    {
                        if (QuizMaster3isOn == 0)
                        {
                            QuizMaster3 = currentQuizMaster;
                            Stamp3.SetActive(true);
                            QuizMaster3isOn = 1;
                            PlayerPrefs.SetString(username + StudentID + "QuizMaster3", QuizMaster3);
                            PlayerPrefs.SetInt(username + StudentID + "QuizMaster3isOn", 1);
                        }
                        else if (QuizMaster3isOn == 1)
                        {
                            if (QuizMaster3 != currentQuizMaster)
                            {
                                if (QuizMaster4isOn == 0)
                                {
                                    QuizMaster4 = currentQuizMaster;
                                    Stamp4.SetActive(true);
                                    QuizMaster4isOn = 1;
                                    PlayerPrefs.SetString(username + StudentID + "QuizMaster4", QuizMaster4);
                                    PlayerPrefs.SetInt(username + StudentID + "QuizMaster4isOn", 1);
                                }
                                else if (QuizMaster4isOn == 1)
                                {
                                    if (QuizMaster4 != currentQuizMaster)
                                    {
                                        if (QuizMaster5isOn == 0)
                                        {
                                            QuizMaster5 = currentQuizMaster;
                                            Stamp5.SetActive(true);
                                            QuizMaster5isOn = 1;
                                            PlayerPrefs.SetString(username + StudentID + "QuizMaster5", QuizMaster5);
                                            PlayerPrefs.SetInt(username + StudentID + "QuizMaster5isOn", 1);
                                        }
                                        else if (QuizMaster5isOn == 1)
                                        {
                                            if (QuizMaster5 != currentQuizMaster)
                                            
                                            {
                                                if (QuizMaster6isOn == 0)
                                                {
                                                    QuizMaster6 = currentQuizMaster;
                                                    Stamp6.SetActive(true);
                                                    QuizMaster6isOn = 1;
                                                    PlayerPrefs.SetString(username + StudentID + "QuizMaster6", QuizMaster6);
                                                    PlayerPrefs.SetInt(username + StudentID + "QuizMaster6isOn", 1);
                                                }
                                                else if (QuizMaster6isOn == 1)
                                                {
                                                    if (QuizMaster6 != currentQuizMaster)
                                                    {
                                                        if (QuizMaster7isOn == 0)
                                                        {
                                                            QuizMaster7 = currentQuizMaster;
                                                            Stamp7.SetActive(true);
                                                            QuizMaster7isOn = 1;
                                                            PlayerPrefs.SetString(username + StudentID + "QuizMaster7", QuizMaster7);
                                                            PlayerPrefs.SetInt(username + StudentID + "QuizMaster7isOn", 1);
                                                        }
                                                        else if (QuizMaster7isOn == 1)
                                                        {
                                                            if (QuizMaster8 != currentQuizMaster)
                                                            {
                                                                if (QuizMaster8isOn == 0)
                                                                {
                                                                    QuizMaster8 = currentQuizMaster;
                                                                    Stamp8.SetActive(true);
                                                                    QuizMaster8isOn = 1;
                                                                    PlayerPrefs.SetString(username + StudentID + "QuizMaster8", QuizMaster8);
                                                                    PlayerPrefs.SetInt(username + StudentID + "QuizMaster8isOn", 1);
                                                                }
                                                                else if (QuizMaster8isOn == 1)
                                                                {
                                                                    if (QuizMaster9 != currentQuizMaster)
                                                                    {
                                                                        if (QuizMaster9isOn == 0)
                                                                        {
                                                                            QuizMaster9 = currentQuizMaster;
                                                                            Stamp9.SetActive(true);
                                                                            QuizMaster9isOn = 1;
                                                                            PlayerPrefs.SetString(username + StudentID + "QuizMaster9", QuizMaster9);
                                                                            PlayerPrefs.SetInt(username + StudentID + "QuizMaster9isOn", 1);
                                                                        }
                                                                        else if (QuizMaster9isOn == 1)
                                                                        {
                                                                            if (QuizMaster10 != currentQuizMaster)
                                                                            {
                                                                                if (QuizMaster10isOn == 0)
                                                                                {
                                                                                    QuizMaster10 = currentQuizMaster;
                                                                                    Stamp10.SetActive(true);
                                                                                    QuizMaster10isOn = 1;
                                                                                    PlayerPrefs.SetString(username + StudentID + "QuizMaster10", QuizMaster10);
                                                                                    PlayerPrefs.SetInt(username + StudentID + "QuizMaster10isOn", 1);
                                                                                }
                                                                                else if (QuizMaster10isOn == 1)
                                                                                {
                                                                                    if (QuizMaster11isOn == 0)
                                                                                    {
                                                                                        QuizMaster11 = currentQuizMaster;
                                                                                        Stamp11.SetActive(true);
                                                                                        QuizMaster11isOn = 1;
                                                                                        PlayerPrefs.SetString(username + StudentID + "QuizMaster11", QuizMaster11);
                                                                                        PlayerPrefs.SetInt(username + StudentID + "QuizMaster11isOn", 1);
                                                                                    }
                                                                                    else if (QuizMaster11isOn == 1)
                                                                                    {
                                                                                        if (QuizMaster11 != currentQuizMaster)
                                                                                        {
                                                                                            if (QuizMaster12isOn == 0)
                                                                                            {
                                                                                                QuizMaster12 = currentQuizMaster;
                                                                                                Stamp12.SetActive(true);
                                                                                                QuizMaster2isOn = 1;
                                                                                                PlayerPrefs.SetString(username + StudentID + "QuizMaster12", QuizMaster12);
                                                                                                PlayerPrefs.SetInt(username + StudentID + "QuizMaster12isOn", 1);
                                                                                            }
                                                                                            else if (QuizMaster12isOn == 1)
                                                                                            {
                                                                                                if (QuizMaster12 != currentQuizMaster)
                                                                                                {
                                                                                                    if (QuizMaster13isOn == 0)
                                                                                                    {
                                                                                                        QuizMaster13 = currentQuizMaster;
                                                                                                        Stamp13.SetActive(true);
                                                                                                        QuizMaster13isOn = 1;
                                                                                                        PlayerPrefs.SetString(username + StudentID + "QuizMaster3", QuizMaster13);
                                                                                                        PlayerPrefs.SetInt(username + StudentID + "QuizMaster13isOn", 1);
                                                                                                    }
                                                                                                    else if (QuizMaster13isOn == 1)
                                                                                                    {
                                                                                                        if (QuizMaster13 != currentQuizMaster)
                                                                                                        {
                                                                                                            if (QuizMaster14isOn == 0)
                                                                                                            {
                                                                                                                QuizMaster14 = currentQuizMaster;
                                                                                                                Stamp14.SetActive(true);
                                                                                                                QuizMaster14isOn = 1;
                                                                                                                PlayerPrefs.SetString(username + StudentID + "QuizMaster14", QuizMaster14);
                                                                                                                PlayerPrefs.SetInt(username + StudentID + "QuizMaster14isOn", 1);
                                                                                                            }
                                                                                                            else if (QuizMaster14isOn == 1)
                                                                                                            {
                                                                                                                if (QuizMaster14 != currentQuizMaster)
                                                                                                                {
                                                                                                                    if (QuizMaster15isOn == 0)
                                                                                                                    {
                                                                                                                        QuizMaster15 = currentQuizMaster;
                                                                                                                        Stamp15.SetActive(true);
                                                                                                                        QuizMaster15isOn = 1;
                                                                                                                        PlayerPrefs.SetString(username + StudentID + "QuizMaster15", QuizMaster15);
                                                                                                                        PlayerPrefs.SetInt(username + StudentID + "QuizMaster15isOn", 1);
                                                                                                                    }
                                                                                                                    else if (QuizMaster15isOn == 1)
                                                                                                                    {
                                                                                                                        if (QuizMaster15 != currentQuizMaster)
                                                                                                                        
                                                                                                                        {
                                                                                                                            if (QuizMaster16isOn == 0)
                                                                                                                            {
                                                                                                                                QuizMaster16 = currentQuizMaster;
                                                                                                                                Stamp16.SetActive(true);
                                                                                                                                QuizMaster16isOn = 1;
                                                                                                                                PlayerPrefs.SetString(username + StudentID + "QuizMaster16", QuizMaster6);
                                                                                                                                PlayerPrefs.SetInt(username + StudentID + "QuizMaster16isOn", 1);
                                                                                                                            }
                                                                                                                            else if (QuizMaster16isOn == 1)
                                                                                                                            {
                                                                                                                                if (QuizMaster16 != currentQuizMaster)
                                                                                                                                {
                                                                                                                                    if (QuizMaster17isOn == 0)
                                                                                                                                    {
                                                                                                                                        QuizMaster17 = currentQuizMaster;
                                                                                                                                        Stamp17.SetActive(true);
                                                                                                                                        QuizMaster17isOn = 1;
                                                                                                                                        PlayerPrefs.SetString(username + StudentID + "QuizMaster17", QuizMaster17);
                                                                                                                                        PlayerPrefs.SetInt(username + StudentID + "QuizMaster17isOn", 1);
                                                                                                                                    }
                                                                                                                                    else if (QuizMaster17isOn == 1)
                                                                                                                                    {
                                                                                                                                        if (QuizMaster18 != currentQuizMaster)
                                                                                                                                        {
                                                                                                                                            if (QuizMaster18isOn == 0)
                                                                                                                                            {
                                                                                                                                                QuizMaster18 = currentQuizMaster;
                                                                                                                                                Stamp18.SetActive(true);
                                                                                                                                                QuizMaster18isOn = 1;
                                                                                                                                                PlayerPrefs.SetString(username + StudentID + "QuizMaster18", QuizMaster8);
                                                                                                                                                PlayerPrefs.SetInt(username + StudentID + "QuizMaster18isOn", 1);
                                                                                                                                            }
                                                                                                                                            else if (QuizMaster18isOn == 1)
                                                                                                                                            {
                                                                                                                                                if (QuizMaster19 != currentQuizMaster)
                                                                                                                                                {
                                                                                                                                                    if (QuizMaster19isOn == 0)
                                                                                                                                                    {
                                                                                                                                                        QuizMaster19 = currentQuizMaster;
                                                                                                                                                        Stamp19.SetActive(true);
                                                                                                                                                        QuizMaster19isOn = 1;
                                                                                                                                                        PlayerPrefs.SetString(username + StudentID + "QuizMaster19", QuizMaster19);
                                                                                                                                                        PlayerPrefs.SetInt(username + StudentID + "QuizMaster19isOn", 1);
                                                                                                                                                    }
                                                                                                                                                    else if (QuizMaster19isOn == 1)
                                                                                                                                                    {
                                                                                                                                                        if (QuizMaster20 != currentQuizMaster)
                                                                                                                                                        {
                                                                                                                                                            if (QuizMaster20isOn == 0)
                                                                                                                                                            {
                                                                                                                                                                QuizMaster20 = currentQuizMaster;
                                                                                                                                                                Stamp20.SetActive(true);
                                                                                                                                                                QuizMaster20isOn = 1;
                                                                                                                                                                PlayerPrefs.SetString(username + StudentID + "QuizMaster20", QuizMaster10);
                                                                                                                                                                PlayerPrefs.SetInt(username + StudentID + "QuizMaster20isOn", 1);
                                                                                                                                                            }
                                                                                                                                                            else if (QuizMaster20isOn == 1)
                                                                                                                                                            {
                                                                                                                                                            
                                                                                                                                                            }
                                                                                                                                                            
                                                                                                                                                        }
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            
                                                                                        }
                                                                                    }
                                                                                
                                                                                }
                                                                                
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
            }
        }
        SaveStamps();
    }

    public void SaveStamps()
    {
        //Send location data to json

        // Create a new data object and populate it
        StampsData dataToSend = new StampsData();
        dataToSend.filename = filename;
        dataToSend.QuizMaster1 = QuizMaster1;
        dataToSend.QuizMaster1isOn = QuizMaster1isOn;
        dataToSend.QuizMaster2 = QuizMaster2;
        dataToSend.QuizMaster2isOn = QuizMaster2isOn;
        dataToSend.QuizMaster3 = QuizMaster3;
        dataToSend.QuizMaster3isOn = QuizMaster3isOn;
        dataToSend.QuizMaster4 = QuizMaster4;
        dataToSend.QuizMaster4isOn = QuizMaster4isOn;
        dataToSend.QuizMaster5 = QuizMaster5;
        dataToSend.QuizMaster5isOn = QuizMaster5isOn;
        dataToSend.QuizMaster6 = QuizMaster6;
        dataToSend.QuizMaster6isOn = QuizMaster6isOn;
        dataToSend.QuizMaster7 = QuizMaster7;
        dataToSend.QuizMaster7isOn = QuizMaster7isOn;
        dataToSend.QuizMaster8 = QuizMaster8;
        dataToSend.QuizMaster8isOn = QuizMaster8isOn;
        dataToSend.QuizMaster9 = QuizMaster9;
        dataToSend.QuizMaster9isOn = QuizMaster9isOn;        
        dataToSend.QuizMaster10 = QuizMaster10;
        dataToSend.QuizMaster10isOn = QuizMaster10isOn;
        dataToSend.QuizMaster11 = QuizMaster11;
        dataToSend.QuizMaster11isOn = QuizMaster11isOn;
        dataToSend.QuizMaster12 = QuizMaster12;
        dataToSend.QuizMaster12isOn = QuizMaster12isOn;
        dataToSend.QuizMaster13 = QuizMaster13;
        dataToSend.QuizMaster13isOn = QuizMaster13isOn;
        dataToSend.QuizMaster14 = QuizMaster14;
        dataToSend.QuizMaster14isOn = QuizMaster14isOn;
        dataToSend.QuizMaster15 = QuizMaster15;
        dataToSend.QuizMaster15isOn = QuizMaster15isOn;
        dataToSend.QuizMaster16 = QuizMaster16;
        dataToSend.QuizMaster16isOn = QuizMaster16isOn;
        dataToSend.QuizMaster17 = QuizMaster17;
        dataToSend.QuizMaster17isOn = QuizMaster17isOn;
        dataToSend.QuizMaster18 = QuizMaster18;
        dataToSend.QuizMaster18isOn = QuizMaster18isOn;
        dataToSend.QuizMaster19 = QuizMaster19;
        dataToSend.QuizMaster19isOn = QuizMaster19isOn;        
        dataToSend.QuizMaster20 = QuizMaster20;
        dataToSend.QuizMaster20isOn = QuizMaster20isOn;


        // Convert the object to a JSON string
        string json = JsonUtility.ToJson(dataToSend);

        // Send the JSON data to the PHP script
        StartCoroutine(SendJsonToServer(json));

    }

    IEnumerator SendJsonToServer(string jsonData)
    {
        // Create a UnityWebRequest for a POST request
        UnityWebRequest request = new UnityWebRequest(SaveStampsPHPUrl, "POST");

        // Convert the JSON string to bytes
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);

        // Set the upload handler with the raw data
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);

        // Set the download handler to receive the server's response
        request.downloadHandler = new DownloadHandlerBuffer();

        // Set the Content-Type header to indicate JSON data
        request.SetRequestHeader("Content-Type", "application/json");

        // Send the request
        yield return request.SendWebRequest();

        // Check for errors
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error sending JSON: " + request.error);
        }
        else
        {
            Debug.Log("JSON sent successfully. Server response: " + request.downloadHandler.text);
        }
    }
}