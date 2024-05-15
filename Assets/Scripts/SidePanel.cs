using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SidePanel : MonoBehaviour
{
    [SerializeField] private DiceThrower diceThrower;

    [SerializeField] private Button panelButton;
    [SerializeField] private Image buttonIcon;
    [SerializeField] private Sprite diceIcon;
    [SerializeField] private Sprite backIcon;

    [SerializeField] private UI ui;

    [SerializeField] private TMP_Dropdown diceSelection;
    [SerializeField] private TMP_Dropdown amountSelection;

    [SerializeField] private Animator animator;


    private bool _isPanelOpen;
    void Start()
    {
        animator = GetComponent<Animator>();
        _isPanelOpen = animator.GetBool("isOpen");
        buttonIcon.sprite = diceIcon;
    }

    public void TogglePanel()
    {
        if (_isPanelOpen)
        {
            animator.SetBool("isOpen", false);
            buttonIcon.sprite = diceIcon;
        }
        else
        {
            animator.SetBool("isOpen", true);
            buttonIcon.sprite = backIcon;
        }

        _isPanelOpen = !_isPanelOpen;
    }

    public void Validate()
    {
        int selectedDice = diceSelection.value;
        int amountOfDices = amountSelection.value + 1;

        diceThrower.SetDiceAndAmount(selectedDice, amountOfDices);
        ui.dicesAmount = amountOfDices;
        TogglePanel();
    }
}
