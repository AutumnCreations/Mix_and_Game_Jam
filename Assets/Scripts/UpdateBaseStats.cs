using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateBaseStats : MonoBehaviour
{

    [SerializeField] Base playerBase;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = ("Gold: " + playerBase.gold);
        healthText.text = ("Health: " + playerBase.health);
    }
}
