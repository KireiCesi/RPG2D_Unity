using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMotor : MonoBehaviour
{
    private InputsManager inputs;

    private Animator anim;

    private GameManager manager;

    private Vector2 velocity = Vector2.zero;

    private int direction = 0;

    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.GetInstance();
        inputs = InputsManager.instance;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 _moveValue = inputs.GetMovingInputs().normalized;
        _moveValue = ChooseDirection(_moveValue);

        velocity = _moveValue * speed;

        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime, 0);

        //Animation
        anim.SetInteger("direction", direction);
        Debug.Log("Direction set to: " + direction);


    }

    private Vector2 ChooseDirection(Vector2 _value)
    {
        Vector2 _result = Mathf.Abs(_value.x) >= Mathf.Abs(_value.y) ? new Vector2(_value.x, 0) : new Vector2(0, _value.y);


       direction =  SetDirection(_result);
        return _result;
    }

    private int SetDirection(Vector2 _vector)
    {
        if (_vector.x > 0)
        {
            return 6;
        }
        if (_vector.x < 0)
        {
            return 4;
        }

        if (_vector.y > 0)
        {
            return 8;
        }

        if (_vector.y < 0)

        {
            return 2;
        }

        return 0;
    }
}
