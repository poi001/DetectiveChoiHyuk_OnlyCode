using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InternetButton : MonoBehaviour
{

    public void SpartaBtn()
    {
        SceneManager.LoadScene("Computer_Internet");
    }
    public void BlogBtn()
    {
        SceneManager.LoadScene("Computer_Blog");
    }

    public void MailBtn()
    {
        SceneManager.LoadScene("Computer_Mail");
    }

    public void SendMailBtn()
    {
        SceneManager.LoadScene("Computer_SendMail");
    }
}
