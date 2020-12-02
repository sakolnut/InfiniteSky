using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class FacebookScript : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Login;
    public GameObject Username;
    public GameObject UserPicture;

    void Awake()
    {

        
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    Debug.LogError("Couldn't initialize");
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
            FB.ActivateApp();
       
    }

    public void FaceBooklogin()
    {
        List<string> permissions = new List<string>();
        permissions.Add("public_profile");

        FB.LogInWithReadPermissions(permissions, AuthCallBack);
    }
    public void FaceBookLogout()
    {
        Menu.SetActive(false);
        Login.SetActive(true);
        FB.LogOut();
    }
    void AuthCallBack(IResult result)
    {
        if (result.Error != null)
        {
            Debug.Log(result.Error);
        }
        else
        {
            if (FB.IsLoggedIn)
            {
                FacebookMNG.Instance.IsLoggedIn = true;
                FacebookMNG.Instance.GetProfile();
                Debug.Log("FB is logged in");
            }
            else
            {
                Debug.Log("FB is not logged in");
            }
            DealWithFBMenus(FB.IsLoggedIn);
        }
    }

    void DealWithFBMenus(bool IsLoggedIn)
    {
        if (IsLoggedIn)
        {
            Menu.SetActive(true);
            Login.SetActive(false);

            if (FacebookMNG.Instance.ProfileName != null)
            {
                Text UserName = Username.GetComponent<Text>();
                UserName.text = "" + FacebookMNG.Instance.ProfileName;
            }
            else
            {
                StartCoroutine("WaitForProfileName");
            }
            if (FacebookMNG.Instance.ProfilePic != null)
            {
                Image ProfilePic = UserPicture.GetComponent<Image>();
                ProfilePic.sprite = FacebookMNG.Instance.ProfilePic;
            }
            else
            {
                StartCoroutine("WaitForProfilePic");
            }
        }
        else
        {
            Menu.SetActive(false);
            Login.SetActive(true);
        }
    }
    IEnumerator WaitForProfileName()
    {
        while (FacebookMNG.Instance.ProfileName == null)
        {
            yield return null;
        }
        DealWithFBMenus(FB.IsLoggedIn);
    }
    IEnumerator WaitForProfilePic()
    {
        while (FacebookMNG.Instance.ProfilePic == null)
        {
            yield return null;
        }
        DealWithFBMenus(FB.IsLoggedIn);
    }

    public void Share()
    {
        FacebookMNG.Instance.Share();
    }

}