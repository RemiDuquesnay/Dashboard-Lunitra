using UnityEngine;
using TMPro;
using System.Collections;

public class UI : MonoBehaviour
{
    public string firstDiceValue = "";
    public string secondDiceValue = "";

    public TextMeshProUGUI firstDiceText;
    public TextMeshProUGUI secondDiceText;

    public GameObject firstDiceObject;
    public GameObject secondDiceObject;

    private bool showValues = false;
    private Vector3 tempUIScale = new Vector3(0, 0, 0);
    private Vector3 maxUIScale = new Vector3(5, 5, 5);

    // Update is called once per frame
    void Update()
    {
        if (firstDiceValue != "" && secondDiceValue != "")
        {
            firstDiceText.text = firstDiceValue;
            secondDiceText.text = secondDiceValue;
            firstDiceValue = "";
            secondDiceValue = "";
            ShowValues();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            firstDiceObject.SetActive(false);
            secondDiceObject.SetActive(false);
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

    internal void SetDiceValue(int diceIndex, int v)
    {
        if (diceIndex == 0)
        {
            firstDiceValue = v.ToString();
        }
        else
        {
            secondDiceValue = v.ToString();
        }
    }

    private void ShowValues()
    {
        firstDiceObject.transform.localScale = new Vector3(0, 0, 0);
        firstDiceObject.transform.localScale = new Vector3(0, 0, 0);

        firstDiceObject.SetActive(true);
        secondDiceObject.SetActive(true);

        showValues = true;
    }

    public void PopText()
    {
        tempUIScale += new Vector3(0.1f, 0.1f, 0.1f);
        firstDiceObject.transform.localScale = tempUIScale;
        secondDiceObject.transform.localScale = tempUIScale;
    }
}
