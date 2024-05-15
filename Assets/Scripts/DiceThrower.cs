using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DiceThrower : MonoBehaviour
{
    [Header("Dice Prefabs")]
    [SerializeField] private Dice d4;
    [SerializeField] private Dice d6;
    [SerializeField] private Dice d8;
    [SerializeField] private Dice d10;
    [SerializeField] private Dice d12;
    [SerializeField] private Dice d20;

    [Header("Settings")]
    public Dice diceToThrow;
    public int amountOfDice = 2;
    public float throwForce = 10f;
    public float rollForce = 10f;
    public Vector3 throwDirection;

    // TODO : material management
    // the dice must have a list of his materials.

    private List<GameObject> _spawnedDice = new List<GameObject>();

    public void Awake()
    {
        throwDirection = transform.forward;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) RollDice();
    }

    public void SetDiceAndAmount(int selectedDice, int amount)
    {
        switch(selectedDice)
        {
            case 0:
                diceToThrow = d4;
                break;
            case 1:
                diceToThrow = d6;
                break;
            case 2:
                diceToThrow = d8;
                break;
            case 3:
                diceToThrow = d10;
                break;
            case 4:
                diceToThrow = d12;
                break;
            case 5:
                diceToThrow = d20;
                break;
        }
        amountOfDice = amount;
    }
    private async void RollDice()
    {
        if (diceToThrow == null) return;

        foreach (var die in _spawnedDice)
        {
            Destroy(die);
        }

        for (int i = 0; i < amountOfDice; i++)
        {
            Dice dice = Instantiate(diceToThrow, transform.position, transform.rotation);
            _spawnedDice.Add(dice.gameObject);
            dice.RollDice(throwForce, rollForce, i, throwDirection);
            await Task.Yield();
        }
    }
}
