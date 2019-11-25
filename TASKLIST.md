## Task List

- [ ] start game screen / space - rules section
	- [ ] bubble machine - when game starts -> bubble pops out of it and can view sea world around you - and game starts (maybe move score / timer to above the bubble machine on the ground?)
- [ ] bubble
	- [ ] decreases in size overtime
	- [ ] initial size depends on initial height of hmd when game starts (matches height)
	- [ ] runs out you die. 
	- [ ] leave the bubble area you die
	- [ ] underwater animal enters bubble area, plays sound
	- [ ] underwater animal about to enter, surface of bubble near there changes color
	- [ ] underwater animal in bubbled area, have their own bubble around head --> they can breathe
	- [ ] sea creatures can enter in upper bubble area or ground. (dont see them til then in the bubble)
- [ ] win/lose
	- [ ] enough points, win
	- [ ] bubble closes before enough points, you die
- [ ] earn points
	- [ ] healing sick animals (+10)
	- [ ] gathering data from tagged animals (+20?) [fewer of these animals overall]
	- [ ] gather data / heal incorrect animal (-15)
- [ ] controls
	- [ ] left controller is grabber
	- [ ] right controller is wand
	- [ ] animal needs to be grabbed before can heal / gather data using wand
- [ ] Additional Displays
	- [ ] timer on bubble wall (static on bubble)
	- [ ] score bar underneath timer


## Initial Notes

Main idea - still the same as before

    You're an underwater researcher trying to save the sea animals.

Setting - you're underwater in a bubble

    this is a magical bubble that acts as your timer.
    It provides you air, but decreases as time goes on.
    When it runs out you die; if you try to leave the bubble you die (it starts out big enough for ample walking space - and ends about when the bubble is the same size as you).
    When underwater animals enter it, they have a bubble of water around them so they can still swim / crawl perfectly fine through it.
    If you garner enough points before the bubble collapses, you complete the level.
    Everytime a sea creature enters your bubble, you hear a sound (since it's 3d). It's a way to let you know a new creature has entered that you need to pay attention to.
    Sea creatures can enter in the main water area (ie from the bubble, such as fish / turtles) or on the ground (crabs). You dont see them until they enter the area [though the surface of the bubble may change color a bit to denote an animal is near there but not yet entered].

Earn Points

    You earn points by grabbing and healing sick animals.
    You lose points by trying to heal an unsick animal or gather data from a non-tagged animal. [note: tagging in this sense is like scientific research tagging where they tag an animal to track data. the player does not tag any animals themselves, that's randomly designated].
    Gathering information from tagged animals earns you more points than healing injured sea creatures; however, there are fewer tagged animals overall.

Controls

    One controller is a hand. Use it to grab the animals.
    The other controller is a wand. Use it to either gather data from the tagged animal you're holding or to heal the sick / stuck / injured animal you're holding.
    To know that the healing / gathering data is working, the animal will change color as the process progresses while you're holding it.

Additional Visuals

    There will be a timer displayed on the inside surface of the bubble (static on the bubble's curvature).
    There will be a score bar underneath this timer.
    These will remain static on the surface of the bubble so you always know where to look back towards to check your status.

## Notes and Responses

Does the user need to move the bubble around at any time? If so, how do they do this?  If not, why not? 

	No they do not need to move the bubble around. It's predetermined by a small magic machine noting their starting location at the center of the available space. This is why we have the caveat that if you leave the bubbled area you die.

	Reasoning for not moving the bubble itself - one of our main issues in the last project was tackling too many game mechanics and features at once. We realized adding in this additional component could confuse the player and have them miss out on the main goal / interactions of how to work with the bubble itself (listening for sea animals and watching the bubble's surface to figure out where another one is coming in soon - a lot of sea animals are moving through at once)

·        Is the point of the bubble to just limit the extent to which the player has access to objects in the environment? 

	Yes and No. Yes it does limit the space to which the player has access to objects, and No because our original reasoning for the bubble was because we wanted a visual aspect to the clock running out that matched the "running out of air" idea. It worked best with a shrinking bubble because it also made the game harder to play the less time there is and heightens the stress for future levels where space and time constraints become the deciding factor.

·        What if an object or fish is at a height greater than a player can reach?  What can they do?

	The height of the scene starts out scaled to the user's height (ie predetermined distance so that nothing will be too far out of reach). Additionally, we might add in a game component with the wand that will help assist / bring the sea animals closer, but overall we think play-wise, the player might have to just wait for the animal to get within reach or jump for it (adds to the "actually under the water" feeling).

·        With this design everything in the world has to come to the player in order for them to interact with it.  Is that what you had intended? 

	Not everything will be "coming to the player for them to interact with it". When the bubble first starts out there is plenty of room for the player to walk around; there just happens to be less space as time goes on.

	Space-wise when the time is halfway through, there will be about as much space for the player to move around and interact with the sea animals in partially the same manner as in Matt's butterfly game (just to give an example of the interactability vs space that we're going for).

·        Are there any power ups that allow the player to enlarge the bubble?  If so, how does the player pick them up and/or acquire them?

	There is no way to enlarge the bubble while it is shrinking. We might look into adding in this element later if it helps the game play, but we think the points as is was fine.

·        What is the challenge/conflict that makes the gameplay interesting?

	Time vs space vs points. Earn as many points as you can (save as many animals as you can) before the time runs out. If you earn enough points before then, you pass the level. Otherwise you die and the level restarts.

