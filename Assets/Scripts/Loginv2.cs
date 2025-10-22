using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro; // For TextMeshPro input fields
using UnityEngine.UI;

// Wrapper class for the array of users
[Serializable]
public class UserList
{
    public User[] users;
}

// User data model
[Serializable]
public class User
{
    public string username;
    public string studentID;
    public int major;
}
public class Loginv2 : MonoBehaviour
{

    // Assign these from the Unity Editor
    public TMP_InputField usernameInput;
    public TMP_InputField studentIDInput;
    public GameObject errorMessage;
    public TextMeshProUGUI errorText;
    public string serverUrl = "https://your-server-address/get_users.php";
    [SerializeField] GameObject welcomePanel;
    [SerializeField] Text user;
    [SerializeField] GameObject progressCircle;
    [SerializeField] Button loginButton;


    void Start()
    {
        if (PlayerPrefs.GetInt("LoggedIn") == 1)
		{
			usernameInput.text = PlayerPrefs.GetString("username");
			studentIDInput.text = PlayerPrefs.GetString("StudentID");
		}

		if (PlayerPrefs.GetInt("LoggedIn") == 0)
		{
			PlayerPrefs.SetInt("Major", 1);
		}
        
    }
    public void OnLoginButtonClicked()
    {
        // Start a coroutine to handle the web request
        errorMessage.SetActive(false);
        loginButton.interactable = false;
        progressCircle.SetActive(true);
        StartCoroutine(AttemptLogin(usernameInput.text, studentIDInput.text));
    }

    private IEnumerator AttemptLogin(string username, string studentID)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(serverUrl);
        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + webRequest.error);
            errorMessage.SetActive(true);
            errorText.text = "Error: " + webRequest.error;
            
        }
        else
        {
            string jsonString = "{\"users\":" + webRequest.downloadHandler.text + "}";
            UserList userList = JsonUtility.FromJson<UserList>(jsonString);

            // Compare credentials
            bool loginSuccessful = false;
            foreach (User user in userList.users)
            {
                if (user.username == username && user.studentID == studentID)
                {
                    loginSuccessful = true;
                    PlayerPrefs.SetInt("Major", user.major);
                    break;
                }
            }

            if (loginSuccessful)
            {
                Debug.Log("Login successful!");
                errorMessage.SetActive(false);
                PlayerPrefs.SetString("StudentID", studentID);
                PlayerPrefs.SetString("username", username);
                PlayerPrefs.SetInt("LoggedIn", 1);
                welcomePanel.SetActive(true);
                user.text = username;

                // Proceed to the next scene or perform other actions
            }
            else
            {
                Debug.Log("Invalid username or password.");
                errorMessage.SetActive(true);
                errorText.text = "Invalid username or password.";

                loginButton.interactable = true;
                progressCircle.SetActive(false);
            }
        }
    }
}

