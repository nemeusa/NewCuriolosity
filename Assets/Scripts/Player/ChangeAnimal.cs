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

    public bool alienTrue;
    public bool goatTrue;
    public bool ratTrue;
    public bool monkeyTrue;
    public bool cambiando;
    public static bool batTrue;
    public static bool batInto;
    public static bool alienInto;


    private void Start()
    {
        creaturesDictionary.Add(Creatures.Alien, new AlienController(this, Alien, 7.5f));
        creaturesDictionary.Add(Creatures.Rat, new RatController(this, Rat, 5.6f));
        creaturesDictionary.Add(Creatures.Turtle, new TurtleController(this, Turtle, 3.7f));
        creaturesDictionary.Add(Creatures.Goat, new GoatController(this, Goat, 6));
        creaturesDictionary.Add(Creatures.Monkey, new MonkeyController(this, Monkey, 6));
        creaturesDictionary.Add(Creatures.Bat, new BatController(this, Bat, 7));

        currentCreature = creaturesDictionary[Creatures.Alien];
        currentCreature.OnChange();

        alienTrue = true;

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
        if (Input.GetKeyDown(alienKey) && currentCreature.CanChange() && !batTrue || alienInto)
        {
            ChangeToCreature(Creatures.Alien);
            _playerAudio.PlayAnimalClip(1);
            alienTrue = true;
            goatTrue = false;
            ratTrue = false;
            monkeyTrue = false;
            batTrue = false;
            alienInto = false;
            cambiando = true;
        }
        if (Input.GetKeyDown(ratKey) && currentCreature.CanChange() && !batTrue)
        {
            ChangeToCreature(Creatures.Rat);
            _playerAudio.PlayAnimalClip(2);
            alienTrue = false;
            goatTrue = false;
            ratTrue = true;
            monkeyTrue = false;
            batTrue = false;
            cambiando = true;
        }
        if (Input.GetKeyDown(turtleKey) && currentCreature.CanChange() && !batTrue)
        {
            ChangeToCreature(Creatures.Turtle);
            _playerAudio.PlayAnimalClip(3);
            alienTrue = false;
            goatTrue = false;
            ratTrue = false;
            monkeyTrue = false;
            batTrue = false;
            cambiando = true;
        }
        if (Input.GetKeyDown(goatKey) && currentCreature.CanChange() && !batTrue && !PlayerMovement.takeWall && !DontGoat.dontGoat)
        {
            ChangeToCreature(Creatures.Goat);
            _playerAudio.PlayAnimalClip(4);
            alienTrue = false;
            goatTrue = true;
            ratTrue = false;
            monkeyTrue = false;
            batTrue = false;
            cambiando = true;
        } 
        if (Input.GetKeyDown(monkeyKey) && currentCreature.CanChange() && !batTrue)
        {
            ChangeToCreature(Creatures.Monkey);
            _playerAudio.PlayAnimalClip(5);
            alienTrue = false;
            goatTrue = false;
            ratTrue = false;
            monkeyTrue = true;
            batTrue = false;
            cambiando = true;
        }
        if (batTrue && currentCreature.CanChange() && batInto)
        {
            ChangeToCreature(Creatures.Bat);
            _playerAudio.PlayAnimalClip(6);
            alienTrue = false;
            goatTrue = false;
            ratTrue = false;
            monkeyTrue = false;
            batInto = false;
            cambiando = true;
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
    
    private void OnTriggerExit(Collider other)
    {
        currentCreature.OnTriggerExit(other);
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