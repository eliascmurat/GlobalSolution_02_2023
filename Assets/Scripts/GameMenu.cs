using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public Button btnPlay;
    public Text txtNomeLevel;

    public GameObject infoLevel;
    public Text txtInfoLevel;
    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    public string[] nomeLevel;
    private int idLevel;

    public int numeroPerguntas = 6;
    
    void Start()
    {
        idLevel = 0;
        txtNomeLevel.text = nomeLevel[idLevel];
        infoLevel.SetActive(false);
        txtInfoLevel.text = "";
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);
        btnPlay.interactable = false;
    }

    public void SelectLevel(int idLevelSelected)
    {
        idLevel = idLevelSelected;
        PlayerPrefs.SetInt("idLevel", idLevel);
        
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);
        
        txtNomeLevel.text = nomeLevel[idLevelSelected];
        infoLevel.SetActive(true);
        
        int notaFinal = PlayerPrefs.GetInt("notaFinal" + idLevel);
        int acertos = PlayerPrefs.GetInt("acertos" + idLevel);
        
        if (notaFinal >= 9)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        }
        else if (notaFinal >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (notaFinal >= 4)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }
        
        txtInfoLevel.text = "Você acertou " + acertos + " de " + numeroPerguntas + " perguntas";
        btnPlay.interactable = true;
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene("T" + idLevel);
    }
}
