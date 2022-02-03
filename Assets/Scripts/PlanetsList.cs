using System.Collections.Generic;
using UnityEngine;

public class PlanetsList : MonoBehaviour {
    public List<Planet> planetsList = new List<Planet>();

    public void AddPlanet(Planet planet) {
        planetsList.Add(planet);
        Debug.LogError("Planets List count: " + planetsList.Count);
        Debug.Log("Added Planet -> " + "ID: " + planet.id +
                "; Name: " + planet.name +
                "; Region: " + planet.region +
                "; Climate: " + planet.climate +
                "; Gravity: " + planet.gravity +
                "; Moons: " + planet.moons +
                "; Day: " + planet.day +
                "; Year: " + planet.year +
                "; Natives: " + planet.natives +
                "; Government: " + planet.government +
                "; Capital: " + planet.capital +
                "; Market: " + planet.market +
                "; Facilities: " + planet.facilities);
    }

    public void DeleteList() {
        planetsList.Clear();
    }
}
