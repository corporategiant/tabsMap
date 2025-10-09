using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Login : MonoBehaviour
{
	public InputField username;
	public InputField password;
    public GameObject failMessage;
    public Dictionary<string, string> AdvancedTextiles = new Dictionary<string, string>() {
        {"Ayako","63F9040J"},
        {"Howie","POKO3311"},
        {"Justin","KOKO3311"},
        {"KyoungOk","KOKO3311"},
        {"Shunichi","KOKO3311"},
        {"Sam","KOKO3311"},
        {"Ham","KOKO3311"},
        {"David","KOKO3311"},
        {"Hamano","KOKO3311"},
        {"Fawaz","KOKO3311"},

        {"Akari","24F1041G"},
        {"Aki","24F1020D"},
        {"An","23F1005G"},
        {"Anna","24F1036A"},
        {"Arai","24F3005A"},
        {"Arata","24F1034D"},
        {"Ayaka","24F1054J"},
        {"Chiharu","24F1013A"},
        {"Eita","24F1018B"},
        {"Fuka","24F1044A"},
        {"Furi","24F1046H"},
        {"Genta","24F3048E"},
        {"Hanano","24F1064F"},
        {"Haruto","24F3010H"},
        {"Hayate","24F1058A"},
        {"Hinata","24F1060C"},
        {"Hiroi","24F1023J"},
        {"Hiroki","24F2024B"},
        {"Hyashi","24F1050F"},
        {"Ikumi","24F1043C"},
        {"Kaisei","20F1019F"},
        {"Kana","24F1030A"},
        {"Karatsu","24F1019A"},
        {"Kazuki","24F1027A"},
        {"Kanta","24F1002F"},
        {"Kenta","24F1053A"},
        {"Koki","24F1061A"},
        {"Kokona","KRKK0903"},
        {"Kouki","KOUKI2021"},
        {"Koyo","24F2013G"},
        {"Kyoichiro","24F1057C"},
        {"Maiko","24F1005A"},
        {"Makiko","24F1037J"},
        {"Manami","24F1038G"},
        {"Masahiro","24F1009C"},
        {"Mei","24F1014K"},
        {"Mio","24F1021B"},
        {"Miyu","24F1011E"},
        {"Momoka","24F1001H"},
        {"Momo","24F1031K"},
        {"Nao","24F1048D"},
        {"Nodoka","24F1025E"},
        {"Nozomi","24F1035B"},
        {"Rion","24F1026C"},
        {"Ruka","24F1066B"},
        {"Ryota","24F1062K"},
        {"Ryusei","24F1004B"},
        {"Sakura","24F1010G"},
        {"Shise","24F1024G"},
        {"Shoichiro","24F1032H"},
        {"Souichi","24F1015H"},
        {"Taisei","24F1052B"},
        {"Taku","24F1029H"},
        {"Takumu","22F1064J"},
        {"Wakana","24F1006J"},
        {"Yoshizawa","24F3106F"},
        {"Yui","23F1801E"},
        {"Yuika","24F1059K"},
        {"Yukari","KOKO3311"},
        {"Yuki","24F1016F"},
        {"Yusuke","23F3110A"},
        {"Yuma","24F1003D"},
        {"Yuta","24F1012C"},
        {"Yuzuki","24F1051D"},
    };
    public Dictionary<string, string> Robotics = new Dictionary<string, string>() {

        {"Daigo","KOKO3311"},

        {"Aika","24F2007B"},
        {"Asahi","24F2041B"},
        {"Atsuya","24F2054D"},
        {"Hiroki","24F2048K"},
        {"Hibiki","24F2019F"},
        {"Hideto","24F2033A"},
        {"Isogai","24F2004H"},
        {"Kaede","24F2036F"},
        {"Kakeru","24F2051K"},
        {"Kodai","24F2029C"},
        {"Koh","24F2034K"},
        {"Koji","24F2040D"},
        {"Kosei","24F2010B"},
        {"Kosuke","24F2043J"},
        {"Kotaro","24F2021H"},
        {"Kouki","23F2011G"},
        {"Koyo","24F2037D"},
        {"Kyohei","24F2052H"},
        {"Liu","24F2059E"},
        {"Mahiro","24F1033F"},
        {"Masanao","24F2003K"},
        {"Matsuo","24F2055B"},
        {"Megumi","24F2015C"},
        {"Miku","24F2012J"},
        {"Mineto","24F2046C"},
        {"Naoto","24F1056E"},
        {"Nana","24F2601A"},
        {"Nanami","24F2017K"},
        {"Neito","24F1007G"},
        {"Otoho","24F2045E"},
        {"Ren","24F1017D"},
        {"Sakura","24F2060J"},
        {"Seina","24F2006D"},
        {"Shinnosuke","24F1040J"},
        {"Shinya","24F2002A"},
        {"Shion","24F2050A"},
        {"Shotaro","24F2011A"},
        {"Shun","22F2050D"},
        {"Shunsuke","24F2025A"},
        {"Shuta","24F2030G"},
        {"Shuya","24F2001C"},
        {"Soichi","24F2016A"},
        {"Sota","24F2039A"},
        {"Suzuki","24F2035H"},
        {"Syuji","24F2022F"},
        {"Takuma","24F2053F"},
        {"Taishi","24F2042A"},
        {"Tenki","24F2005F"},
        {"Tomoharu","24F2027G"},
        {"Tomohiro","24F2058G"},
        {"Tomoki","24F2026J"},
        {"Tsubasa","24F2020K"},
        {"Wang","24F2008A"},
        {"Yakame","22F1058D"},
        {"Yokota","24F2057J"},
        {"Yuji","24F2009J"},
        {"Yuna","24F2044G"},
        {"Yusuke","24F1039E"},
    };
    public Dictionary<string, string> Chemistry = new Dictionary<string, string>() {

        {"Yasuhiro","KOKO3311"},

        {"Akane","AKANE0708"},
        {"Akari","24F3090F"},
        {"Atsuki","24F3086H"},
        {"Atsuya","24F3007H"},
        {"Ayami","24F3075B"},
        {"Azusa","24F3097C"},
        {"Chie","24F3081G"},
        {"Eri","24F3057D"},
        {"Eito","24F3050G"},
        {"Fuki","24F3003E"},
        {"Haruaki","24F3073F"},
        {"Haruto","24F3076A"},
        {"Hayashi","24F3015J"},
        {"Hayato","24F3056F"},
        {"Hiroto","24F3088D"},
        {"Hitomi","24F3051E"},
        {"Honda","24F3091D"},
        {"Hotaka","24F3047G"},
        {"Ichika","24F3035C"},
        {"Kaito","24F3001J"},
        {"Kanata","235711VC"},
        {"Karin","24F3002G"},
        {"Katsuma","21F1060B"},
        {"Kazuhiro","24F3107D"},
        {"Kazuma","24F3085K"},
        {"Kazuki","22F3077A"},
        {"Kenshin","24F3017E"},
        {"Kensho","24F3101E"},
        {"Kodai","23F3048A"},
        {"Kouhei","24F3102C"},
        {"Koki","24F3033G"},
        {"Kokichi","24F3096E"},
        {"Kokona","24F1022A"},
        {"Kosei","22F1062B"},
        {"Koshiro","24F3041H"},
        {"Kota","24F3071K"},
        {"Koumei","24F3095G"},
        {"Kounosuke","24F3067A"},
        {"Koyo","22F1061D"},
        {"Mao","24F3066C"},
        {"Mari","24F3093A"},
        {"Masaki","24F3034E"},
        {"Masanari","24F3100G"},
        {"Masatoshi","24F3080J"},
        {"Masato","24F3058B"},
        {"Masaya","23F3024D"},
        {"Mikome","24F3095G"},
        {"Minori","24F3098A"},
        {"Mizuki","24F3031A"},
        {"Muneaki","24F3013B"},
        {"Nanaru","24F3004C"},
        {"Reishi","24F3020E"},
        {"Reito","24F3038H"},
        {"Riko","24F3036A"},
        {"Rina","24F3062A"},
        {"Ryo","24F3044B"},
        {"Ryoji","24F3039F"},
        {"Ryoga","24F3084A"},
        {"Ryoma","24F3059A"},
        {"Ryota","24F3053A"},
        {"Sakuya","24F3108B"},
        {"Sara","24F3054K"},
        {"Sasuke","24F3014A"},
        {"Shion","24F3082E"},
        {"Shinta","24F3046J"},
        {"Shitaro","24F3027B"},
        {"Shoma","24F3052C"},
        {"Shuta","24F3065E"},
        {"Shuto","24F3032J"},
        {"So","24F2057J"},
        {"Sohei","24F3025F"},
        {"Sou","24F3015J"},
        {"Souma","24F3055H"},
        {"Taichi","24F3069H"},
        {"Taiki","24F3012D"},
        {"Taisei","24F1055G"},
        {"Takeuchi","23F3058J"},
        {"Takumi","24F3028A"},
        {"Tamaki","24F3104K"},
        {"Tensho","24F3089B"},
        {"Teppei","24F3061B"},
        {"Tomoya","24F3083C"},
        {"Toshihiro","24F2038B"},
        {"Tsuyoshi","23F3062G"},
        {"Yasuto","24F3019A"},
        {"Yuga","24F3029J"},
        {"Yugo","24F3030B"},
        {"Yuhei","24F3024H"},
        {"Yuika","20050811"},
        {"Yuki","24F3079E"},
        {"Yuina","24F3018C"},
        {"Yuma","24F3064G"},
        {"Yumi","24F3011F"},
        {"Yuta","24F3049C"},
        {"Yutaro","24F3072H"},
        {"Yuto","24F3068K"},
        {"Yuuka","24F3077J"},
        {"Wang","24F3016G"},

    };
    public Dictionary<string, string> Biology = new Dictionary<string, string>() {
        {"Seiji","KOKO3311"},

        {"Ageha","24F4036G"},
        {"Aito","24F3092B"},
        {"Akira","24F4013H"},
        {"Aoi","24F4029D"},
        {"Asahi","21F4003K"},
        {"Ayumu","24F4028F"},
        {"Azusa","24F4023E"},
        {"Chiaki","24F4040E"},
        {"Chisato","24F4007C"},
        {"Christian","24F4005G"},
        {"Hana","24F3063J"},
        {"Haru","24F4026K"},
        {"Haruka","24F4042A"},
        {"Haruna","24F3026D"},
        {"Hiidome","24F4038C"},
        {"Himeka","24F4046D"},
        {"Hinako","24F4008A"},
        {"Hiroki","24F4030H"},
        {"Hirotaka","24F4006E"},
        {"Kakeru","24F4025A"},
        {"Kao","24F4011A"},
        {"Kazuma","24F1008E"},
        {"Kurumi","24F4047B"},
        {"Kyouta","24F4043K"},
        {"Luje","24F4052J"},
        {"Masashi","24F4014F"},
        {"Mayuko","24F4010C"},
        {"Megumi","24F4031F"},
        {"Mio","24F4037E"},
        {"Miu","24F4032D"},
        {"Mizuki","24F4018J"},
        {"Momoko","24F4034A"},
        {"Nanase","24F4041C"},
        {"Onitsuka","24F4012K"},
        {"Riko","24F4016B"},
        {"Ryogo","24F4004J"},
        {"Ryota","24F4017A"},
        {"Sakai","24F4019G"},
        {"Sayana","24F4045F"},
        {"Shoji","24F4050B"},
        {"Shota","24F4024C"},
        {"Shuntaro","24F4009K"},
        {"Shunya","24F4033B"},
        {"Shuta","24F4001D"},
        {"So","AOI326JP"},
        {"Tomohiro","24F4021J"},
        {"Tsubasa","24F4015D"},
        {"Yosuke","24F4020A"},
        {"Yu","24F4003A"},
        {"Yuki","23F1050B"},
        {"Yuma","24F4035J"},
        {"Yuzu","24F4044H"},

    };

    public Dictionary<string, string> AdvancedTextiles2 = new Dictionary<string, string>() {
        {"Ayaka","24F1028K"},
        {"Kenta","24F1049B"},
    };

    public Dictionary<string, string> AdvancedTextiles3 = new Dictionary<string, string>() {
        {"Kenta","24F1002F"},
    };

    public Dictionary<string, string> Robotics2 = new Dictionary<string, string>()
    {
        {"Kosuke","24F2049H"},
        {"Yusuke","24F2018H"},
    };

    public Dictionary<string, string> Robotics3 = new Dictionary<string, string>()
    {
        {"Yusuke","24F2023D"},
    };

    public Dictionary<string, string> Biology2 = new Dictionary<string, string>()
    {
        {"Aoi","24F4049J"},
        {"Hiroki","HYNK4483"},
        {"Ryota","24F4022G"},
        {"Shunya","24F4039A"},
        {"Yu","24F4027H"},

    };

    public Dictionary<string, string> Chemistry2 = new Dictionary<string, string>()
    {
        {"Akane","24F3008F"},
        {"Atsuki","24F3009D"},
        {"Haruto","24F3078G"},
        {"Kenshin","24F3040K"},
        {"Koki","24F3023K"},
        {"Mizuki","24F3070A"},
        {"Ryo","24F3094J"},
        {"Shuto","24F3032J"},
        {"Taichi","24F3105H"},
    };

    public Dictionary<string, string> Chemistry3 = new Dictionary<string, string>()
    {
        {"Koki","24F3099K"},
    };

    string foundPassword;


    [SerializeField] GameObject welcomePanel;
	[SerializeField] Text user;

	[SerializeField] GameObject progressCircle;


	[SerializeField] Button loginButton;

	
	private void Start()
	{
		if (PlayerPrefs.GetInt("LoggedIn") == 1)
		{
			username.text = PlayerPrefs.GetString("username");
			password.text = PlayerPrefs.GetString("StudentID");
		}

		if (PlayerPrefs.GetInt("LoggedIn") == 0)
		{
			PlayerPrefs.SetInt("Major", 1);
		}
		
	}

    public void OnLoginButtonClicked()
	{
		//Debug.Log("Login Button was clicked");
        failMessage.SetActive(false);
        loginButton.interactable = false;
		progressCircle.SetActive(true);
		StartCoroutine(StartLogin());
	}

	IEnumerator StartLogin ()
	{
        if (AdvancedTextiles.TryGetValue(username.text, out foundPassword) && (foundPassword == password.text))
        {
            yield return new WaitForSeconds(2f);
            //open welcome panel
            welcomePanel.SetActive(true);
            user.text = username.text;
            PlayerPrefs.SetString("StudentID", password.text);
            PlayerPrefs.SetString("username", username.text);
            PlayerPrefs.SetInt("LoggedIn", 1);
            PlayerPrefs.SetInt("Major", 1);
            //Debug.Log("Login Succesful");//user exist

        }

        else if (Robotics.TryGetValue(username.text, out foundPassword) && (foundPassword == password.text))
        {
            yield return new WaitForSeconds(2f);
            //open welcome panel
            welcomePanel.SetActive(true);
            user.text = username.text;
            PlayerPrefs.SetString("StudentID", password.text);
            PlayerPrefs.SetString("username", username.text);
            PlayerPrefs.SetInt("LoggedIn", 1);
            PlayerPrefs.SetInt("Major", 2);
            //Debug.Log("Login Succesful");//user exist

        }

        else if (Chemistry.TryGetValue(username.text, out foundPassword) && (foundPassword == password.text))
        {
            yield return new WaitForSeconds(2f);
            //open welcome panel
            welcomePanel.SetActive(true);
            user.text = username.text;
            PlayerPrefs.SetString("StudentID", password.text);
            PlayerPrefs.SetString("username", username.text);
            PlayerPrefs.SetInt("LoggedIn", 1);
            PlayerPrefs.SetInt("Major", 3);

            //Debug.Log("Login Succesful");//user exist
        }

        else if (Biology.TryGetValue(username.text, out foundPassword) && (foundPassword == password.text))
        {
            yield return new WaitForSeconds(2f);
            //open welcome panel
            welcomePanel.SetActive(true);
            user.text = username.text;
            PlayerPrefs.SetString("StudentID", password.text);
            PlayerPrefs.SetString("username", username.text);
            PlayerPrefs.SetInt("LoggedIn", 1);
            PlayerPrefs.SetInt("Major", 4);
            //Debug.Log("Login Succesful");//user exist
        }

        else if (AdvancedTextiles2.TryGetValue(username.text, out foundPassword) && (foundPassword == password.text))
        {
            yield return new WaitForSeconds(2f);
            //open welcome panel
            welcomePanel.SetActive(true);
            user.text = username.text;
            PlayerPrefs.SetString("StudentID", password.text);
            PlayerPrefs.SetString("username", username.text);
            PlayerPrefs.SetInt("LoggedIn", 1);
            PlayerPrefs.SetInt("Major", 1);
            //Debug.Log("Login Succesful");//user exist

        }

        else if (AdvancedTextiles3.TryGetValue(username.text, out foundPassword) && (foundPassword == password.text))
        {
            yield return new WaitForSeconds(2f);
            //open welcome panel
            welcomePanel.SetActive(true);
            user.text = username.text;
            PlayerPrefs.SetString("StudentID", password.text);
            PlayerPrefs.SetString("username", username.text);
            PlayerPrefs.SetInt("LoggedIn", 1);
            PlayerPrefs.SetInt("Major", 1);
            //Debug.Log("Login Succesful");//user exist

        }

        else if (Robotics2.TryGetValue(username.text, out foundPassword) && (foundPassword == password.text))
        {
            yield return new WaitForSeconds(2f);
            //open welcome panel
            welcomePanel.SetActive(true);
            user.text = username.text;
            PlayerPrefs.SetString("StudentID", password.text);
            PlayerPrefs.SetString("username", username.text);
            PlayerPrefs.SetInt("LoggedIn", 1);
            PlayerPrefs.SetInt("Major", 2);
            //Debug.Log("Login Succesful");//user exist

        }

        else if (Robotics3.TryGetValue(username.text, out foundPassword) && (foundPassword == password.text))
        {
            yield return new WaitForSeconds(2f);
            //open welcome panel
            welcomePanel.SetActive(true);
            user.text = username.text;
            PlayerPrefs.SetString("StudentID", password.text);
            PlayerPrefs.SetString("username", username.text);
            PlayerPrefs.SetInt("LoggedIn", 1);
            PlayerPrefs.SetInt("Major", 2);
            //Debug.Log("Login Succesful");//user exist

        }

        else if (Chemistry2.TryGetValue(username.text, out foundPassword) && (foundPassword == password.text))
        {
            yield return new WaitForSeconds(2f);
            //open welcome panel
            welcomePanel.SetActive(true);
            user.text = username.text;
            PlayerPrefs.SetString("StudentID", password.text);
            PlayerPrefs.SetString("username", username.text);
            PlayerPrefs.SetInt("LoggedIn", 1);
            PlayerPrefs.SetInt("Major", 3);
            //Debug.Log("Login Succesful");//user exist
        }

        else if (Chemistry3.TryGetValue(username.text, out foundPassword) && (foundPassword == password.text))
        {
            yield return new WaitForSeconds(2f);
            //open welcome panel
            welcomePanel.SetActive(true);
            user.text = username.text;
            PlayerPrefs.SetString("StudentID", password.text);
            PlayerPrefs.SetString("username", username.text);
            PlayerPrefs.SetInt("LoggedIn", 1);
            PlayerPrefs.SetInt("Major", 3);
            //Debug.Log("Login Succesful");//user exist
        }

        else if (Biology2.TryGetValue(username.text, out foundPassword) && (foundPassword == password.text))
        {
            yield return new WaitForSeconds(2f);
            //open welcome panel
            welcomePanel.SetActive(true);
            user.text = username.text;
            PlayerPrefs.SetString("StudentID", password.text);
            PlayerPrefs.SetString("username", username.text);
            PlayerPrefs.SetInt("LoggedIn", 1);
            PlayerPrefs.SetInt("Major", 4);
            //Debug.Log("Login Succesful");//user exist
        }


        else
        {
			//Debug.Log(" Login Failed");
		}
		yield return new WaitForSeconds(1);
		loginButton.interactable = true;
		progressCircle.SetActive(false);
        failMessage.SetActive(true);

	}


}