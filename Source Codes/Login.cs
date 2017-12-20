using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.Text.RegularExpressions;
//

public class Login : MonoBehaviour
{
	public GameObject password;
	public GameObject username;

	private string Password;
	private string Username;
	private string[] Lines;
	private string DecryptedPass;
	public void LoginButton()
	{
		sql_Login();       
	}


	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (username.GetComponent<InputField>().isFocused)
			{
				password.GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (Username != "" && Password != "")
			{
				LoginButton();
			}
		}
		Password = password.GetComponent<InputField>().text;
		Username = username.GetComponent<InputField>().text;

	}

	void sql_Login()
	{
		bool UN = false;
		bool PW = false;
		string conn = "URI=file:" + Application.dataPath + "/sqlLiteTesting.db"; //Path to database.
		IDbConnection dbconn;
		dbconn = (IDbConnection)new SqliteConnection(conn);
		dbconn.Open(); //Open connection to the database.
		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = "SELECT Username, Password FROM User";
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();
		/* while (reader.Read())
        {
            string value = reader.GetString(0);
            string name = reader.GetString(1);
            //int rand = reader.GetInt32(2);

            Debug.Log("User= " + value + "  Password =" + name);
        }
        */
		while (reader.Read())
		{
			string user = reader.GetString(0);
			string pass = reader.GetString(1);
			string decrypted_Pass = "";
			if (user != "")
			{
				if (Username == user)
				{
					UN = true;
					Debug.Log("Username matches");
					if (Password != "")
					{
						int i = 1;
						foreach (char c in pass)
						{
							i++;
							char Decrypted = (char)(c / i);
							decrypted_Pass += Decrypted.ToString();
						}
						// Debug.Log("pass= " + pass);
						Debug.Log("DecryptedPass= " + decrypted_Pass);
						if (decrypted_Pass == Password)
						{
							PW = true;
							Debug.Log("Password matched!");
						}
						else
						{
							Debug.LogWarning("Password is invalid");
						}
					}
					else
					{
						Debug.LogWarning("Password field is empty");
					}
				}
				else
				{
					Debug.LogWarning("Username did not match DB entry, checking next entry");
				}
			}
			else
			{
				Debug.LogWarning("Username field is empty");
			}

			if (UN == true && PW == true)
			{
				username.GetComponent<InputField>().text = "";
				password.GetComponent<InputField>().text = "";
				print("Login Successful");
				Application.LoadLevel("Level01");

			}
		}

	}
}