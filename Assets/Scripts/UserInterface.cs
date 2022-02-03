using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterface : MonoBehaviour {
    public PlanetsList planetsList;

    [SerializeField] private TMP_Text planetID,
    planetName,
    planetRegion,
    planetClimate,
    planetGravity,
    planetMoons,
    planetDay,
    planetYear,
    planetNatives,
    planetGovernment,
    planetCapital,
    planetMarket,
    planetFacilities,
    updateMessage;

    [SerializeField] private TMP_Text planetsCount;
    
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text searchByIDText;
    [SerializeField] private TMP_Text placeholderText;

    [SerializeField] private int planetIndex = 0;
    [SerializeField] private int id = 1;

    [SerializeField] private int maxPlanetsCount => planetsList.planetsList.Count;

    [SerializeField] private Color updateMessageSuccessfulLoadingColor;
    [SerializeField] private Color updateMessageErrorColor;
    [SerializeField] private Color updateMessageEditIDColor;
    [SerializeField] private Color updateMessageOthersColor;
    
    public void DisplayPlanetAtIndex(int n = 0) {
        planetID.text = planetsList.planetsList[n].id.ToString();
        planetName.text = planetsList.planetsList[n].name;
        planetRegion.text = planetsList.planetsList[n].region;
        planetClimate.text = planetsList.planetsList[n].climate;
        planetGravity.text = planetsList.planetsList[n].gravity;
        planetMoons.text = planetsList.planetsList[n].moons;
        planetDay.text = planetsList.planetsList[n].day;
        planetYear.text = planetsList.planetsList[n].year;
        planetNatives.text = planetsList.planetsList[n].natives;
        planetGovernment.text = planetsList.planetsList[n].government;
        planetCapital.text = planetsList.planetsList[n].capital;
        planetMarket.text = planetsList.planetsList[n].market;
        planetFacilities.text = planetsList.planetsList[n].facilities;

        if (planetsCount.text != maxPlanetsCount.ToString())
            planetsCount.text = maxPlanetsCount.ToString();
    }
    
    public void PreviousPlanet() {
        planetIndex--;
        id = planetIndex + 1;
        if (planetIndex < 0) {
            planetIndex = maxPlanetsCount - 1;
            id = maxPlanetsCount;
        }
        DisplayPlanetAtIndex(planetIndex);
        updateMessage.text = ("Displaying previous Planet.");
        updateMessage.color = updateMessageOthersColor;
    }

    public void NextPlanet() {
        planetIndex++;
        id = planetIndex + 1;
        if (maxPlanetsCount <= planetIndex) {
            planetIndex = 0;
            id = 1;
        }
        DisplayPlanetAtIndex(planetIndex);
        updateMessage.text = ("Displaying next Planet.");
        updateMessage.color = updateMessageOthersColor;
    }

    public void RandomPlanet() {
        planetIndex = Random.Range(0, maxPlanetsCount);
        id = planetIndex + 1;
        DisplayPlanetAtIndex(planetIndex);
        updateMessage.text = ("Displaying random Planet.");
        updateMessage.color = updateMessageOthersColor;
    }

    public void EnterID() {
        id = planetIndex;
        planetIndex = id;

        bool converted;
        converted = checkParse(inputField.text);
        
        if (converted) {
            if (id < System.Int32.MinValue || System.Int32.MaxValue < id) {
                updateMessage.text = ("Input ID has overflowed. Please, use a number lesser than " + System.Int32.MinValue + " and greater than " + System.Int32.MaxValue + ").");
                updateMessage.color = updateMessageErrorColor;
            }
            else if (maxPlanetsCount < id || id <= 0) {
                updateMessage.text = ("Input ID was successfully converted. However, the ID is non existent. Try with a value between 1 and " + maxPlanetsCount + ".");
                updateMessage.color = updateMessageErrorColor;
            }
            else {
                planetIndex = id - 1;
                DisplayPlanetAtIndex(planetIndex);
                updateMessage.text = ("The corresponding planet was successfully displayed.");
                updateMessage.color = updateMessageSuccessfulLoadingColor;
            }
        }
        else {
            updateMessage.text = ("Input ID was not an integer. Please, change the format of the text.");
            updateMessage.color = updateMessageErrorColor;
        }
    }

    public void HidePlaceholderText() {
        inputField.text = string.Empty;
        placeholderText.text = string.Empty;

        updateMessage.text = ("Insert Planet ID...");
        updateMessage.color = updateMessageEditIDColor;
    }

    public void ResetPlaceholderText() {
        inputField.restoreOriginalTextOnEscape = true;
        inputField.resetOnDeActivation = true;
        inputField.text = "Enter ID...";
        searchByIDText.text = string.Empty;
    }

    public bool checkParse(string inputString) {
        bool converted = false;
        
        try {
            id = System.Int32.Parse(inputString);
            converted = true;
        }
        catch (System.FormatException) {
            updateMessage.text = ("Input ID was not an integer. Please, change the format of the text.");
            updateMessage.color = updateMessageErrorColor;
        }
        catch (System.ArgumentNullException) {
            updateMessage.text = ("Input ID was null. Please, write an integer value.");
            updateMessage.color = updateMessageErrorColor;
        }
        
        return converted;
    }
}                                      
