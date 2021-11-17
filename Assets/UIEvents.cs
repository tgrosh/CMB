using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public GameData gameData;
    public Canvas schoolChooser;
    public Canvas schoolRoster;
    public Canvas mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        schoolChooser.gameObject.SetActive(false);
        schoolRoster.gameObject.SetActive(false);

        mainMenu.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        GenerateGameData();
        ShowSchoolChooser();
    }

    public void GenerateGameData() {
        gameData.GenerateConferencesAndSchools();
    }

    public void ShowSchoolChooser() {
        schoolRoster.gameObject.SetActive(false);
        schoolChooser.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    public void ShowSchoolRoster() {
        schoolRoster.gameObject.SetActive(true);
        schoolChooser.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
    }

    public void SetSchool(School school) {
        gameData.SetCurrentSchool(school);
        ShowSchoolRoster();
    }
}
