using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public string[] dicesValues = new string[4];

    public TextMeshProUGUI firstDiceText;
    public TextMeshProUGUI secondDiceText;
    public TextMeshProUGUI thirdDiceText;
    public TextMeshProUGUI fourthDiceText;

    public GameObject firstDiceObject;
    public GameObject secondDiceObject;
    public GameObject thirdDiceObject;
    public GameObject fourthDiceObject;

    public int dicesAmount = 1;

    private bool showValues = false;
    private bool diceLaunched = false;
    private Vector3 tempUIScale = new Vector3(0, 0, 0);
    private Vector3 maxUIScale = new Vector3(5, 5, 5);

    void Update()
    {
        if (diceLaunched)
        {
            switch (dicesAmount)
            {
                case 1:
                    if (dicesValues[0] != "")
                    {
                        firstDiceText.text = dicesValues[0];
                        ShowValues();
                        ResetValues();
                    }
                    break;
                case 2:
                    if (dicesValues[0] != "" && dicesValues[1] != "")
                    {
                        firstDiceText.text = dicesValues[0];
                        secondDiceText.text = dicesValues[0];
                        ShowValues();
                        ResetValues();
                    }
                    break;
                case 3:
                    if (dicesValues[0] != "" && dicesValues[1] != "" && dicesValues[2] != "")
                    {
                        firstDiceText.text = dicesValues[0];
                        secondDiceText.text = dicesValues[1];
                        thirdDiceText.text = dicesValues[2];
                        ShowValues();
                        ResetValues();
                    }
                    break;
                case 4:
                    if (dicesValues[0] != "" && dicesValues[1] != "" && dicesValues[2] != "" && dicesValues[3] != "")
                    {
                        firstDiceText.text = dicesValues[0];
                        secondDiceText.text = dicesValues[1];
                        thirdDiceText.text = dicesValues[2];
                        fourthDiceText.text = dicesValues[3];
                        ShowValues();
                        ResetValues();
                    }
                    break;
                default:
                    break;
            }

            
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            firstDiceObject.SetActive(false);
            secondDiceObject.SetActive(false);
            thirdDiceObject.SetActive(false);
            fourthDiceObject.SetActive(false);
        }

        if (tempUIScale.x >= maxUIScale.x)
        {
            tempUIScale = new Vector3(0, 0, 0);
            showValues = false;
        }

        if (showValues)
        {
            PopText();
        }

    }

    public void ResetValues()
    {
        for (int i = 0; i < dicesValues.Length; i++)
        {
            dicesValues[i] = "";
        }
        
        diceLaunched = false;
    }

    public void SetDiceValue(int diceIndex, int v)
    {
        diceLaunched = true;
        switch (diceIndex)
        {
            case 0:
                dicesValues[0] = v.ToString();
                break;
            case 1:
                dicesValues[1] = v.ToString();
                break;
            case 2:
                dicesValues[2] = v.ToString();
                break;
            case 3:
                dicesValues[3] = v.ToString();
                break;
        }
    }

    private void ShowValues()
    {
        switch (dicesAmount)
        {
            case 1:
                firstDiceObject.SetActive(true);
                break;
            case 2:
                firstDiceObject.SetActive(true);
                secondDiceObject.SetActive(true);
                break;
            case 3:
                firstDiceObject.SetActive(true);
                secondDiceObject.SetActive(true);
                thirdDiceObject.SetActive(true);
                break;
            case 4:
                firstDiceObject.SetActive(true);
                secondDiceObject.SetActive(true);
                thirdDiceObject.SetActive(true);
                fourthDiceObject.SetActive(true);
                break;
            default:
                break;
        }

        showValues = true;
    }

    public void PopText()
    {
        tempUIScale += new Vector3(0.1f, 0.1f, 0.1f);
        firstDiceObject.transform.localScale = tempUIScale;
        secondDiceObject.transform.localScale = tempUIScale;
        thirdDiceObject.transform.localScale = tempUIScale;
        fourthDiceObject.transform.localScale = tempUIScale;
    }
}
