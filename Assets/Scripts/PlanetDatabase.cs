using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;

// Helpful links about DBNull check
// https://www.codegrepper.com/code-examples/csharp/how+to+handle+when+sqlite+data+reader+get+null+values
// https://stackoverflow.com/questions/1772025/sql-data-reader-handling-null-column-values

public class PlanetDatabase : MonoBehaviour {
    public PlanetsList planetsList;
    public UserInterface userInterface;
    
    string dbName = null;
    IDbConnection dbConnection = null;
    string sqlQuery = null;
    IDbCommand dbCommand = null;
    IDataReader reader = null;

    void Awake() {
        if (planetsList == null) planetsList = this.GetComponent<PlanetsList>();
    }
    
    void Start() {
        planetsList.DeleteList();
        FetchAllPlanets();
        userInterface.DisplayPlanetAtIndex();
    }

    public void FetchAllPlanets() {
        OpenDatabase();
        ReadData();
        CloseDatabase();
    }

    private void OpenDatabase() {
        dbName = "URI=file:" + Application.dataPath + "/BasePlanetas.db";
        dbConnection = (IDbConnection) new SqliteConnection(dbName);
        dbConnection.Open();
        Debug.Log("Database connection is open");

        dbCommand = dbConnection.CreateCommand();
        sqlQuery = "SELECT * FROM Planetas";
        dbCommand.CommandText = sqlQuery;
    }

    private void ReadData() {
        reader = dbCommand.ExecuteReader();
        while (reader.Read()) {
            int id = reader.GetInt32(0);
            string planet = SafeGetString(1);
            string region = SafeGetString(2);
            string climate = SafeGetString(3);
            string gravity = SafeGetString(4);
            string moons = SafeGetString(5);
            string day = SafeGetString(6);
            string year = SafeGetString(7);
            string natives = SafeGetString(8);
            string government = SafeGetString(9);
            string capital = SafeGetString(10);
            string market = SafeGetString(11);
            string facilities = SafeGetString(12);

            // Making a new Planet and adding to my local list;
            Planet currentPlanet = new Planet(id, planet, region, climate, gravity, moons, day, year, natives, government, capital, market, facilities);
            Debug.Log("Current Planet number: " + currentPlanet.id);

            planetsList.AddPlanet(currentPlanet);
        }
    }

    private void CloseDatabase() {
        reader.Close();
        reader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConnection.Close();
        dbConnection = null;
        Debug.Log("Database connection is closed");
    }

    public string SafeGetString(int columnIndex) {
        bool nullField = reader.IsDBNull(columnIndex);
        var data = string.Empty;

        data = nullField ? "None" : reader.GetString(columnIndex);

        return data;
    }

    // Delete data from the list
    void OnApplicationQuit() {
        planetsList.DeleteList();
    }
}
