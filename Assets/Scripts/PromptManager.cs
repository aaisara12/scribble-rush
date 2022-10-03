using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptManager : MonoBehaviour
{

    public string[] nouns=
    {
    "caterpillar",
    "napkin",
    "hamburger",
    "dog",
    "dragon",
    "gargoyle",
    "cucumber",
    "cup",
    "boot",
    "lunch",
    "salad",
    "bread",
    "dinosaur",
    "professor",
    "student",
    "cat",
    "bunny",
    "tree",
    "flower",
    "TV",
    "worm",
    "mole",
    "beetle ",
    "strawberry",
    "primordial ooze ",
    "game dev",
    "rock",
    "boba",
    "pizza",
    "lamp",
    "foot",
    "hand",
    "minion",
    "moon",
    "ramen",
    "salmon",
    };

    public string[] adjectives = 
    {
    "slow",
    "mysterious",
    "stressed",
    "brave",
    "friendly",
    "tough",
    "clever",
    "mystic",
    "loving",
    "calm",
    "optimistic",
    "gentle",
    "social",
    "bold",
    "dizzy",
    "dead",
    "fancy",
    "famous",
    "filthy",
    "clean",
    "elegant",
    "handsome",
    "healthy",
    "expensive",
    "mushy",
    "odd",
    "lucky",
    "lazy",
    "powerful",
    "repulsive",
    "super",
    "tame",
    "talented",
    "tasty",
    "wild",
    "witty",
    "unusual",
    "wicked",
    "tender",
    "tense",
    "terrible",
    "sore",
    "shiny",
    "dull",
    "selfish",
    "scary",
    "rich",
    "flirtatious",
    "shy",
    };


    public string noun(){
        return nouns[Random.Range(0,nouns.Length)];
    }
    string adjective(){
        return adjectives[Random.Range(0,adjectives.Length)];
    }

    public string addAdjective(string prompt){
        return adjective()+" "+prompt;
    }
}
