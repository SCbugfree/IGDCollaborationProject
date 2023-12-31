//This is the file storing dialogues in Scene2: Gothic Glam
// !Narrator @Player #Amelia/Daughter, %Jade/Mommy 1, ^: Mommy 2, &: NPC/No image
VAR Symbol = ""
VAR Response = ""

-> Main
=== Main ===
!Welcome to Gothic Glam. Let me know if you need anything! #Employee

!I follow Amelia straight to the music section. She scours the shelfs for her favorite vinyl. #Narrator

!I let her do her own thing, while I go check out the rest of the store. #Narrator

!I stare down this one shirt based on my favorite band, My Synthetic Love, when… #Narrator

%Oops, sorry! #Jade

%Excuse me, I was standing- #MommyClone

!I look up at who ran into me, and she’s beautiful. Her jet black hair is perfectly silky, and her dark eye makeup makes her eyes shine. #Narrator

%Apologies. I was staring down this shirt for my daughter, and wasn’t looking where I was going. My name is Jade, by the way. #Jade

!Her accent is almost vampire-like in the most elegant way. #Narrator

!She points up to the exact same band shirt I was looking at. #Narrator

%Wow, your daughter has good taste! My Synthetic Love rocks. #MommyClone

%I am quite enamored with their music as well… What’s the song you would deem your favorite? #Jade

-> MSL_Choice

=== MSL_Choice ===
+ ["Adolescents"]
     ~ Symbol = "¥"
    ~ Response = "Oh… Interesting."
    -> CONTINUE
        
+ ["Greetings to the Dark March"]
    ~ Symbol = "$"
    ~ Response = " I quite like that one!"
    -> CONTINUE
        
 + ["Love"]
    ~ Symbol = "!"
    ~ Response = "That one is fine."
    -> CONTINUE


=== CONTINUE ===
{Symbol}{Response} #Jade

%In my humble opinion, Werewolf Dollars is superb. #Jade

%Would you care to join my daughter and I for a pretzel? #MommyClone

!Oh god, I probably made it too obvious that I’m trying to flirt with her… #Narrator

%Hmm… That would be pleasurable, but I have a parent-teacher conference with my daughter over there later this afternoon. #Jade

%She points to an gothic silver-haired teen in the anime section, seemingly debating between a Devil Killer or Battle on Giant shirt. #Lilith

%My daughter, Amelia, is the one over there, staring at the vinyls. Maybe they could be friends! We just moved to town, so she hasn’t met any friends yet. #MommyClone

%Lilith would be delighted. I shall go grab her. #Jade

!While Jade gets her daughter, I head over to Amelia to quickly purchase her vinyl. #Narrator

%Amelia, you won’t believe it. I met this totally awesome, fellow single mom in the band section. #MommyClone

!The cashier scans Amelia’s item and puts it in a Gothic Glam bag as I hand him a twenty dollar bill. #Narrator

%Oh is it that lady with the Victorian outfit? She’s pretty. #Amelia

%Yeah! She invited me over to her house tonight. Let me introduce you to her! #MommyClone

!I grab Amelia’s vinyl, and walk over to Jade who’s standing outside the Gothic Glam door with her daughter. #Narrator

%Jade, Lilith! This is Amelia. #MommyClone

%Amelia shyly waves to them. #Narrator

%Hello, Amelia. Pleasure to meet you. This is my daughter, Lilith. Do tell her about yourself, Lily. #Jade

!The girl, whose countenance initially exuded an air of aloofness, unfolded a smile towards Amelia. #Narrator

%Hey Amelia, pleasure meeting you. #Lilith


 -> END