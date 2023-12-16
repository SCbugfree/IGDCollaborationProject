//This is the file storing dialogues in Scene9: FrontofCoffeeFork
// !Narrator @Player #Amelia/Daughter, %Jade/Mommy 1, ^: Mommy 2, &: NPC/No image
VAR Symbol = ""
VAR Response = ""
!I show up to the Coffee Fork at 8 in what I hope is concert-appropriate attire. I see Madi out front locking the door to the shop. #Narrator

$Hey you made it! Ready for tonight? #Madi

-> REA_Choice

== REA_Choice ==
* [Well, it's been a while.]
    ~ Symbol = "%"
    ~ Response = "No worries!"
->CONTINUE

* [Yes of course, I definitely know what I'm talking about] 
    ~ Symbol = "$"
    ~ Response = "I detect sarcasm." 
-> CONTINUE

* [Ready? I was born ready.]
    ~ Symbol = "¥"
    ~ Response = "Haha, it's okay if you aren't."
-> CONTINUE

== CONTINUE ==
{Symbol}{Response} #Madi
%I get to take you to your first concert in a long time? This is gonna be awesome! Just hang with me, and you’ll be good. This scene is super supportive. It’ll be a blast. #Madi

%Quick question? #MommyClone

%Shoot. #Madi

%What is... scene? #MommyClone

$Madi lets out a tiny laugh. #Narrator

%Sorry, sorry. It’s just weird because Scene can describe a “music scene” as it pertains to a community of people who like the same genre, but also describe a genre of music no one wants to admit they were into. #Madi

%Madi looks off into middle distance. She says nothing, but I can tell she’s thinking, “never again.” #Narrator

%That's confusing. #MommyClone

%You’ll get it. The important thing tonight is that you enjoy yourself. C’mon, let’s head to the show. #Madi

-> END