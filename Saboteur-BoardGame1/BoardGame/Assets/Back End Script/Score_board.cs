using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_boad : MonoBehaviour
{
    public GameObject PlayerInfoPreb;
    public GameObject RoundStatPreb;

    public void LoadScoreBoard()
    {

        foreach(GameObject player in GameManager.Instance.Players)
        {
            PlayerController PlayerS = player.GetComponent<PlayerController>();
            GameObject PlayerInfoHolder = Instantiate(PlayerInfoPrefab) as GameObject;
            Player_info_control pic = PlayerInfoHolder.GetComponent<Player_info_control>();
            pic.Row_number();
            pic.Player_name(PlayerS.playerName);
            pic.Total_Gold(PlayerS.getTotalPoint());
            PlayerInfoHolder.transform.setParent(this.gameObject.transform);
            for(int i = 0; i < PlayerS.GetPoints().count; i++)
            {
                GameObject pointholder = Instantiate(RoundStatPreb) as GameObject;
                Round_start_control rsc = pointholder.GetComponent<Round_start_control>();
                rsc.setPoint(PlayerS.getPoint(i));
                rsc.setRole(PlayerS.getRoleIndex(i));
                pointholder.transform.setParent(PlayerInfoHolder.transform);
            }

        }
    }
}
