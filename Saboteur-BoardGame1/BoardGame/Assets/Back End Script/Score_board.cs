using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_board : MonoBehaviour
{
    public GameObject PlayerInfoPrefab;
    public GameObject RoundStatPreb;

    public void LoadScoreBoard()
    {
        int count = 0;
        foreach (GameObject player in GameManager.Instance.Players)
        {
            PlayerController PlayerS = player.GetComponent<PlayerController>();
            GameObject PlayerInfoHolder = Instantiate(PlayerInfoPrefab) as GameObject;
            Player_info_control pic = PlayerInfoHolder.GetComponent<Player_info_control>();
            pic.Row_number(count+1);
            pic.Player_name(PlayerS.playerName);
            pic.Total_Gold(PlayerS.getTotalPoint());
            PlayerInfoHolder.transform.SetParent(this.gameObject.transform);
            for (int i = 0; i < PlayerS.GetPoints().Count; i++)
            {
                GameObject pointholder = Instantiate(RoundStatPreb) as GameObject;
                Round_start_control rsc = pointholder.GetComponent<Round_start_control>();
                rsc.setPoint(PlayerS.getPoint(i));
                rsc.setRole(PlayerS.getRoleIndex(i));
                pointholder.transform.SetParent(PlayerInfoHolder.transform);
            }
            count++;
        }
    }
}
