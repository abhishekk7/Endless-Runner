using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public Text scoreText;
    public Image backgroundImg;
    private bool isShown = false;
    private float transition=0.0f;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isShown)
            return;
        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black,transition);
	}
    public void ToggleEndMenu(float score,float coin)
    {
        gameObject.SetActive(true);
        isShown = true;
        string scoreString = "Survival score: " + (int)score + "\nCoins collected: " + (int)coin + "\nCoin score(x 2): " + (int)coin * 2 + "\nTotal score: " + (int)(score + coin * 10f);
        scoreText.text = scoreString;//((int)score).ToString();

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
