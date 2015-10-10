using UnityEngine;
using System.Collections.Generic;

public class Wish : MonoBehaviour {
	public enum Realms
	{
		Nostalgia,
		Self,
		Revenge,
		Happiness,
		Progress,
		TrueLove,
		LENGTH
	}
	private static string[] realmNames = {
		"Nostalgia",
		"Self",
		"Revenge",
		"Happy",
		"Learning",
		"Love"
	};
	private string[][] realmWishes = 
	{
		nostalgiaWishes,
		selfWishes,
		revengeWishes,
		happyWishes,
		learningWishes,
		loveWishes
	};
	private static string[] nostalgiaWishes =
	{
		"I wish I were young again...",
		"I long for the old days...",
		"I miss my friends.  I want to see them again.",
		"I wish for my health back!",
		"I wish I had started a band instead of getting a job!",
		"I miss ma's cookin'...",
		"I wish I could see my high school sweetheart again...",
		"I wish to be remembered..."
	};
	private static string[] selfWishes =
	{
		"I wish to marry rich!",
		"I wish for a nice house with a nice kitchen!",
		"I wish for three more wishes!!!  Make that unlimited wishes!",
		"I wish to win the game on Friday.",
		"I wish I was better looking.",
		"I wish I had more meaning in life.",
		"I wish to be famous!",
		"I wish for that pair of golden shoes at the mall.",
		"I wish for a fast car.  A Bugatti Veyron!",
		"I wish to be popular, part of the in crowd!"
	};
	private static string[] revengeWishes =
	{
		"I wish she was never born!",
		"I wish he were dead!",
		"I wish my roommate would turn into a toad!",
		"I wish to get even!"
	};
	private static string[] happyWishes =
	{
		"I wish for world peace!",
		"I wish this day will never end!",
		"I wish to meet someone with a sense of humor, like my dad!",
		"I wish my parents were together again.",
		"I wish for a box of chocolates.",
		"I wish to spend more time with my family!!",
		"I really, really want a pet puppy!"
	};
	private static string[] learningWishes =
	{
		"I wish to learn a new language so I can travel the world!",
		"I wish I could sing or play an instrument!",
		"I wish I had a heart! No, a brain! Maybe courage?",
		"I wish to go to a great university!",
		"I wish to quit my job!",
		"I wish to inspire someone today.",
		"I wish I was better at math...",
		"I wish I were a better artist!",
		"I wish I were better with people!",
		"I want to go to space!"
	};
	private static string[] loveWishes = // must be two or more, final wish is end game wish
	{
		"I just don't want to be lonely anymore.",
		"I wish to meet someone tall, dark, handsome...someone who loves me!",
		"I wish for us to be Together Forever! (This seems familiar somehow...)"
	};
	public static string winWish = loveWishes[loveWishes.Length-1];
	public string secretText;
	public string type;

	// Use this for initialization
	void Start () {
		int realm = Random.Range(0, (int)Realms.LENGTH);
		type = realmNames[realm];
		string[] realmWishlist = realmWishes[realm];
		int wishIdx = Random.Range(0, realmWishlist.Length);
		if( PlayerController.preventFinalWish && realmWishlist == loveWishes && wishIdx == loveWishes.Length-1 )
		{
			wishIdx--;
		}
		secretText = realmWishlist[wishIdx];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
