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
            BT.Sequence().OpenBranch(
                BT.If(InMageRange).OpenBranch(
                    BT.Call(Appear)
                ),
                BT.If(Appeared).OpenBranch(
                    BT.Call(ShowMessage)
                )
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
        gameObject.SetActive(true);
    }

    private void ShowMessage()
    {
        mageText.gameObject.SetActive(true);
        mageText.text = "Collect as many potatoes as you can without getting mauled by the Big Rat. Potatoes are the foundation of any great meal. Mashed potatoes, french fries, tater tots, wedges, smashed potatoes...";
    }

    private void Disappear()
    {
        hasAppeared = false;
        gameObject.SetActive(false);
        mageText.gameObject.SetActive(false);
    }
}
