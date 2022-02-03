using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;

public class DBTest : MonoBehaviour {
    void Start() {
        ReadDatabase();
    }

    void ReadDatabase() {
        string dbName = "URI=file:" + Application.dataPath + "/Databases/testdb.db"; // Path to database.
        IDbConnection dbConnection;
        dbConnection = (IDbConnection) new SqliteConnection(dbName);
        dbConnection.Open(); // Open connection to the database.
        Debug.Log("Se abrio la conexion");

        IDbCommand dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "SELECT * FROM user";
        dbCommand.CommandText = sqlQuery;
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read()) {
            // Assign each field to a variable of the same type, by its index in reader (use same name as the field)

            string username = reader.GetString(0);
            int pincode = reader.GetInt32(1);

            // Log each field like Debug.Log("FieldName1: " + -variable1- + "; FieldName2: " + -variable2 + ...);
            Debug.Log("Username: " + username + "; Pincode: " + pincode);
        }

        reader.Close();
        reader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
        Debug.Log("Se cerró la conexion");
    }
}
