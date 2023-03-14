using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    public Animal(string name, int id, GameObject animalImage) { m_name = name; m_id = id; m_animalImage = animalImage;}
    
    // Getters/Setters
    public string GetName(){ return m_name; }
    public int GetID(){ return m_id; }
    public GameObject GetImage(){ return m_animalImage; }

    public void SetName(string name) { m_name = name; }
    // void SetID(int id) { m_id = id; }
    public void SetImage(GameObject image) {m_animalImage = image;}

    private string m_name;
    private int m_id;
    private GameObject m_animalImage;
}
