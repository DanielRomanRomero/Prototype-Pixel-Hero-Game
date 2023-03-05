using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private bool isHeart, isCoinSpin, isCoinShine;
    private SpriteRenderer SR;
    private Transform pos;
    private bool isCatched;

    private Vector3 startValue, endValue;
    [SerializeField] private float duration;
    private float elapsedTime, intervalTime;
    private Color startAlpha, endAlpha;

    private ItemsManager itemsManagerScript;
    private UIManager UiManagerScript;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        pos = GetComponent<Transform>();
        startValue = pos.position;
        endValue = new Vector3(pos.position.x, pos.position.y + 2, 0f);
        startAlpha = new Color(1f, 1f, 1f, 1f);
        endAlpha = new Color(1f, 1f, 1f, 0f);
        isCatched = false;
    }
    private void Start()
    {
        itemsManagerScript = GameObject.Find("ItemsManager").GetComponent<ItemsManager>();
        UiManagerScript = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void Update()
    {
        if (isCatched)
            PlayerTouched();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCatched = true;
            GetComponent<CircleCollider2D>().enabled = false;

            if (isHeart)
            {
                itemsManagerScript.PickHeartAmount++;
                UiManagerScript.HeartsPending--;
            }
            else if (isCoinSpin)
            {
                itemsManagerScript.CoinSpinAmount++;
                UiManagerScript.CoinsSpinPending--;
            }
            else if (isCoinShine)
            {
                itemsManagerScript.CoinShineAmount++;
                UiManagerScript.CoinsShinePending--;
            }

            itemsManagerScript.ManagingAmounts();
        } 
    }

    private void PlayerTouched()
    {
        elapsedTime += Time.deltaTime;
        intervalTime = elapsedTime / duration;
        pos.position = Vector3.Lerp(startValue, endValue, intervalTime);
        SR.color = Color.Lerp(startAlpha, endAlpha, intervalTime);
    }
}
