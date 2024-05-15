using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

// force the requirement of a component of type : Rigidbody
[RequireComponent (typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    public Transform[] diceFaces;
    public Rigidbody rb;

    public UI ui;

    // TODO : material management

    private int _diceIndex = -1;

    private bool _hasStoppedRolling = false;
    private bool _delayFinished = false;

    public static UnityAction<int, int> OnDiceResult;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ui = FindObjectOfType<UI>();
    }

    private void Start()
    {
        transform.rotation = Random.rotation;
    }

    private void Update()
    {
        if (!_delayFinished) return;

        if (!_hasStoppedRolling && rb.velocity.sqrMagnitude == 0f)
        {
            _hasStoppedRolling = true;
            GetNuberOnTopFace();
        }
    }

    [ContextMenu("Get Top Face")]
    private int GetNuberOnTopFace()
    {
        if (diceFaces == null) return -1;

        int topFace = 0;
        float lastYPosition = diceFaces[0].position.y;

        for (int i = 0; i < diceFaces.Length; i++)
        {
            if (diceFaces[i].position.y > lastYPosition)
            {
                lastYPosition = diceFaces[i].position.y;
                topFace = i;
            }
        }

        ui.SetDiceValue(_diceIndex, topFace + 1);

        OnDiceResult?.Invoke(_diceIndex, topFace + 1);
        return topFace + 1;
    }

    public void RollDice(float throwForce, float rollForce, int i, Vector3 throwDirection)
    {
        _diceIndex = i;
        float randomVariance = Random.Range(0.25f, 1f);
        rb.AddForce(throwDirection * (throwForce * randomVariance), ForceMode.Impulse);
        
        StartCoroutine(DelayResult());
    }

    private IEnumerator DelayResult()
    {
        yield return new WaitForSeconds(1);
        _delayFinished = true;
    }
}
