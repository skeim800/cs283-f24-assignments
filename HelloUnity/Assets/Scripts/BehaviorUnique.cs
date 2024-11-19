using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTAI;
using TMPro;

public class BehaviorUnique : MonoBehaviour
{
    private Root m_btRoot = BT.Root();
    public Transform player;
    public float mageRange = 5.0f;
    public TextMeshProUGUI mageText;
    private bool hasAppeared;

    // Start is called before the first frame update
    void Start()
    {

        m_btRoot.OpenBranch(
        BT.Selector().OpenBranch(
                BT.If(InMageRange).OpenBranch(
                    BT.Call(Appear)
                ),
                BT.Call(Disappear)
            )
        );
    }

    // Update is called once per frame
    void Update()
    {
        m_btRoot.Tick();
    }

    private bool InMageRange()
    {
        return Vector3.Distance(transform.position, player.position) < mageRange;
    }

    private bool Appeared()
    {
        return hasAppeared;
    }

    private void Appear()
    {
        hasAppeared = true;
        transform.GetChild(0).gameObject.SetActive(true);
        ShowMessage();
    }

    private void ShowMessage()
    {
        mageText.gameObject.SetActive(true);
        mageText.text = "Potatoes are the foundation of any great meal! Mashed potatoes, " +
            "french fries, tater tots, potato wedges, smashed potatoes...Sorry sorry. Ahem. Get to the top of the " +
            "mountain and collect as many potatoes as you can without getting mauled by the Big Rat. " +
            "Congratulations, you're a potato farmer now.";
    }

    private void Disappear()
    {
        hasAppeared = false;
        transform.GetChild(0).gameObject.SetActive(false);
        mageText.gameObject.SetActive(false);
    }
}
