using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Prefabs.Locomotion.Teleporters;
using Zinnia.Data.Type;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuLogic : MonoBehaviour
{
    //用于做传送
    public TeleporterFacade teleporter;
    //传送功能移动的区域
    public Transform playArea;
    //用于获取头部的Transform信息做offset用
    public Transform headOrientation;
    //当Pause按钮按下时，玩家会被传送到这里
    public Transform pauseLocation;
    //当玩家继续游戏时会被传送去的地方
    public Transform gameLocation;

    //用于跟踪目前游戏状态是否为暂停。默认状态为false
    protected bool inPauseMenu = false;

    //用于保存暂停状态下需要启用的GameObject
    public List<GameObject> pauseItems;
    //用于保存游戏运行状态下需要启用的GameObject
    public List<GameObject> gameItems;

    public GameObject teleportationRelease;
    public GameObject teleportationPress;

    //用于在暂停或者继续游戏时切换房间用
    public void SwitchRooms() {
        TransformData teleportDestination = new TransformData(gameLocation);
        if (!inPauseMenu) {
            //把头部的位置信息考虑进去
            gameLocation.position = new Vector3(headOrientation.position.x, playArea.position.y, headOrientation.position.z);

            Vector3 right = Vector3.Cross(playArea.up, headOrientation.forward);
            Vector3 forward = Vector3.Cross(right, playArea.up);

            gameLocation.rotation = Quaternion.LookRotation(forward, playArea.up);

            teleportDestination = new TransformData(pauseLocation);
        }

        teleporter.Teleport(teleportDestination);
        inPauseMenu = !inPauseMenu;

        foreach (GameObject item in pauseItems) {
            item.SetActive(inPauseMenu);
        }

        foreach (GameObject item in gameItems) {
            item.SetActive(!inPauseMenu);
        }
    }

    public void ResetGame() {
        SceneManager.LoadScene("Final", LoadSceneMode.Single);
    }

    public void SwitchTeleportationToPress(bool value) {
        teleportationRelease.SetActive(!value);
        teleportationPress.SetActive(value);
    }

    public void SwitchTeleportationToRelease(bool value) {
        SwitchTeleportationToPress(!value);
    }
}
