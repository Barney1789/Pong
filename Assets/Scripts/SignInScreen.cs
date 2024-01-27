using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class SignInScreen : MonoBehaviour
{

    private List<string> GetUserInput()
    {
        string username = GameObject.Find("CanvasSignIn/Background/InputUsername").GetComponent<TMP_InputField>().text;
        string password = GameObject.Find("CanvasSignIn/Background/InputPassword").GetComponent<TMP_InputField>().text;

        return new List<string> { username, password };
    }

   
    public void RegisterUser()
    {
        //Debug.Log("username:"+GetUserInput()[0]);
        //Debug.Log("password:" + GetUserInput()[1]);

        User_Model newUser = new User_Model() { password = GetUserInput()[1], username = GetUserInput()[0] };

        RestClient.Post(GameManager.baseURI + "/api/user-register", newUser).Then(response =>
        {
            print(response.StatusCode.ToString());
            JObject jObject = JObject.Parse(response.Text);
            print(jObject.GetValue("message"));

        })
        .Catch(err =>
        {
            var error = err as RequestException;
            print(error.StatusCode);
            print(error.Response);
            print(err.Message);
        });

    }

  
    public void SignIn()
    {
        User_Model user = new User_Model() { password = GetUserInput()[1], username = GetUserInput()[0] };
        RestClient.Post<User_Model>(GameManager.baseURI + "/api/user-signin", user).Then(response =>
        {
            //save login data in PlayerPrefs
            PlayerPrefs.SetString("JWT", response.accessToken);

            print("Logged in...jwt token saved in SharedPreferences");
            SceneManager.LoadScene("GameMenu");
        })
        .Catch(err =>
        {
            var error = err as RequestException;
            print(error.StatusCode);
            print(error.Response);
            print(err.Message);
        });

        
    }

}
