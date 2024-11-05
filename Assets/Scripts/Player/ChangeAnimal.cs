using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimal : MonoBehaviour
{
    public GameObject Alien;
    public GameObject Rat;
    public GameObject Turtle;
    public GameObject Goat;

    public AlienController AlienCode;
    public RatController RatCode;
    public TurtleController TurtleCode;
    public GoatController GoatCode;

    public ParticleSystem changeParticle;

    [SerializeField] private PlayerAudio _playerAudio;

    private Dictionary<Creatures, CreatureController> creaturesDictionary = new();
    public CreatureController currentCreature;
    [SerializeField] KeyCode alienKey, ratKey, turtleKey, goatKey;

    public PlayerMovement playerMovement;

    public LayerMask layerMask;

    public bool goatTrue;
    public bool ratTrue;


    private void Start()
    {
        creaturesDictionary.Add(Creatures.Alien, new AlienController(this, Alien, 7.5f));
        creaturesDictionary.Add(Creatures.Rat, new RatController(this, Rat, 5.6f));
        creaturesDictionary.Add(Creatures.Turtle, new TurtleController(this, Turtle, 3.7f));
        creaturesDictionary.Add(Creatures.Goat, new GoatController(this, Goat, 6));

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
        if (Input.GetKeyDown(alienKey))
        {
            ChangeToCreature(Creatures.Alien);
            _playerAudio.PlayAnimalClip(1);
            goatTrue = false;
            ratTrue = false;
        }
        if (Input.GetKeyDown(ratKey))
        {
            ChangeToCreature(Creatures.Rat);
            _playerAudio.PlayAnimalClip(2);
            goatTrue = false;
            ratTrue = true;
        }
        if (Input.GetKeyDown(turtleKey))
        {
            ChangeToCreature(Creatures.Turtle);
            _playerAudio.PlayAnimalClip(3);
            goatTrue = false;
            ratTrue = false;
        }
        if (Input.GetKeyDown(goatKey))
        {
            ChangeToCreature(Creatures.Goat);
            _playerAudio.PlayAnimalClip(4);
            goatTrue = true;
            ratTrue = false;
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
    Goat
}