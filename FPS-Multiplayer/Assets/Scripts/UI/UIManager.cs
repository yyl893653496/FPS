using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CanvasGroup MenuItemCanvasGroup;
    public Button PlayButton;
    public Button CreateGameButton;
    public Button JoinGameButton;
    public Button SettingButton;


    [Space] public Animator CreateGamePanelAnimator;
    public Button CancelToCreateGameButton;
    public Button ConfirmToCreateGameButton;

    public InputField RoomName;
    public InputField RoomPsw;
    public Dropdown MaxPlayer;
    public string MapName;


    [Space] public Animator JoinGamePanelAnimator;
    public Button CancelJoinToCreateGameButton;
    public Button JoinToCreateGameButton;

    public Launcher Launcher;

    private void Start()
    {
        CreateGameButton.onClick.AddListener(() =>
        {
            CreateGamePanelAnimator.SetTrigger("FadeIn");
            MenuItemCanvasGroup.interactable = false;
        });

        CancelToCreateGameButton.onClick.AddListener(() =>
        {
            CreateGamePanelAnimator.SetTrigger("FadeOut");
            MenuItemCanvasGroup.interactable = true;
        });


        JoinGameButton.onClick.AddListener(() =>
        {
            JoinGamePanelAnimator.SetTrigger("FadeIn");
            MenuItemCanvasGroup.interactable = false;
        });


        CancelJoinToCreateGameButton.onClick.AddListener(() =>
        {
            JoinGamePanelAnimator.SetTrigger("FadeOut");
            MenuItemCanvasGroup.interactable = true;
        });


        ConfirmToCreateGameButton.onClick.AddListener(() =>
        {
            Launcher.CreateRoom(RoomName.text, (byte) (MaxPlayer.value), int.Parse(RoomPsw.text), MapName);
        });
    }
}