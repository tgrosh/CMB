using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public GameData gameData;
    public Canvas schoolChooser;
    public Canvas schoolOverview;
    public Canvas schoolRoster;
    public Canvas mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        ClearScreens();

        mainMenu.gameObject.SetActive(true);
    }

    private void ClearScreens()
    {
        schoolChooser.gameObject.SetActive(false);
        schoolOverview.gameObject.SetActive(false);
        schoolRoster.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
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
        ClearScreens();
        schoolChooser.gameObject.SetActive(true);
    }

    public void ShowSchoolRoster() {
        ClearScreens();
        schoolRoster.gameObject.SetActive(true);
    }
    
    public void ShowSchoolOverview() {
        ClearScreens();
        schoolOverview.gameObject.SetActive(true);
    }

    public void SetSchool(School school) {
        gameData.SetCurrentSchool(school);
        ShowSchoolOverview();
    }
}
