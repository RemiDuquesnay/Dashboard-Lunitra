using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DiceThrower : MonoBehaviour
{
    public Dice diceToThrow;
    public int amountOfDice = 2;
    public float throwForce = 10f;
    public float rollForce = 10f;
    public Vector3 throwDirection;

    public bool Dice100;

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
