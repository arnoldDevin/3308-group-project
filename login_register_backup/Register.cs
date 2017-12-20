using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using System.Data;
using Mono.Data.Sqlite;



public class Register : MonoBehaviour {
	public GameObject username;
	public GameObject email;
	public GameObject password;
	public GameObject confPassword;
    

	private string Username;
	private string Email;
	private string Password;
	private string ConfPassword;

	private string form; // holds all the above variables
	private bool EmailValid = false;
	private string [] Characters = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
		"0","1","2","3","4","5","6","7","8","9","_","-","%","@"};

	public void RegisterButton(){
		bool UN = false;
		bool EM = false;
		bool PW = false;
		bool CPW = false;

		if(Username != ""){
			if(!System.IO.File.Exists(Username + ".txt")){
				UN = true;
			}
			else{
				Debug.LogWarning("User name already exists");
			}
		}
		else{
			Debug.LogWarning("Username Field is empty");
		}
		if (Email != ""){
			EmailValidation ();
			if(EmailValid){
				if(Email.Contains("@")){
					if(Email.Contains(".")){
						EM = true;
					}else{
						Debug.LogWarning("Email is incorrect1");
					}
				}else{
					Debug.LogWarning("Email is incorrect2");
				}
			} else{
				Debug.LogWarning("Email is incorrect3");		
			}
		} else{
			Debug.LogWarning("Email Field is empty");		
		}
		if (Password != ""){
			if(Password.Length > 5){
				PW = true; 
			} else{
				Debug.LogWarning("Password must at least six characters");
			}
		} else {
			Debug.LogWarning("Password field is empty");
		}
		if (ConfPassword != ""){
			if (ConfPassword == Password){
				CPW  = true; 
			}else{
				Debug.LogWarning("Passwords don't match");
			}
		} else{
			Debug.LogWarning("Confirm password field is Empty ");
		}
		if (UN == true && EM == true && PW == true && CPW == true){
			bool Clear = true;
			int i = 1;
			foreach(char c in Password){
				if (Clear){
					Password = "";
					Clear = false;
				}
				i++;
			char Encrypted = (char)(c*i);
				Password +=Encrypted.ToString();
			}
			form = (Username+"\n"+Email+"\n"+Password);
			System.IO.File.WriteAllText(Username + ".txt", form);
			username.GetComponent<InputField> ().text = "";
			email.GetComponent<InputField> ().text = "";
			password.GetComponent<InputField> ().text = "";
			confPassword.GetComponent<InputField> ().text = "";

			string conn = "URI=file:" + Application.dataPath + "/sqlLiteTesting.db"; 
			IDbConnection dbconn;
			dbconn = (IDbConnection)new SqliteConnection(conn);
			dbconn.Open();
			IDbCommand dbcmd = dbconn.CreateCommand();
			string dbname = "User";
			dbcmd = dbconn.CreateCommand();
			string sqlInsert = "Insert INTO " + dbname + "(Username, Email, Password, Highscore) VALUES ('"+Username+"', '"+Email+"', '"+Password+"', '"+(Shooter.highScore)+"')";	 
			dbcmd.CommandText = sqlInsert;
			dbcmd.ExecuteNonQuery();
            /*IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                string value = reader.GetString(0);
                string name = reader.GetString(1);
                //int rand = reader.GetInt32(2);

            Debug.Log("User= " + value + "  Password =" + name);
            }*/
			print ("Registered " + Username);
		}
	}




	// Use this for initialization
	void Start () {
	}


	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)){
			if(username.GetComponent<InputField>().isFocused){
				email.GetComponent<InputField>().Select();
			}
			if(email.GetComponent<InputField>().isFocused){
				password.GetComponent<InputField>().Select();
			}
			if(password.GetComponent<InputField>().isFocused){
				confPassword.GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (Username != "" && Email != "" && Password != "" && ConfPassword != "") {
				RegisterButton ();
			}
		}
		Username = username.GetComponent<InputField>().text;
		Email = email.GetComponent<InputField>().text;
		Password= password.GetComponent<InputField>().text;
		ConfPassword = confPassword.GetComponent<InputField>().text;
		
	}

	void EmailValidation(){
		bool SW = false;
		bool EW = false;
		for (int i = 0; i < Characters.Length; i++) {
			if (Email.StartsWith (Characters [i])) {
				SW = true; 
			}
			if (Email.EndsWith (Characters [i])) {
				EW = true; 
			}
		}
		if (SW == true && EW == true) {
			EmailValid = true;
		} else {
			EmailValid = true;
		}
	}
}

