using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    [SerializeField] private Button[] moveInputButtons = new Button[4];
    [SerializeField] private Sprite[] moveGraphics = new Sprite[4];
    [SerializeField] private GameObject playerShip;

    private Player _player;
    private int[] _counter = new int[4];
    private MoveToken[] _moveTokens = new MoveToken[4];

    void Awake()
    {
        _player = playerShip.GetComponent<Player>();

        foreach (var btn in moveInputButtons)
        {
            btn.onClick.AddListener(() => MoveInputCycle(Array.FindIndex(moveInputButtons, b => b == btn)));
        }
    }

    void Update()
    {

    }

    public void MoveInputCycle(int index)
    {
        moveInputButtons[index].image.sprite = moveGraphics[_counter[index]];
        _counter[index]++;

        if (_counter[index] == 4)
            _counter[index] = 0;

        _moveTokens[index] = (MoveToken)_counter[index];
        _player.MoveTokens = _moveTokens;
    }

}
