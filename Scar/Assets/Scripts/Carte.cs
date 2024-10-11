using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carte : MonoBehaviour
{
    public string rarity;
    public string type;
    [SerializeField] private Image carte;
    [SerializeField] private Sprite rarityNormal;
    [SerializeField] private Sprite rarityRare;
    [SerializeField] private Sprite rarityEpic;
    
    //* Permet de changer l'image de la carte en fonction de sa rareté *//
    public void ImageByRarity(string rar) {
        if(rar == "normal") {
            carte.sprite = rarityNormal;
        } else if(rar == "rare") {
            carte.sprite = rarityRare;
        } else if(rar == "epic") {
            carte.sprite = rarityEpic;
        }
    }

}
