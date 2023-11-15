Hello Player #speaker: NPC1 #portrait:NPC1_neutral
Good evening!
How are you doing today?
-> My_Choices
== My_Choices ==
* [Good] -> Good
* [Bad] -> Bad
* [What?] ->Repeat

== Good ==
I'm doing good, thank you.#speaker:Player#portrait:Player_happy
Good evening!#speaker:Player#portrait:Player_Default
->END

== Bad ==
Eh... not so well.#speaker:Player#portrait:Player_sad
Oh I am sorry to hear that.#speaker: NPC1#portrait:NPC1_sad
->END

== Repeat == 
Oh, maybe  you didn't hear me well.#speaker: NPC1#portrait:NPC1_neutral
I asked, "How are you doing today?"#speaker: NPC1

-> END