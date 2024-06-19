using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;
using UnityEngine.Networking;

public class GameStart : MonoBehaviour
{
    private string URL = "http://127.0.0.1:5000";
    [SerializeField] private TextMeshProUGUI _scoreText;

    [Inject]
    public void Construct(ScoreHandler scoreHandler)
    {
        int score = scoreHandler.playerScore;
        
        if (score != 0) _scoreText.text = "Your best score is " + scoreHandler.playerScore;
    }

    // Начинаем игру
    public void StartGame()
    {
        Debug.Log("Игра начинается!");
    }

    IEnumerator GetJSON()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            
            if (request.result == UnityWebRequest.Result.ConnectionError) Debug.LogError(request.error);
            else
            {
                string json = request.downloadHandler.text;
                SimpleJSON.JSONNode stat = SimpleJSON.JSON.Parse(json);
                
                Debug.Log(stat["1"]);
            }
        }
    }
}