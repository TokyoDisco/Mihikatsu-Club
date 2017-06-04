using UnityEngine;
using System.Collections;

using System.Collections.Generic;

[System.Serializable]
public class SkillList : MonoBehaviour {
    public List<Skill> listofskills = new List<Skill>();
    public List<Skill> listofAllSkils = new List<Skill>();
    public List<Skill> listofTrinketsSkills = new List<Skill>();

    public void Start()
    {
        ///list of all in-game skills//
        listofAllSkils.Add(new Skill("Healing Powder", "Thorw a healing powder to restore small amount of HP!", "Heal", "Earth", 10, 20, 1));
        listofAllSkils.Add(new Skill("Fireball", "Most commonly used spell in Pyromancy. Blast enemy with sphere made of fire", "Damage", "Fire", 30, 200, 2));
        listofAllSkils.Add(new Skill("Moonlight Stream", "In Hydromancy spell which allows user to regerated portion of lost mana", "Mana", "Water", 0, 200, 3));
        listofAllSkils.Add(new Skill("Dance of Wind", "Echanted Wind comes with music of storm. Unleashed upon enemies cause massive dmg", "Damage","Air", 100, 350, 4));
        listofAllSkils.Add(new Skill("Greater Fireball", "Powerfull spell that cause heave burning", "Damage", "Fire", 60, 250, 5));
        listofAllSkils.Add(new Skill("Landslide", "Causing earth to tremble upon feared enemies", "Damage", "Earth", 100, 135, 6));
        listofAllSkils.Add(new Skill("Fire Dancers", "Regenarate health of pyromancers", "Heal", "Fire", 50, 300, 7));
        listofAllSkils.Add(new Skill("Water Lance", "Hydromance most common offensive spell", "Damage", "Water", 20, 100, 8));
        listofAllSkils.Add(new Skill("Mad Man Dinner", "Whispering to ears of enemies, causing them to hurt them self paranoia causing hp to recover", "Damage", "Water", 120, 200, 9));
        listofAllSkils.Add(new Skill("Strangling Roots", "Hold enemy in place and crush his bones", "Damage", "Earth", 40, 180, 10));
        listofAllSkils.Add(new Skill("Haku", "Monsterious Plant living in class now fighting on our side", "Summon", "Earth", 150, 50, 11));
        listofAllSkils.Add(new Skill("Morning Wave", "Morning water of ocean strikes enemies", "Damage", "Water", 50, 150, 12));
        listofAllSkils.Add(new Skill("Fading Embers", "At the end of their life embers strikes, taking what left of flames", "Damage", "Fire", 10, 30, 13));
        listofAllSkils.Add(new Skill("Leafs dash", "Stream of blade-sharp leafs striking enemies", "Damage", "Earth", 50, 50, 14));

        //list of all in-game trinkets effects//
        listofTrinketsSkills.Add(new Skill("Mystic Eye", "Its watching you", "Damage", "neutral", 0, 200, 001));

        //list of staring skills//

        listofskills.Add(listofAllSkils[2]);
        listofskills.Add(listofAllSkils[7]);
        // listofskills.Add(new Skill("Fireball", "Most commonly used spell in Pyromancy. Blast enemy with sphere made of fire", "Damage", 30, 200,2));
        // listofskills.Add(new Skill("Healing Powder", "Thorw a healing powder to restore small amount of HP!", "Heal", 10, 20,1));




    }
    








}
