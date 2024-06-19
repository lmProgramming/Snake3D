using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance;

    public Image deathImage;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDeathScreen()
    {
        deathImage.enabled = true;
    }
}
