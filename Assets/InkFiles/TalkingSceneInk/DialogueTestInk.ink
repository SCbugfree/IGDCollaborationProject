//This is a testing file
VAR Dialogue = ""

//-> Main
//=== Main ===
$Greetings, traveler! #NPC1
$Welcome to this new world! #NPC1
¥Oh, how rude of me. #NPC1
¥I forgot to introduce myself. #NPC1
¥I am Alice, guardian of the Enchanted Grove. #NPC1
-> MYCHOICE

=== MYCHOICE ===
//Player make choice
$What brings you to this magical realm? #NPC1


    +[Ask about the Enchanted Grove's history]
        ~ Dialogue = "The Enchanted Grove has seen many stories unfold. Its ancient trees hold memories of the past."
        -> CHOICEMADE
        //-> DONE
        
    +[Inquire about Lumina's powers]
        ~ Dialogue = "Ah, the tales of the Grove are both fascinating and mysterious."
        -> CHOICEMADE
        //-> DONE
        
    +[Express curiosity about any dangers in the Grove]
        ~ Dialogue = "There are mystical beings and creatures that roam, but the Grove is protected by ancient spells."
        -> CHOICEMADE
        //-> DONE

=== CHOICEMADE ===
${Dialogue} #Player
-> CONTINUE

===CONTINUE===
$The tale of the Moonlit Masquerade is one that echoes through the ages. #NPC2
$Legend has it that once a century, the mystical beings of the Grove gather beneath the ancient Willow to celebrate. #NPC2
¥Their identities hidden behind enchanting masks. #NPC2
¥The last Masquerade was held many decades ago, but the magic lingers. #NPC2 
¥The Grove longs for the joyous melodies and laughter that accompanied that night. #NPC2
&Should you choose to seek it out, the Willow will guide your way. #NPC2


-> END

