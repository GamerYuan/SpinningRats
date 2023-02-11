using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public string[] sentences;

    public void setName(string name)
    {
        this.name = name;
    }

    public void setSentences(string[] sentences)
    {
        this.sentences = sentences;
    }

    public string getName()
    {
        return name;
    }

    public string[] getSentences()
    {
        return sentences;
    }
}
