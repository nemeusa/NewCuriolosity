using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimal : MonoBehaviour
{
    public GameObject Alien;
    public GameObject Rat;
    public GameObject Turtle;
    public GameObject Goat;
    public GameObject Monkey;
    public GameObject Bat;

    public AlienController AlienCode;
    public RatController RatCode;
    public TurtleController TurtleCode;
    public GoatController GoatCode;
    public GoatController MonkeyCode;
    public GoatController BatCode;

    public ParticleSystem changeParticle;

    [SerializeField] private PlayerAudio _playerAudio;

    public Dictionary<Creatures, CreatureController> creaturesDictionary = new();
    public CreatureController currentCreature;
    [SerializeField] KeyCode alienKey, ratKey, turtleKey, goatKey, monkeyKey, batKey;

    public PlayerMovement playerMovement;

    public LayerMask layerMask;

    public bool goatTrue;
    public bool ratTrue;
    public bool monkeyTrue;
    public bool batTrue;


    private void Start()
    {
        creaturesDictionary.Add(Creatures.Alien, new AlienController(this, Alien, 7.5f));
        creaturesDictionary.Add(Creatures.Rat, new RatController(this, Rat, 5.6f));
        creaturesDictionary.Add(Creatures.Turtle, new TurtleController(this, Turtle, 3.7f));
        creaturesDictionary.Add(Creatures.Goat, new GoatController(this, Goat, 6));
        creaturesDictionary.Add(Creatures.Monkey, new GoatController(this, Monkey, 6));
        creaturesDictionary.Add(Creatures.Bat, new GoatController(this, Bat, 7));

        currentCreature = creaturesDictionary[Creatures.Alien];
        currentCreature.OnChange();

    }

    private void Update()
    {
        ChangePlayer();

        currentCreature.OnUpdate();
    }

    private void FixedUpdate()
    {
        currentCreature.OnFixedUpdate();
    }

    private void ChangePlayer()
    {
        if (Input.GetKeyDown(alienKey) && currentCreature.CanChange())
        {
            ChangeToCreature(Creatures.Alien);
            _playerAudio.PlayAnimalClip(1);
            goatTrue = false;
            ratTrue = false;
            monkeyTrue = false;
            batTrue = false;
        }
        if (Input.GetKeyDown(ratKey) && currentCreature.CanChange())
        {
            ChangeToCreature(Creatures.Rat);
            _playerAudio.PlayAnimalClip(2);
            goatTrue = false;
            ratTrue = true;
            monkeyTrue = false;
            batTrue = false;
        }
        if (Input.GetKeyDown(turtleKey) && currentCreature.CanChange())
        {
            ChangeToCreature(Creatures.Turtle);
            _playerAudio.PlayAnimalClip(3);
            goatTrue = false;
            ratTrue = false;
            monkeyTrue = false;
            batTrue = false;
        }
        if (Input.GetKeyDown(goatKey) && currentCreature.CanChange())
        {
            ChangeToCreature(Creatures.Goat);
            _playerAudio.PlayAnimalClip(4);
            goatTrue = true;
            ratTrue = false;
            monkeyTrue = false;
            batTrue = false;
        } 
        if (Input.GetKeyDown(monkeyKey) && currentCreature.CanChange())
        {
            ChangeToCreature(Creatures.Monkey);
            //_playerAudio.PlayAnimalClip(4);
            goatTrue = false;
            ratTrue = false;
            monkeyTrue = true;
            batTrue = false;
        }
        if (Input.GetKeyDown(batKey) && currentCreature.CanChange())
        {
            ChangeToCreature(Creatures.Bat);
            //_playerAudio.PlayAnimalClip(4);
            goatTrue = false;
            ratTrue = false;
            monkeyTrue = false;
            batTrue = true;
        }
    }

    private void ChangeToCreature(Creatures creatureToChange)
    {
        if (!currentCreature.CanChange() || currentCreature == creaturesDictionary[creatureToChange])
        {
            return;
        }

        changeParticle.Play();
        _playerAudio.PlayTransClip();
        currentCreature.OnDisable();
        currentCreature = creaturesDictionary[creatureToChange];
        currentCreature.OnChange();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentCreature.OnTriggerEnter(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentCreature.OnCollisionEnter(collision);
    }

    private void OnCollisionStay(Collision other)
    {
        currentCreature.OnCollisionStay(other);
    }

    public void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }

}

public enum Creatures
{
    Alien, 
    Rat,
    Turtle,
    Goat,
    Monkey,
    Bat
}