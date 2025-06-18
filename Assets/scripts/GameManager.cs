using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> checkpoints;
    public int nextcheckpointindex = 0;
    public int completedcircles = 0;
    public TextMeshProUGUI textcircles;
    public GameObject winscreen;

    void Start()
    {
        UpdataUI();
        Time.timeScale = 1f;
        winscreen.gameObject.SetActive(false);
    }
    void Update()
    {
        
    }
    public void CheckpointTouched(GameObject checkpointblock)
    {
        if (checkpoints[nextcheckpointindex] == checkpointblock)
        {
            checkpointblock.GetComponent<Renderer>().material.color = new Color32(0, 255, 0, 32);
            nextcheckpointindex++;
            Debug.Log(nextcheckpointindex);
        }
    }

    public void FinishTouched (GameObject finishblock )
    {
        Debug.Log("мы коснулись финиша");
        if (nextcheckpointindex == checkpoints.Count)
        {
            finishblock.GetComponent<Renderer>().material.color = new Color32(0, 255, 0, 32);
            completedcircles++;
            UpdataUI();
            StartCoroutine(Timer(1f, finishblock));
            if (completedcircles == 3)
            {
                Time.timeScale = 0f;
                winscreen.gameObject.SetActive(true);
            }
        }
    }
    private void ResetCheckpoints(GameObject finishblock)
    {
        foreach (GameObject checkpoint in checkpoints) {

            checkpoint.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 32);
        }
           finishblock .GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 32);
        nextcheckpointindex = 0;
    }

    IEnumerator Timer (float time , GameObject finishblock )
    {
        yield return new WaitForSeconds(time);
        ResetCheckpoints(finishblock);
    }
    void UpdataUI ()
    {
        textcircles.text = "Circles: " + completedcircles.ToString();
    }

    public void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame ()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
